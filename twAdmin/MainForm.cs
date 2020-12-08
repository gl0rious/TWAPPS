using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TWOra;

namespace tw_app {
    public partial class MainForm : Form {
        Database db;
        List<Role> editedUserRoles;
        List<string> allApps;
        List<Role> allRoles;
        List<User> allUsers;
        List<Session> allSessions;
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
            if(dialog.ShowDialog() == DialogResult.OK)
                this.Text = string.Format($"TW Admin [{ConnectionSetting.Username}]");
            else {
                this.Close();
                return;
            }
            db = dialog.Database;
            if(!db.isDBASession()) {
                MessageBox.Show($"'{ConnectionSetting.Username}' is not BDA");
                this.Close();
                return;
            }
            allRoles = Role.AllTWRoles(db);
            allApps = allRoles.Select(r => r.AppName).Distinct().ToList();
            allUsers = User.AllUsers(db);
            allUsers.Sort();
            Task.Factory.StartNew(() => {
                allUsers.ForEach(u => u.GetGrantedRoles());
                cbApps.Invoke(new Action(()=>{ cbApps.Enabled = true; }));
            });
            cbApps.Enabled = false;
            cbApps.Items.AddRange(new string[]{"ALL"}.Concat(allApps).ToArray());
            cbApps.SelectedIndex = 0;
            initTabs();
            cbStates.SelectedIndex = 0;
        }

        private void initTabs() {
            foreach(var appName in allApps) {
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
                if(!btnEdit.Enabled && selectedUser != null)
                    btnSave.Enabled = editedUserRoles.Exists(
                        r => !selectedUser.GetGrantedRoles().Contains(r)) ||
                        selectedUser.GetGrantedRoles().Exists(r => !editedUserRoles.Contains(r));
                updateTabStats(tabs.SelectedTab);
            }
        }

        void updateTabStats(TabPage tab) {
            var flow = tab.Controls[0] as FlowLayoutPanel;
            int checkedCount = flow.Controls.OfType<CheckBox>().Count(cb => cb.Checked);
            tab.Text = checkedCount > 0 ? $"{tab.Name} ({checkedCount})" : $"{tab.Name}";
        }

        private void selectUser(User user) {
            selectedUser = user;
            lblUser.Text = user != null ? $"{user.Username} : {user.Fullname}" : "";
            var roles = selectedUser != null? selectedUser.GetGrantedRoles():new List<Role>();
            selectCheckBoxes(roles);
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            gvUsers.Enabled = false;
            btnCancel.Enabled = true;
            btnEdit.Enabled = false;
            btnCopy.Enabled = true;
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                flow.ContextMenuStrip = cmSelect;
                flow.Controls.OfType<CheckBox>().ToList()
                    .ForEach(cb => cb.AutoCheck = true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if(MessageBox.Show($"Do you want to save changes to '{selectedUser.Username}'?",
                "Save Changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
                saveUserRoles();
            }
            selectUser(selectedUser);
            gvUsers.Enabled = true;
            btnCancel.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCopy.Enabled = false;
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                flow.ContextMenuStrip = null;
                flow.Controls.OfType<CheckBox>().ToList()
                    .ForEach(cb => cb.AutoCheck = false);
            }
        }

        private void saveUserRoles() {
            editedUserRoles.Except(selectedUser.GetGrantedRoles()).ToList()
                .ForEach(role => selectedUser.addRoleToUser(role));
            selectedUser.GetGrantedRoles().Except(editedUserRoles).ToList()
                .ForEach(role => selectedUser.removeRoleFromUser(role));
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            gvUsers.Enabled = true;
            btnEdit.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnCopy.Enabled = false;
            selectUser(selectedUser);
            foreach(var tab in tabs.Controls.OfType<TabPage>()) {
                var flow = tab.Controls[0] as FlowLayoutPanel;
                flow.ContextMenuStrip = null;
                flow.Controls.OfType<CheckBox>().ToList()
                    .ForEach(cb => cb.AutoCheck = false);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e) {
            CopyForm form = new CopyForm(allUsers);
            if(form.ShowDialog() == DialogResult.OK) {
                var copiedRoles = form.selectedUser.GetGrantedRoles();
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

        private void cbApps_SelectedIndexChanged(object sender, EventArgs e) {
            refreshUsersList();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            allSessions = Session.AllSessions(db);
            refreshUsersList();
        }

        private void refreshUsersList() {
            List<User> users = allUsers;
            if(cbStates.SelectedItem as string == "Connected") {
                allSessions = Session.AllSessions(db);
                users = users.Where(u => allSessions.Exists(s => s.Username == u.Username)).ToList();
            }
            else if(cbStates.SelectedItem as string == "Locked")
                users = users.Where(u => u.Locked).ToList();
            if(cbApps.SelectedIndex != 0)
                users = users.Where(u => u.GetGrantedRoles()
                    .Exists(r => r.AppName == (string)cbApps.SelectedItem)).ToList();
            gvUsers.Rows.Clear();
            foreach(var user in users)
                gvUsers.Rows.Add(user.Username, user.Fullname);
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedUsernames = gvUsers.SelectedRows.OfType<DataGridViewRow>().Select(r => r.Cells[0].Value as string);
            var selectedSessions = allSessions.Where(s => selectedUsernames.Contains(s.Username)).ToList();
            selectedSessions.ForEach(s => s.Terminate());
            refreshUsersList();
        }

        private void lockUserToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedUsernames = gvUsers.SelectedRows.OfType<DataGridViewRow>().Select(r => r.Cells[0].Value as string);
            var selectedUsers = allUsers.Where(u => selectedUsernames.Contains(u.Username)).ToList();
            selectedUsers.ForEach(u => u.LockUser());
        }

        private void unlockUserToolStripMenuItem_Click(object sender, EventArgs e) {
            var selectedUsernames = gvUsers.SelectedRows.OfType<DataGridViewRow>().Select(r => r.Cells[0].Value as string);
            var selectedUsers = allUsers.Where(u => selectedUsernames.Contains(u.Username)).ToList();
            selectedUsers.ForEach(u => u.UnlockUser());
            refreshUsersList();
        }

        private void cbStates_SelectedIndexChanged(object sender, EventArgs e) {
            refreshUsersList();
        }

        private void gvUsers_SelectionChanged(object sender, EventArgs e) {
            btnEdit.Enabled = gvUsers.SelectedRows.Count == 1;
            if(gvUsers.SelectedRows.Count == 1) {
                var username = gvUsers.SelectedRows[0].Cells[0].Value as string;
                selectUser(allUsers.First(u => u.Username == username));
            }
            else
                selectUser(null);
        }
    }
}
