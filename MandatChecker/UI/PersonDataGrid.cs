using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MandatChecker.UI {
    class PersonDataGrid : DataGridView {
        DataGridViewTextBoxColumn clIndex;
        DataGridViewTextBoxColumn clStar;
        DataGridViewTextBoxColumn clAccount;
        DataGridViewTextBoxColumn clAmount;
        DataGridViewTextBoxColumn clFullname;
        DataGridViewTextBoxColumn clZeroOne;
        DataGridViewTextBoxColumn clTail;

        public PersonDataGrid() {
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;

            clIndex = new DataGridViewTextBoxColumn();
            clStar = new DataGridViewTextBoxColumn();
            clAccount = new DataGridViewTextBoxColumn();
            clAmount = new DataGridViewTextBoxColumn();
            clFullname = new DataGridViewTextBoxColumn();
            clZeroOne = new DataGridViewTextBoxColumn();
            clTail = new DataGridViewTextBoxColumn();
        }

    }
}
