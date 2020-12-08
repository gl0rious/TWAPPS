using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TWOra;

namespace MandatChecker {
    public partial class MainForm : Form
    {
        enum MandatHint
        {
            Normal,
            Error,
            Warning,
            Focus
        }
        public MainForm()
        {
            InitializeComponent();

        }
        Regex digitsOnly = new Regex(@"\d+");
        Regex nameRule = new Regex(@"[A-Z \/\-\.]+");
        Regex tailZeros = new Regex(@"0*$");
        Color[] colors;
        Database db;
        Scanner scanner;
        

        //public List<Tuple<string, string>> findSimilairUsers(string name, string account)
        //{
        //    //List<Tuple<string, string>> users = new List<Tuple<string, string>>();
        //    //var rd = execute($@"SELECT nom,num_compte FROM personne WHERE nom='{name}' or num_compte='{account}'");
        //    //while (rd.Read())
        //    //    users.Add(new Tuple<string, string>(rd.GetString(0), rd.GetString(1)));
        //    //return users;
        //}
        private void MainForm_Load(object sender, EventArgs e)
        {
            ConnectForm form = new ConnectForm();
            if(form.ShowDialog() == DialogResult.OK)
                db = form.Database;
            else {
                Close();
                return;
            }
            ColorConverter cc = new ColorConverter();
            colors = new Color[]{
                ColorTranslator.FromHtml("#b0c984"),// normal
                ColorTranslator.FromHtml("#DFF2BF"),// light normal
                ColorTranslator.FromHtml("#ee0000"),// error 
                ColorTranslator.FromHtml("#cc0000"),// light error
                ColorTranslator.FromHtml("#FFBF00"),// warning
                ColorTranslator.FromHtml("#FFBF33"),// light warning
                ColorTranslator.FromHtml("#0000FF"),// Focus
                ColorTranslator.FromHtml("#0000FF"),// light Focus
            };
            loadFile(@"G:\tw_dev\ANEM0820.txt");
        }

        private void loadFile(string path) {
            scanner = new Scanner(path);
            mandatTB.Text = scanner.getPrintableText();
            dataGridView1.Rows.Clear();
            checkMandat();
        }

        private void checkMandat() {
            var star = scanner.getToken(1);
            hintToken(star);
            var acct = scanner.getToken(20);
            hintToken(acct);
            var amnt = scanner.getToken(13);
            hintToken(amnt);
            var bcnt = scanner.getToken(7);
            hintToken(bcnt);
            var mnth = scanner.getToken(2);
            hintToken(mnth);
            var year = scanner.getToken(4);
            hintToken(year);
            var ordn = scanner.getToken(8);
            hintToken(ordn);
            var mndt = scanner.getToken(6);
            hintToken(mndt);
            var zero = scanner.getToken(1);
            hintToken(zero);
            var tail = scanner.getRemaining();
            hintToken(tail,MandatHint.Warning);

            if(!star.isStar())
                addErrorMsg(star,"'*' expected");
            if(!acct.isAccount())
                addErrorMsg(acct, "not a valid account");
            if(!amnt.isAmount())
                addErrorMsg(amnt, "not a valid amount");
            if(!bcnt.isBenifCount())
                addErrorMsg(bcnt, "not a benif count");
            if(!mnth.isMonth())
                addErrorMsg(mnth, "not a valid month");
            if(!year.isYear())
                addErrorMsg(year, "not a valid year");
            if(!ordn.isOrd())
                addErrorMsg(ordn, "not a valid ordonateur");
            if(!mndt.isMandatNumber())
                addErrorMsg(mndt, "not a valid mandat number");
            if(!zero.isZero())
                addErrorMsg(zero, "'0' expected");
            if(!tail.isTailWhiteSpace())
                addErrorMsg(tail, "excessive text");
            while(scanner.nextLine())
                checkBenif();
        }

        void checkBenif() {
            var star = scanner.getToken(1);
            hintToken(star);
            var acct = scanner.getToken(20);
            hintToken(acct);
            var amnt = scanner.getToken(13);
            hintToken(amnt);
            var name = scanner.getToken(27);
            hintToken(name);
            var one = scanner.getToken(1);
            hintToken(one);
            var tail = scanner.getRemaining();
            hintToken(tail, MandatHint.Warning);

            if(!star.isStar())
                addErrorMsg(star, "'*' expected");
            if(!acct.isAccount())
                addErrorMsg(acct, "not a valid account");
            if(!amnt.isAmount())
                addErrorMsg(amnt, "not a valid amount");
            if(!name.isBenifName())
                addErrorMsg(name, "not a valid name");            
            if(!one.isOne())
                addErrorMsg(one, "'1' expected");
            if(!tail.isTailWhiteSpace())
                addErrorMsg(tail, "excessive text");
        }

