using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TWOra;

namespace tw_app
{
    public partial class CopyForm : Form
    {
        List<User> users;
        public string selectedUser;
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
            selectedUser = usersGridView.Rows[e.RowIndex].Cells[0].Value as string;
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
