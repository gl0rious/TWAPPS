using PoorMansTSqlFormatterLib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TWOra;

namespace SQLTracker {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            //ConnectForm dialog = new ConnectForm();
            //if(dialog.ShowDialog() == DialogResult.OK)
            //    this.Text = string.Format($"TW Admin [{ConnectionSetting.Username}]");
            //else {
            //    this.Close();
            //    return;
            //}
            //Database db = dialog.Database;
            //if(!db.isDBASession()) {
            //    MessageBox.Show($"'{ConnectionSetting.Username}' is not BDA");
            //    this.Close();
            //    return;
            //}


            ISqlTokenizer _tokenizer;
            ISqlTokenParser _parser;
            ISqlTreeFormatter _formatter;
            ISqlTreeFormatter innerFormatter;

            _tokenizer = new PoorMansTSqlFormatterLib.Tokenizers.TSqlStandardTokenizer();
            _parser = new PoorMansTSqlFormatterLib.Parsers.TSqlStandardParser();
            //innerFormatter = new PoorMansTSqlFormatterLib.Formatters.TSqlIdentityFormatter(true);

            innerFormatter = new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatter(new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatterOptions {
                IndentString = "\t",
            SpacesPerTab = 4,
            MaxLineWidth = 999,
            ExpandCommaLists = true,
            TrailingCommas = false,
            SpaceAfterExpandedComma = false,
            ExpandBooleanExpressions = true,
            ExpandBetweenConditions = true,
            ExpandCaseStatements = true,
            UppercaseKeywords = true,
            BreakJoinOnSections = false,
            HTMLColoring = true,
            KeywordStandardization = true,
            ExpandInLists = true,
            NewClauseLineBreaks = 1,
            NewStatementLineBreaks = 2,
    });

            _formatter = new PoorMansTSqlFormatterLib.Formatters.HtmlPageWrapper(innerFormatter);

            var sql = _tokenizer.TokenizeSQL(@"SELECT M.CODE_ORD,
  TO_CHAR(M.DT_EMISSION, 'MM'),
  A.code_CHAPITRE,
  SUM(A.MT_OPER)
FROM MANDAT M,
  MANDAT_CHAPITRE A
WHERE M.TYPE_SERVICE = 'BF'
  AND M.SI_DISPO = 1
  AND M.NUM_MANDAT = A.NUM_MANDAT
  AND M.GESTION = '2021'
GROUP BY M.CODE_ORD,
  TO_CHAR(M.DT_EMISSION, 'MM'),
  M.GESTION,
  A.code_CHAPITRE
ORDER BY 1,
  2,
  3,
  4; ");
            var sql2 = _parser.ParseSQL(sql);
            webBrowser1.DocumentText = _formatter.FormatSQLTree(sql2);
        }
    }
}