        void addErrorMsg(Token token, string msg) {
            int dgts =  (int)Math.Ceiling(Math.Log10(scanner.getLineCount()));
            int idx = dataGridView1.Rows.Add($"{token.line+1}", $"{msg}");
            dataGridView1.Rows[idx].Tag = token;
            hintToken(token, MandatHint.Error);
        }

        //private void checkMandat()
        //{
        //    string[] lines = File.ReadAllLines(@"G:\tw_dev\ANEM0820.txt");
        //    string head = lines[0];
        //    checkHead(head);
        //    var benifs = lines.Skip(1);
        //    for(int i=1;i<lines.Length;i++)
        //        checkBenif(i, lines[i]);
        //    if(headerAmount != totalAmount)
        //    {
        //        error(string.Format("error in line '{0}' total amount: expected [{1}] found [{2}]", 0,
        //            toMoneyString(totalAmount), toMoneyString(headerAmount)));
        //        hintText(0, 21, 13, MandatHint.LightError);
        //    }
        //    if (headerCount != benifCount)
        //    {
        //        error(string.Format("error in line '{0}' benif count: expected [{1}] found [{2}]", 0, benifCount, headerCount));
        //        hintText(0, 34, 7, MandatHint.Error);
        //    }
        //}

        //private void checkHead(string head)
        //{
        //    string star = takeFromString(ref head, 1);
        //    hintText(0, 0, 1, MandatHint.LightNormal);
        //    if (star == null || star != "*")
        //    {
        //        error("error in header star");
        //        hintText(0, 0, 1, MandatHint.Error);
        //    }
        //    //
        //    string account = takeFromString(ref head, 20);
        //    hintText(0, 1, 20, MandatHint.Normal);
        //    if (!isDigitString(account))
        //    {
        //        error("error in header account");
        //        hintText(0, 1, 20, MandatHint.Error);
        //    }
        //    //
        //    string amount = takeFromString(ref head, 13);
        //    hintText(0, 21, 13, MandatHint.LightNormal);
        //    if (!isDigitString(amount))
        //    {
        //        error("error in header amount");
        //        hintText(0, 21, 13, MandatHint.Error);
        //    }
        //    else
        //        headerAmount = long.Parse(amount);
        //    //
        //    string benifCount = takeFromString(ref head, 7);
        //    hintText(0, 34, 7, MandatHint.Normal);
        //    if (!isDigitString(benifCount))
        //    {
        //        error("error in header benif count");
        //        hintText(0, 34, 7, MandatHint.Error);
        //    }
        //    else
        //        headerCount = int.Parse(benifCount);
        //    //
        //    string month = takeFromString(ref head, 2);
        //    hintText(0, 41, 2, MandatHint.LightNormal);
        //    if (!isDigitString(month) || int.Parse(month) > 12 || int.Parse(month) < 1)
        //    {
        //        error("error in header month");
        //        hintText(0, 41, 2, MandatHint.Error);
        //    }
        //    else
        //        headerMonth = int.Parse(month);
        //    //
        //    string year = takeFromString(ref head, 4);
        //    hintText(0, 43, 4, MandatHint.Normal);
        //    if (!isDigitString(year))
        //    {
        //        error("error in header year");
        //        hintText(0, 43, 4, MandatHint.Error);
        //    }
        //    else
        //        headerYear = int.Parse(year);
        //    //
        //    string ord = takeFromString(ref head, 8);
        //    hintText(0, 47, 8, MandatHint.LightNormal);
        //    if (!isDigitString(ord))
        //    {
        //        error("error in header ordonnateur");
        //        hintText(0, 47, 8, MandatHint.Error);
        //    }
        //    else
        //        headerOrd = tailZeros.Replace(ord, "");
        //    //
        //    string mandat = takeFromString(ref head, 6);
        //    hintText(0, 55, 6, MandatHint.Normal);
        //    if (!isDigitString(mandat))
        //    {
        //        error("error in header mandat");
        //        hintText(0, 55, 6, MandatHint.Error);
        //    }
        //    else
        //        headerMandat = int.Parse(mandat);
        //    //
        //    string headerZero = takeFromString(ref head, 1);
        //    hintText(0, 61, 1, MandatHint.LightNormal);
        //    if (headerZero == null || headerZero != "0")
        //    {
        //        error("error in header zero");
        //        hintText(0, 61, 1, MandatHint.Error);
        //    }
        //    if (head.Length > 0)
        //    {
        //        error("warning in header overflow");
        //        hintText(0, 62, head.Length, MandatHint.Warning);
        //    }
        //}

