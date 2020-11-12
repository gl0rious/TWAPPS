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

namespace unBlock
{
    public partial class MainForm : Form
    {
        Database db;
        public MainForm()
        {
            InitializeComponent();
        }
 
        private void MainForm_Load(object sender, EventArgs e) {
            ConnectForm form = new ConnectForm();
            if(form.ShowDialog()!=DialogResult.OK)
                Close();
            db = form.Database;
            fillGrid();
        }

        void fillGrid() {
            dataGridView1.Rows.Clear();
            var users = db.GetUsersList();
            var sessions = db.GetUserSessions();
            foreach(var user in users) {
                if(sessions.Exists(s=>s.Username==user.Username))
                    dataGridView1.Rows.Add(
                        false, 
                        user.Username, 
                        user.Fullname,
                        sessions.Count(s => s.Username == user.Username),
                        user.State.ToString());
            }
        }
    }
}
