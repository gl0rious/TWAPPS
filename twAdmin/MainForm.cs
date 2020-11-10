using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using TWOra;

namespace tw_app
{
    public partial class MainForm  : Form
    {
        Database db;
        List<string> validRoles;
        List<string> loadedUserRoles;
        List<string> editedUserRoles;
        Dictionary<string, List<string>> roleTree = new Dictionary<string, List<string>>();
        List<User> users;
        XElement configRoles;
        Font normalFont;
        Font boldFont;
        string selectedUser;

        List<CheckBox> allCheckBoxes = new List<CheckBox>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConnectForm dialog = new ConnectForm();
            if(dialog.ShowDialog() == DialogResult.OK) {
                this.Text = string.Format("TW Admin [TW08]");
            }
            else {
                this.Close();
                return;
            }
            normalFont = new Font("arial",10);
            boldFont = new Font(normalFont,FontStyle.Bold);
            configRoles = XElement.Load(@"FormRoles.xml");
            db = dialog.Database;
            setValidRoles();
            initTabs();
            initUsersTable();
        }

        private void initTabs() {
            foreach(var appRoles in configRoles.Elements()) {
                var tab = new TabPage(appRoles.Name.LocalName);
                tab.Name = appRoles.Name.LocalName;
                tabs.Controls.Add(tab);
                var flow = new FlowLayoutPanel();
                flow.Dock = DockStyle.Fill;
                flow.FlowDirection = FlowDirection.TopDown;
                flow.WrapContents = false;
                flow.AutoScroll = true;
                flow.AutoSize = true;
                tab.Controls.Add(flow);
                var menuItem = cmUsers.Items.Add(tab.Name) as ToolStripMenuItem;
                menuItem.CheckOnClick = true;
                menuItem.Checked = false;
                menuItem.Click += MenuItem_Click; ;
                flow.SuspendLayout();
                foreach(var roleGroup in appRoles.Elements()) {
                    var label = new Label();
                    label.AutoSize = true;
                    label.Text = roleGroup.Name.LocalName;
                    label.Font = boldFont;
                    flow.Controls.Add(label);
                    foreach(var role in roleGroup.Elements())
                        if(validRoles.Contains(role.Name.LocalName)) {
                            var cb = new CheckBox();
                            cb.AutoCheck = false;
                            cb.Name = role.Name.LocalName;
                            cb.Font = normalFont;
                            cb.Margin = new Padding(20, 0, 0, 0);
                            cb.AutoSize = true;
                            cb.Text = role.Value;
                            flow.Controls.Add(cb);
                            allCheckBoxes.Add(cb);
                            cb.Tag = tab;
                            cb.CheckedChanged += Cb_CheckedChanged;
                        }
                }
                flow.ResumeLayout();
                flow.PerformLayout();
                flow.MouseEnter += Flow_MouseEnter;
            }      
        }

        private void MenuItem_Click(object sender, EventArgs e) {
            var menuItem = sender as ToolStripMenuItem;
            foreach(ToolStripMenuItem item in cmUsers.Items) {
                item.Checked = item == menuItem;
            }
            if(menuItem == allToolStripMenuItem)
                initUsersTable();
            else {
                var appRoles = roleTree[menuItem.Text];
                usersGridView.SuspendLayout();
                usersGridView.Rows.Clear();
                foreach(User user in users) {
                    var roles = db.GetUserRoles(user.Username);
                    if(roles.Exists(r=>appRoles.Contains(r)))
                        usersGridView.Rows.Add(user.Username, user.Fullname);
                }
                usersGridView.ResumeLayout();
            }
        }

        private void Flow_MouseEnter(object sender, EventArgs e) {
            var flow = sender as FlowLayoutPanel;
            flow.Focus();
        }

        private void Cb_CheckedChanged(object sender, EventArgs e) {
            var cb = sender as CheckBox;
            cb.ForeColor = cb.Checked ? Color.DarkRed :
                Color.FromKnownColor(KnownColor.ControlText);
            if(cb.Checked && !editedUserRoles.Contains(cb.Name)) {
                editedUserRoles.Add(cb.Name);
            }
            if(!cb.Checked && editedUserRoles.Contains(cb.Name)) {
                editedUserRoles.Remove(cb.Name);
            }
            if(!edit_sbtn.Enabled)
                save_sbtn.Enabled = editedUserRoles.Except(loadedUserRoles).Count() > 0 ||
                    loadedUserRoles.Except(editedUserRoles).Count() > 0;
            updateStats();
        }