        //private void checkBenif(int linenum, string line)
        //{
        //    benifCount++;
        //    if (line == "")
        //    {
        //        error(string.Format("error in line '{0}' empty line", linenum));
        //        hintText(linenum, 0, 1, MandatHint.Warning);
        //    }

        //    string star = takeFromString(ref line, 1);
        //    hintText(linenum, 0, 1, MandatHint.LightNormal);
        //    if (star == null || star != "*")
        //    {
        //        error(string.Format("error in line '{0}' star",linenum));
        //        hintText(linenum, 0, 1, MandatHint.Error);
        //    }
        //    //
        //    string account = takeFromString(ref line, 20);
        //    hintText(linenum, 1, 20, MandatHint.Normal);
        //    if (!isDigitString(account))
        //    {
        //        error(string.Format("error in line '{0}' account", linenum));
        //        hintText(linenum, 1, 20, MandatHint.Error);
        //    }
        //    //
        //    string amount = takeFromString(ref line, 13);
        //    hintText(linenum, 21, 13, MandatHint.LightNormal);
        //    if (!isDigitString(amount))
        //    {
        //        error(string.Format("error in line '{0}' amount", linenum));
        //        hintText(linenum, 21, 13, MandatHint.Error);
        //    }
        //    else
        //        totalAmount += long.Parse(amount);

        //    string name = takeFromString(ref line, 27);
        //    hintText(linenum, 34, 27, MandatHint.Normal);
        //    if (!isName(name))
        //    {
        //        error(string.Format("error in line '{0}' name", linenum));
        //        hintText(linenum, 34, 27, MandatHint.Error);
        //    }
        //    //            
        //    string lineTail = takeFromString(ref line, 1);
        //    hintText(linenum, 61, 1, MandatHint.LightNormal);
        //    if (lineTail == null || lineTail != "1")
        //    {
        //        error(string.Format("error in line '{0}' zero", linenum));
        //        hintText(linenum, 61, 1, MandatHint.Error);
        //    }
        //    //
        //    if (line.Length > 0)
        //    {
        //        error(string.Format("error in line '{0}' overflow", linenum));
        //        hintText(linenum, 62, line.Length, MandatHint.Warning);
        //    }
        //    name = name.TrimEnd(' ');
        //    var pers = Person.FindByAccount(db, account);
        //    if (pers == null)
        //    {
        //        hintText(linenum, 1, 20, MandatHint.Error);
        //        hintText(linenum, 34, name.Length, MandatHint.Error);
        //    }
        //}

        private void checkBenifDB(string name, string account)
        {
            if(Person.Exists(db,name, account))
            {

            }
        }

        private string toMoneyString(decimal amount)
        {
            return (amount / 100).ToString("C", CultureInfo.GetCultureInfo("en-us")).Substring(1);
        }

        private void hintToken(Token token, MandatHint hint=MandatHint.Normal) {
            mandatTB.Select(mandatTB.GetFirstCharIndexFromLine(token.line) + 
                scanner.LineNumWidth + scanner.LineNumSep.Length + token.index, token.Length());
            int idx = (int)hint * 2 + token.position % 2;
            mandatTB.SelectionBackColor = colors[idx];
            mandatTB.SelectionColor = Color.Black;
            mandatTB.DeselectAll();
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDlg.Font = mandatTB.Font;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                mandatTB.Font = fontDlg.Font;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if(dataGridView1.SelectedRows.Count == 0)
                return;
            Token token = dataGridView1.SelectedRows[0].Tag as Token;
            if(token != null) {
                mandatTB.Focus();
                mandatTB.Select(mandatTB.GetFirstCharIndexFromLine(token.line) +
                    scanner.LineNumWidth + scanner.LineNumSep.Length + token.index, 
                    token.Length());
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e) {
            if(openFileDialog1.ShowDialog() == DialogResult.OK) {
                mandatTB.Enabled=false;
                loadFile(openFileDialog1.FileName);
                mandatTB.Enabled = true;
            }
        }
    }
}
