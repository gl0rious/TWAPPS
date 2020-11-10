using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandatChecker
{
    public partial class MainForm : Form
    {
        enum MandatHint
        {
            Normal,
            LightNormal,
            Error,
            LightError,
            Warning,
        }
        public MainForm()
        {
            InitializeComponent();
        }
        Regex digitsOnly = new Regex(@"[^\d]");
        Regex nameRule = new Regex(@"[^A-Z \/\-\.]");
        Regex tailZeros = new Regex(@"0*$");
        decimal headerAmount = 0;
        decimal totalAmount = 0;
        long benifCount = 0;
        long headerCount = 0;
        int headerMonth = 0;
        int headerYear = 0;
        string headerOrd;
        int headerMandat = 0;
        Color[] colors;
        //Font underlinedFont;
        const string cnx_string = "Data Source=(DESCRIPTION="
                + "(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))"
                + "(CONNECT_DATA=(SERVICE_NAME={2})));"
                + "User Id={3};Password={4};";
        OracleConnection cnx = new OracleConnection();
        OracleDataReader execute(string sql)
        {
            OracleCommand cmd = new OracleCommand(sql, cnx);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteReader();
        }

        public bool isUserExists(string name, string account)
        {
            var rd = execute($@"SELECT count(*) FROM personne
                                 WHERE nom='{name}' and num_compte='{account}'");
            if (rd.Read() && rd.GetInt32(0) >= 1)
                return true;
            return false;
        }

        public List<Tuple<string, string>> findSimilairUsers(string name, string account)
        {
            List<Tuple<string, string>> users = new List<Tuple<string, string>>();
            var rd = execute($@"SELECT nom,num_compte FROM personne WHERE nom='{name}' or num_compte='{account}'");
            while (rd.Read())
                users.Add(new Tuple<string, string>(rd.GetString(0), rd.GetString(1)));
            return users;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cnx.ConnectionString = string.Format(cnx_string, "192.168.2.33", "1521",
                "SIT08001", "tw08", "pproot08");
            try
            {
                cnx.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            //underlinedFont = new Font(mandatTB.Font, FontStyle.Underline);
            ColorConverter cc = new ColorConverter();
            colors = new Color[]{
                ColorTranslator.FromHtml("#b0c984"),
                ColorTranslator.FromHtml("#DFF2BF"),
                ColorTranslator.FromHtml("#ee0000"),
                ColorTranslator.FromHtml("#ee0000"),
                ColorTranslator.FromHtml("#FFBF00"),
            };
            var text = File.ReadAllText(@"G:\tw_dev\ANEM0820.txt");
            mandatTB.Text = text.Replace('\t',' ');
            checkMandat();
        }

        private void checkMandat()
        {
            string[] lines = File.ReadAllLines(@"G:\tw_dev\ANEM0820.txt");
            string head = lines[0];
            checkHead(head);
            var benifs = lines.Skip(1);
            for(int i=1;i<lines.Length;i++)
                checkBenif(i, lines[i]);
            if(headerAmount != totalAmount)
            {
                error(string.Format("error in line '{0}' total amount: expected [{1}] found [{2}]", 0,
                    toMoneyString(totalAmount), toMoneyString(headerAmount)));
                hintText(0, 21, 13, MandatHint.LightError);
            }
            if (headerCount != benifCount)
            {
                error(string.Format("error in line '{0}' benif count: expected [{1}] found [{2}]", 0, benifCount, headerCount));
                hintText(0, 34, 7, MandatHint.Error);
            }
        }

        private void checkHead(string head)
        {
            string star = takeFromString(ref head, 1);
            hintText(0, 0, 1, MandatHint.LightNormal);
            if (star == null || star != "*")
            {
                error("error in header star");
                hintText(0, 0, 1, MandatHint.Error);
            }
            //
            string account = takeFromString(ref head, 20);
            hintText(0, 1, 20, MandatHint.Normal);
            if (!isDigitString(account))
            {
                error("error in header account");
                hintText(0, 1, 20, MandatHint.Error);
            }
            //
            string amount = takeFromString(ref head, 13);
            hintText(0, 21, 13, MandatHint.LightNormal);
            if (!isDigitString(amount))
            {
                error("error in header amount");
                hintText(0, 21, 13, MandatHint.Error);
            }
            else
                headerAmount = long.Parse(amount);
            //
            string benifCount = takeFromString(ref head, 7);
            hintText(0, 34, 7, MandatHint.Normal);
            if (!isDigitString(benifCount))
            {
                error("error in header benif count");
                hintText(0, 34, 7, MandatHint.Error);
            }
            else
                headerCount = int.Parse(benifCount);
            //
            string month = takeFromString(ref head, 2);
            hintText(0, 41, 2, MandatHint.LightNormal);
            if (!isDigitString(month) || int.Parse(month) > 12 || int.Parse(month) < 1)
            {
                error("error in header month");
                hintText(0, 41, 2, MandatHint.Error);
            }
            else
                headerMonth = int.Parse(month);
            //
            string year = takeFromString(ref head, 4);
            hintText(0, 43, 4, MandatHint.Normal);
            if (!isDigitString(year))
            {
                error("error in header year");
                hintText(0, 43, 4, MandatHint.Error);
            }
            else
                headerYear = int.Parse(year);
            //
            string ord = takeFromString(ref head, 8);
            hintText(0, 47, 8, MandatHint.LightNormal);
            if (!isDigitString(ord))
            {
                error("error in header ordonnateur");
                hintText(0, 47, 8, MandatHint.Error);
            }
            else
                headerOrd = tailZeros.Replace(ord, "");
            //
            string mandat = takeFromString(ref head, 6);
            hintText(0, 55, 6, MandatHint.Normal);
            if (!isDigitString(mandat))
            {
                error("error in header mandat");
                hintText(0, 55, 6, MandatHint.Error);
            }
            else
                headerMandat = int.Parse(mandat);
            //
            string headerZero = takeFromString(ref head, 1);
            hintText(0, 61, 1, MandatHint.LightNormal);
            if (headerZero == null || headerZero != "0")
            {
                error("error in header zero");
                hintText(0, 61, 1, MandatHint.Error);
            }
            if (head.Length > 0)
            {
                error("warning in header overflow");
                hintText(0, 62, head.Length, MandatHint.Warning);
            }
        }

        private void checkBenif(int linenum, string line)
        {
            benifCount++;
            if (line == "")
            {
                error(string.Format("error in line '{0}' empty line", linenum));
                hintText(linenum, 0, 1, MandatHint.Warning);
            }

            string star = takeFromString(ref line, 1);
            hintText(linenum, 0, 1, MandatHint.LightNormal);
            if (star == null || star != "*")
            {
                error(string.Format("error in line '{0}' star",linenum));
                hintText(linenum, 0, 1, MandatHint.Error);
            }
            //
            string account = takeFromString(ref line, 20);
            hintText(linenum, 1, 20, MandatHint.Normal);
            if (!isDigitString(account))
            {
                error(string.Format("error in line '{0}' account", linenum));
                hintText(linenum, 1, 20, MandatHint.Error);
            }
            //
            string amount = takeFromString(ref line, 13);
            hintText(linenum, 21, 13, MandatHint.LightNormal);
            if (!isDigitString(amount))
            {
                error(string.Format("error in line '{0}' amount", linenum));
                hintText(linenum, 21, 13, MandatHint.Error);
            }
            else
                totalAmount += long.Parse(amount);

            string name = takeFromString(ref line, 27);
            hintText(linenum, 34, 27, MandatHint.Normal);
            if (!isName(name))
            {
                error(string.Format("error in line '{0}' name", linenum));
                //hintText(linenum, 34, 27, MandatHint.Error);
            }
            //            
            string lineTail = takeFromString(ref line, 1);
            hintText(linenum, 61, 1, MandatHint.LightNormal);
            if (lineTail == null || lineTail != "1")
            {
                error(string.Format("error in line '{0}' zero", linenum));
                hintText(linenum, 61, 1, MandatHint.Error);
            }
            //
            if (line.Length > 0)
            {
                error(string.Format("error in line '{0}' overflow", linenum));
                hintText(linenum, 62, line.Length, MandatHint.Warning);
            }
            name = name.TrimEnd(' ');
            if (!isUserExists(name, account))
            {

                hintText(linenum, 1, 20, MandatHint.Error);
                hintText(linenum, 34, name.Length, MandatHint.Error);
            }
        }

        private void checkBenifDB(string name, string account)
        {
            if(isUserExists(name, account))
            {

            }
        }

        private string toMoneyString(decimal amount)
        {
            return (amount / 100).ToString("C", CultureInfo.GetCultureInfo("en-us")).Substring(1);
        }

        private bool isDigitString(string text)
        {
            return text != null && !digitsOnly.IsMatch(text);
        }

        private bool isName(string text)
        {
            return text != null && !nameRule.IsMatch(text);
        }

        private void error(string msg)
        {
            Debug.WriteLine(msg);
        }

        private string takeFromString(ref string text, int count)
        {
            if (text.Length < count)
                return null;
            string token = text.Substring(0, count);
            text = text.Substring(count, text.Length - count);
            return token;
        }

        private void hintText(int line, int index, int length, MandatHint hint)
        {
            mandatTB.Select(mandatTB.GetFirstCharIndexFromLine(line) + index, length);
            mandatTB.SelectionBackColor = colors[(int)hint];
            //if (colors[(int)hint].GetBrightness() < 0.5)
            //    mandatTB.SelectionColor = Color.White;
            //else
                mandatTB.SelectionColor = Color.Black;
            mandatTB.DeselectAll();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(cnx.State == ConnectionState.Open)
                cnx.Close();
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDlg.Font = mandatTB.Font;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                mandatTB.Font = fontDlg.Font;
            }
        }

        private void mandatTB_SelectionChanged(object sender, EventArgs e)
        {

            Debug.WriteLine(mandatTB.GetLineFromCharIndex(mandatTB.GetFirstCharIndexOfCurrentLine()).ToString());

        }
    }
}
