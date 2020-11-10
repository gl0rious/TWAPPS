using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSHTW08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Chilkat.Ssh ssh = new Chilkat.Ssh();
            bool success = ssh.Connect("10.5.108.1", 22);
            if (success != true)
            {
                Debug.WriteLine(ssh.LastErrorText);
                return;
            }

            // Authenticate using login/password:
            success = ssh.AuthenticatePw("root", "pproot08");
            if (success != true)
            {
                Debug.WriteLine(ssh.LastErrorText);
                return;
            }

        }
    }
}
