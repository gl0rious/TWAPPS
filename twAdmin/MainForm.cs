using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TWOra;

namespace tw_app {
    public partial class MainForm : Form {
        Database db;
        List<Role> loadedUserRoles;
        List<Role> editedUserRoles;
        List<Role> allRoles;
        List<User> users;
        User selectedUser;
        Font normalFont;
        Font boldFont;
        Color checkedColor;
        Color uncheckedColor;

        public MainForm() {
            InitializeComponent();
            normalFont = new Font("arial", 10);
            boldFont = new Font(normalFont, FontStyle.Bold);
            checkedColor = Color.DarkRed;
            uncheckedColor = Color.FromKnownColor(KnownColor.ControlText);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ConnectForm dialog = new ConnectForm();
            if(dialog.ShowDialog() == DialogResult.OK) {
                this.Text = string.Format($"TW Admin [{dialog.Database.connectedUser}]");
            }
            else {
                this.Close();
                return;
            }
            db = dialog.Database;
            allRoles = Role.GetAllTWRoles(db);
            initTabs();
            initUsersTable();
            Task.Factory.StartNew(() => users.ForEach(u => u.GetGrantedRoles()));
        }

        private void initTabs() {
            var appNames = allRoles.Select(r => r.AppName).Distinct();
            foreach(var appName in appNames) {
                var tab = new TabPage(appName);
                tab.Name = appName;
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
                menuItem.Click += menuItem_Click;
                flow.ContextMenuStrip = cmSelect;
                flow.SuspendLayout();
                var groupNames = allRoles.Where(r => r.AppName == appName)
                    .Select(r => r.GroupName).Distinct();
                foreach(var groupName in groupNames) {
                    var label = new Label();
                    label.AutoSize = true;
                    label.Text = groupName;
                    label.Font = boldFont;
                    flow.Controls.Add(label);
                    var groupRoles = allRoles.Where(r => r.AppName == appName
                        && r.GroupName == groupName).Distinct();
                    foreach(var role in groupRoles) {
                        var cb = new CheckBox();
                        cb.AutoCheck = false;
                        cb.Name = role.Name;
                        cb.Tag = role;
                        cb.Font = normalFont;
                        cb.Margin = new Padding(20, 0, 0, 0);
                        cb.AutoSize = true;
                        cb.Text = role.Title;
                        cb.CheckedChanged += checkBox_CheckedChanged;
                        flow.Controls.Add(cb);
                    }
                }
                flow.ResumeLayout();
                flow.PerformLayout();
                flow.MouseEnter += flow_MouseEnter;
            }
        }

        private void menuItem_Click(object sender, EventArgs e) {
            var menuItem = sender as ToolStripMenuItem;
            foreach(ToolStripMenuItem item in cmUsers.Items)
                item.Checked = item == menuItem;
            if(menuItem == allToolStripMenuItem)
                initUsersTable();
            else {
                var watch = Stopwatch.StartNew();
                var appName = menuItem.Text;
                gvUsers.Rows.Clear();
                var appUsers = users.Where(u => u.GetGrantedRoles()
                    .Exists(r => r.AppName == appName)).ToList();
                foreach(User user in appUsers)
                    gvUsers.Rows.Add(user.Username, user.Fullname);
                watch.Stop();
                Debug.WriteLine($"Elapsed time = {watch.Elapsed}");
            }
        }

        private void flow_MouseEnter(object sender, EventArgs e) {
            var flow = sender as FlowLayoutPanel;
            flow.Focus();
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e) {
            var cb = sender as CheckBox;
            var role = cb.Tag as Role;
            cb.ForeColor = cb.Checked ? checkedColor : uncheckedColor;
            if(!btnEdit.Enabled) {
                if(cb.Checked && !editedUserRoles.Contains(role))
                    editedUserRoles.Add(role);
                if(!cb.Checked && editedUserRoles.Contains(cb.Tag))
                    editedUserRoles.Remove(role);
                if(!btnEdit.Enabled)
                    btnSave.Enabled = editedUserRoles.Exists(r => !loadedUserRoles.Contains(r)) ||
                        loadedUserRoles.Exists(r => !editedUserRoles.Contains(r));
                updateTabStats(tabs.SelectedTab);
            }
        }

