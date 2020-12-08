using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker {
    //enum TokenType {
    //    STAR,
    //    ZERO,
    //    ONE,
    //    NUMBER,
    //    MONTH,
    //    YEAR,
    //    ACCOUNT,
    //    AMOUNT,
    //    NAME,

    //}
    class Token {
        public int line;
        public int index;
        public string txt;
        public int position;

        static Regex numberRule = new Regex(@"^\d+$");
        static Regex nameRule = new Regex(@"^[A-Z' \/\-\.]+$");
        static Regex tailRule = new Regex(@"^[ \t]*$");
        public bool isStar() {
            return txt == "*";
        }
        public bool isAccount() {
            return txt != null && txt.Length==20 && numberRule.IsMatch(txt); ;
        }
        public bool isAmount() {
            return txt != null && txt.Length == 13 && numberRule.IsMatch(txt); ;
        }
        public bool isBenifCount() {
            return txt != null && txt.Length == 7 && numberRule.IsMatch(txt); ;
        }
        public bool isMonth() {
            return txt != null && txt.Length == 2 && numberRule.IsMatch(txt)
                && int.Parse(txt) >= 1 && int.Parse(txt) <=12;
        }
        public bool isYear() {
            return txt != null && txt.Length == 4 && numberRule.IsMatch(txt)
                 && int.Parse(txt) >= 2000 && int.Parse(txt) <= 2099;
        }
        public bool isOrd() {
            return txt != null && txt.Length == 8 && numberRule.IsMatch(txt);
        }
        public bool isMandatNumber() {
            return txt != null && txt.Length == 6 && numberRule.IsMatch(txt);
        }
        public bool isZero() {
            return txt == "0";
        }
        public bool isBenifName() {
            return txt != null && txt.Length == 27 && nameRule.IsMatch(txt);
        }
        public override string ToString() {
            return txt;
        }
        public bool isOne() {
            return txt == "1";
        }
        public bool isTailWhiteSpace() {
            return txt == null || txt.Length == 0 || tailRule.IsMatch(txt);
        }

        public int Length() {
            return txt == null ? 0 : txt.Length;
        }
    }
    class Scanner {
        string[] lines;
        public int CurrentLine { get; private set; }
        public int CurrentColumn { get; private set; }
        public int LineNumWidth { get; private set; }
        public string LineNumSep { get; private set; }
        int rank;

        public Scanner(string path) {
            lines = File.ReadAllLines(path);
            LineNumWidth = (int)Math.Ceiling(Math.Log10(lines.Length));
            LineNumSep = "| ";
            CurrentLine = 0;
            CurrentColumn = 0;
            rank = 0;
        }
        
        public string getPrintableText() {
            var txt = "";
            int i = 0;
            foreach(var line in lines) {
                i++;
                txt += $"{i}".PadLeft(LineNumWidth)+LineNumSep+$"{line.Replace('\t',' ')}\n";
            }
            return txt;
        }

        public Token getToken(int length) {
            var line = lines[CurrentLine];
            Token tk;
            string txt;
            if(CurrentColumn + length > line.Length) 
                txt = line.Substring(CurrentColumn);
            else 
                txt = line.Substring(CurrentColumn, length);
            rank++;
            tk = new Token { line = CurrentLine, index = CurrentColumn, txt = txt, position=rank};
            CurrentColumn += txt.Length;
            return tk;
        }
        public Token getRemaining() {
            var line = lines[CurrentLine];
            Token tk;
            string txt = line.Substring(CurrentColumn);            
            tk = new Token { line = CurrentLine, index = CurrentColumn, txt = txt };
            CurrentColumn += txt.Length;
            return tk;
        }

        public bool nextLine() {
            rank = 0;
            CurrentColumn = 0;
            CurrentLine = CurrentLine < lines.Length ? CurrentLine + 1 : CurrentLine;
            return CurrentLine < lines.Length;
        }

        public int getLineCount() {
            return lines.Length;
        }
    }
}
