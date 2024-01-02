using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
//using TWOra;
using System.IO;
using System.Resources;
using MandatChecker.UI;
using MandatChecker.Fields;
using MandatChecker.Text;
using MandatChecker.Tokens;

namespace MandatChecker {
    public partial class MainForm : Form//,MandatView
    {
        ResourceManager resourceManager = new ResourceManager("",
            typeof(MainForm).Assembly);

        Mandat mandat;

        Color themeValidBackgroundColor = Color.LimeGreen;
        Color themeInvalidBackgroundColor = Color.Tomato;
        Color themeValidForeColor = Color.Empty;
        Color themeInvalidForeColor = Color.White;

        IList<Person> completeList;
        IList<Person> errorList;
        IList<Person> displayedList;

        public MainForm() {
            InitializeComponent();
        }

        private void UsersGridView_CellValueNeeded( object sender, DataGridViewCellValueEventArgs e ) {
            if( displayedList == null || e.RowIndex >= displayedList.Count )
                return;
            var person = displayedList[e.RowIndex];
            var columnName = usersGridView.Columns[e.ColumnIndex].HeaderText;
            var cell = usersGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            Field value = null;
            switch( e.ColumnIndex ) {
                case 0:
                    e.Value = person.Index.ToString().PadLeft(mandat.PersonList.Count.ToString().Length);
                    return;
                case 1:
                    value = person.Star;
                    break;
                case 2:
                    value = person.Account;
                    break;
                case 3:
                    value = person.Amount;
                    break;
                case 4:
                    value = person.Fullname;
                    break;
                case 5:
                    value = person.One;
                    break;
                case 6:
                    value = person.Tail;
                    break;
            }
            cell.Style.BackColor = value != null && !value.HasErrors ?
                Color.Empty : themeInvalidBackgroundColor;
            cell.Style.ForeColor = value != null && !value.HasErrors ?
                themeValidForeColor : themeInvalidForeColor;
            e.Value = value;
        }

        //Database db;

        private void MainForm_Load( object sender, EventArgs e ) {
            //ConnectForm form = new ConnectForm();
            //if(form.ShowDialog() == DialogResult.OK)
            //    db = form.Database;
            //else {
            //    Close();
            //    return;
            //}
            setUpHeader();

            //openFile(@"G:\ANEM08202.TXT");
        }

        private void setColumnsWidth() {
            Action<DataGridViewColumn, int> PadRight = ( DataGridViewColumn column, int length ) =>
                column.HeaderText = column.HeaderText.Trim().PadRight(length);

            Action<DataGridViewColumn, int> PadLeft = ( DataGridViewColumn column, int length ) =>
                column.HeaderText = column.HeaderText.Trim().PadLeft(length);

            PadLeft(clIndex, mandat.PersonList.Count.ToString().Length);
            //PadLeft(clStar, mandat.PersonList.ToString().Length);
            PadRight(clAccount, 20);
            PadLeft(clAmount, 17);
            PadRight(clFullname, 27);
            PadRight(clTail, mandat.PersonList.Max(p => p.Tail.TextLength));
        }

        private void setUpHeader() {
            Action<Label, int> PadRight = ( Label label, int length ) =>
                label.Text = label.Text.Trim().PadRight(length);

            Action<Label, int> PadLeft = ( Label label, int length ) =>
                label.Text = label.Text.Trim().PadLeft(length);

            PadRight(accountLabel, 20);
            PadLeft(totalLabel, 17);
            PadLeft(lineCountLabel, 9);
            PadLeft(dateLabel, 7);
            PadLeft(ordLabel, 8);
            PadLeft(mandatNumLabel, 6);
            PadRight(tailLabel, 10);

            foreach( var textBox in tableLayoutPanel1.Controls.OfType<TextBox>() )
                textBox.Click += ( s, a ) => {
                    textBox.SelectAll();
                    var field = textBox.Tag as Field;
                    DisplayErrors(field);
                };
        }

        private void DisplayErrors( Field field ) {
            errorsTextBox.Clear();
            errorsTextBox.BackColor = Color.LightGray;
            if( field != null && field.HasErrors ) {
                errorsTextBox.BackColor = Color.Tomato;
                foreach( var message in field.Errors ) {
                    errorsTextBox.AppendText("# " + message.ToUpper() + Environment.NewLine);
                }
            }
        }

        private void checkBenifDB( string name, string account ) {
            //if(Person.Exists(db,name, account))
            //{

            //}
        }

        private void btnOpen_Click( object sender, EventArgs e ) {
            if( openFileDialog1.ShowDialog() == DialogResult.OK ) {
                openFile(openFileDialog1.FileName);
            }
        }

        private void openFile( string filePath ) {
            mandat = Mandat.fromFile(filePath);
            completeList = mandat.PersonList;
            errorList = mandat.PersonList.Where(p => p.HasErrors).ToList();

            errorsButton.Enabled = errorList.Count > 0;
            errorsButton.Text = $"Erreurs ({errorList.Count})";

            displayedList = completeList;
            usersGridView.RowCount = 0;
            usersGridView.RowCount = displayedList.Count;

            updateHeader();
            setColumnsWidth();
            usersGridView.Select();
        }

        private void toolStripButton1_CheckedChanged( object sender, EventArgs e ) {
            usersGridView.RowCount = 0;
            displayedList = errorsButton.Checked ? errorList : completeList;
            usersGridView.RowCount = displayedList.Count;
            errorsButton.ForeColor = errorsButton.Checked ? Color.Red : SystemColors.ControlText;
        }

        private void textBox1_Enter( object sender, EventArgs e ) {
            var control = sender as Control;
            control.BackColor = SystemColors.Highlight;
            control.ForeColor = SystemColors.HighlightText;
        }

        private void textBox1_Leave( object sender, EventArgs e ) {
            var control = sender as Control;
            control.BackColor = Color.LimeGreen;
            control.ForeColor = SystemColors.ControlText;
        }

        void updateHeader() {
            //12345123451234512345
            //12,123,123,123.99
            //accountField.



            Action<TextBox, Field> setTextBox = ( TextBox textBox, Field field ) => {
                textBox.BackColor = !field.HasErrors ? themeValidBackgroundColor : themeInvalidBackgroundColor;
                textBox.Text = field.ToString();
                textBox.Tag = field;
            };

            setTextBox(starTextBox, mandat.Star);
            setTextBox(accountTextBox, mandat.Account);
            setTextBox(totalTextBox, mandat.Amount);
            setTextBox(computedTotalTextBox, mandat.ComputedAmount);
            setTextBox(lineCountTextBox, mandat.LineCount);
            setTextBox(computedLineCountTextBox, mandat.ComputedLineCount);
            setTextBox(dateTextBox, mandat.Date);
            setTextBox(ordTextBox, mandat.Ordonnateur);
            setTextBox(mandatNumTextBox, mandat.Number);
            setTextBox(zeroTextBox, mandat.Zero);
            setTextBox(tailTextBox, mandat.Tail);
        }

        private void usersGridView_CellEnter( object sender, DataGridViewCellEventArgs e ) {
            var field = usersGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as Field;
            DisplayErrors(field);
        }

        private void usersGridView_Leave( object sender, EventArgs e ) {
            usersGridView.ClearSelection();
        }
    }
}