        void updateStats() {
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                int checkedCount = flow.Controls.OfType<CheckBox>().Count(cb => cb.Checked);
                tab.Text = checkedCount > 0 ? $"{tab.Name} ({checkedCount})" : $"{tab.Name}";
            }
        }
        private void setValidRoles()
        {            
            validRoles = db.GetAllRoles();
            List<string> configValidRoles = new List<string>();
            foreach(var appRoles in configRoles.Elements()) {
                roleTree[appRoles.Name.LocalName] = new List<string>();
                foreach(var roleGroup in appRoles.Elements())
                    foreach(var role in roleGroup.Elements()) {
                        configValidRoles.Add(role.Name.LocalName);
                        roleTree[appRoles.Name.LocalName].Add(role.Name.LocalName);
                    }
            }
            validRoles.RemoveAll(role => !configValidRoles.Contains(role));
        }

        private void initUsersTable()
        {
            users = db.GetUsersList();
            users.Sort((user1,user2)=>user1.Username.CompareTo(user2.Username));
            usersGridView.SuspendLayout();
            usersGridView.Rows.Clear();
            foreach (var user in users)
                usersGridView.Rows.Add(user.Username,user.Fullname);
            usersGridView.ResumeLayout();
        }

        private void usersGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var user = usersGridView.Rows[e.RowIndex].Cells[0].Value as string;
            if(user!=selectedUser)
                selectUser(user);
        }

        private void selectUser(string user)
        {
            selectedUser = user;
            loadedUserRoles = db.GetUserRoles(selectedUser);
            loadedUserRoles.RemoveAll(role => !validRoles.Contains(role));
            editedUserRoles = loadedUserRoles.ToList();
            var flow = tabs.SelectedTab.Controls[0] as FlowLayoutPanel;
            allCheckBoxes.ForEach(cb => cb.Checked = loadedUserRoles.Contains(cb.Name));
            updateStats();
        }

        private void edit_sbtn_Click(object sender, EventArgs e)
        {
            usersGridView.Enabled = false;
            cancel_sbtn.Enabled = true;
            edit_sbtn.Enabled = false;
            //save_sbtn.Enabled = true;
            copy_sbtn.Enabled = true;
            allCheckBoxes.ForEach(cb => cb.AutoCheck = true);
        }

        private void save_sbtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Save","Save changes!",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                saveUserRoles();
            }
            selectUser(selectedUser);
            usersGridView.Enabled = true;
            cancel_sbtn.Enabled = false;
            edit_sbtn.Enabled = true;
            save_sbtn.Enabled = false;
            copy_sbtn.Enabled = false;
            allCheckBoxes.ForEach(cb => cb.AutoCheck = false);
        }

        private void saveUserRoles()
        {
            editedUserRoles.Select(role => !loadedUserRoles.Contains(role));
            editedUserRoles.Except(loadedUserRoles).ToList()
                .ForEach(role => db.addRoleToUser(selectedUser, role));
            loadedUserRoles.Except(editedUserRoles).ToList()
                .ForEach(role => db.removeRoleFromUser(selectedUser, role));
        }

        private void cancel_sbtn_Click(object sender, EventArgs e)
        {
            usersGridView.Enabled = true;
            edit_sbtn.Enabled = true;
            cancel_sbtn.Enabled = false;
            save_sbtn.Enabled = false;
            copy_sbtn.Enabled = false;
            allCheckBoxes.ForEach(cb => cb.AutoCheck = false);
            selectUser(selectedUser);
        }

        private void copy_sbtn_Click(object sender, EventArgs e)
        {
            CopyForm form = new CopyForm(users);
            if (form.ShowDialog() == DialogResult.OK)
            {
                var copiedRoles = db.GetUserRoles(form.selectedUser);
                editedUserRoles = copiedRoles.ToList();
                allCheckBoxes.ForEach(cb => cb.Checked = copiedRoles.Contains(cb.Name));
            }
        }

        private void usersGridView_MouseEnter(object sender, EventArgs e) {
            usersGridView.Focus();
        }
    }
}