        void updateTabStats(TabPage tab) {
            var flow = tab.Controls[0] as FlowLayoutPanel;
            int checkedCount = flow.Controls.OfType<CheckBox>().Count(cb => cb.Checked);
            tab.Text = checkedCount > 0 ? $"{tab.Name} ({checkedCount})" : $"{tab.Name}";
        }


        private void initUsersTable() {
            users = User.GetUsersList(db);
            users.Sort();
            gvUsers.Rows.Clear();
            foreach(var user in users)
                gvUsers.Rows.Add(user.Username, user.Fullname);
        }

        private void gvUsers_RowEnter(object sender, DataGridViewCellEventArgs e) {
            var username = gvUsers.Rows[e.RowIndex].Cells[0].Value as string;
            if(selectedUser == null || selectedUser.Username != username)
                selectUser(username);
        }

        private void selectUser(string username) {
            selectedUser = users.FindByName(username);
            loadedUserRoles = selectedUser.GetGrantedRoles();
            selectCheckBoxes(loadedUserRoles);
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            gvUsers.Enabled = false;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
            btnCopy.Enabled = true;
            cmSelect.Enabled = true;
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                flow.Controls.OfType<CheckBox>().ToList()
                    .ForEach(cb => cb.AutoCheck = true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(MessageBox.Show($"Do you want to save changes to '{selectedUser}'?",
                "Save Changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                saveUserRoles();
            }
            selectUser(selectedUser.Username);
            gvUsers.Enabled = true;
            btnCancel.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCopy.Enabled = false;
            cmSelect.Enabled = false;
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                flow.Controls.OfType<CheckBox>().ToList()
                    .ForEach(cb => cb.AutoCheck = false);
            }
        }

        private void saveUserRoles() {
            editedUserRoles.Except(loadedUserRoles).ToList()
                .ForEach(role => selectedUser.addRoleToUser(role));
            loadedUserRoles.Except(editedUserRoles).ToList()
                .ForEach(role => selectedUser.removeRoleFromUser(role));
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            gvUsers.Enabled = true;
            btnEdit.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnCopy.Enabled = false;
            cmSelect.Enabled = false;
            selectUser(selectedUser.Username);
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                flow.Controls.OfType<CheckBox>().ToList()
                    .ForEach(cb => cb.AutoCheck = false);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e) {
            CopyForm form = new CopyForm(users);
            if(form.ShowDialog() == DialogResult.OK) {
                var fromUser = users.Find(u => u.Username == form.selectedUser);
                var copiedRoles = fromUser.GetGrantedRoles();
                selectCheckBoxes(copiedRoles);
            }
        }

        private void gvUsers_MouseEnter(object sender, EventArgs e) {
            gvUsers.Focus();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            var flow = tabs.SelectedTab.Controls[0] as FlowLayoutPanel;
            flow.Controls.OfType<CheckBox>().ToList().ForEach(cb => cb.Checked = true);
        }

        private void deselectAllToolStripMenuItem_Click(object sender, EventArgs e) {
            var flow = tabs.SelectedTab.Controls[0] as FlowLayoutPanel;
            flow.Controls.OfType<CheckBox>().ToList().ForEach(cb => cb.Checked = false);
        }

        private void selectCheckBoxes(List<Role> roles) {
            editedUserRoles = roles.ToList();
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                flow.Controls.OfType<CheckBox>().ToList()
                    .ForEach(cb => cb.Checked = editedUserRoles.Contains(cb.Tag));
            }
            foreach(var tab in tabs.Controls.OfType<TabPage>())
                updateTabStats(tab);
        }
    }
}
