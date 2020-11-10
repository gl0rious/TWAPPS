using System;
using System.Windows.Forms;

namespace TWOra {
    public partial class ConnectForm : Form
    {
        public Database Database { get; private set; }
        public ConnectForm() {
            InitializeComponent();
            Database = new Database();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            var username = txtUsername.Text;
            var password = txtPassword.Text;
            if(username == null || username == "") {
                MessageBox.Show("Username is empty", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                ConnectionSetting.Username = username;
            if(password == null || password == "") {
                MessageBox.Show("Password is empty", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                ConnectionSetting.Password = password;
            if(Database.Connect())
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show(Database.LastError, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
        }

        private void txt_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyData != Keys.Enter)
                return;
            btnOK.PerformClick();
        }

        private void ConnectForm_Load(object sender, EventArgs e) {
            if(ConnectionSetting.LoadConfig()) {
                if(Database.Connect())
                    DialogResult = DialogResult.OK;
                else
                    MessageBox.Show(Database.LastError, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtUsername.Text = ConnectionSetting.Username;
        }
    }
}
