using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TWOra;

namespace twAdmin {
    public partial class CopyForm : Form
    {
        List<User> users;
        public User selectedUser;
        public CopyForm(List<User> users)
        {
            this.users = users;
            InitializeComponent();
        }

        private void CopyForm_Load(object sender, EventArgs e)
        {
            foreach (var user in users)
                usersGridView.Rows.Add(user.Username, user.Fullname);
        }

        private void usersGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var selectedUsername = usersGridView.Rows[e.RowIndex].Cells[0].Value as string;
            selectedUser = users.First(u => u.Username == selectedUsername);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
