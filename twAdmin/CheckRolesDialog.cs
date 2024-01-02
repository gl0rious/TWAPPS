using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace twAdmin {
    public partial class CheckRolesDialog : Form {
        public CheckRolesDialog() {
            InitializeComponent();
        }

        public void SetMessage(string msg) {
            textBox1.Text = msg;
        }
    }
}
