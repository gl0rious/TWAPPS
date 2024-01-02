using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWOra;

namespace unBlock {
    public partial class MainForm : Form {
        Database db;
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ConnectForm form = new ConnectForm();
            if(form.ShowDialog() != DialogResult.OK)
                Close();
            db = form.Database;
            var apps = Role.AllTWRoles(db).Select(r => r.AppName).Distinct();
            cbApps.Items.Add("All");
            foreach(var app in apps)
                cbApps.Items.Add(app);
            cbApps.SelectedIndex = 0;
        }

        void fillGrid() {
            gvUsers.Rows.Clear();
            var sessions = Session.AllSessions(db);
            foreach(var user in sessions.Select(s => s.User).Distinct()) {
                gvUsers.Rows.Add(
                    false,
                    user.Username,
                    user.Fullname,
                    sessions.Count(s => s.User.Username == user.Username),
                    user.State.ToString(),
                    sessions.Where(s => s.User == user).Select(s => s.LogonTime).Max());
            }
        }

        private void cbApps_SelectedIndexChanged(object sender, EventArgs e) {
            gvUsers.Rows.Clear();
            var sessions = Session.AllSessions(db);
            var users = sessions.Select(s => s.User).Distinct();
            var app = (string)cbApps.SelectedItem;

            if(app != "All")
                users = users.Where(u => u.GetGrantedRoles().Exists(r => r.AppName == app));
            foreach(var user in users) {
                gvUsers.Rows.Add(
                    false,
                    user.Username,
                    user.Fullname,
                    sessions.Count(s => s.User.Username == user.Username),
                    user.State.ToString(),
                    sessions.Where(s => s.User == user).Select(s => s.LogonTime).Max());
            }
        }
    }
}
