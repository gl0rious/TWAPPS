using MandatChecker.Fields;
using System;
using System.Collections.Generic;

namespace MandatChecker.Text {
    public class Scanner {
        string[] lines;
        public int CurrentLine { get; private set; }
        public int CurrentColumn { get; private set; }
        //int rank;
        string currentLineText;

        Dictionary<Type, int> FieldLengths = new Dictionary<Type, int> {
            { typeof(AccountField), AccountField.Length },
            { typeof(AmountField), AmountField.Length },
            { typeof(DateField), DateField.Length },
            { typeof(FullnameField), FullnameField.Length },
            { typeof(LineCountField), LineCountField.Length },
            { typeof(MandatNumField), MandatNumField.Length },
            { typeof(OneField), OneField.Length },
            { typeof(OrdField), OrdField.Length },
            { typeof(StarField), StarField.Length },
            { typeof(TailField), int.MaxValue },
            { typeof(ZeroField), ZeroField.Length }
        };

        public Scanner(string[] lines) {
            this.lines = lines;
            CurrentLine = 0;
            CurrentColumn = 0;
            //rank = 0;
            currentLineText = lines[CurrentLine];
        }


        public AccountField getAccount() {
            var Field = new AccountField();
            fillFieldInfo(Field, AccountField.Length);
            return Field;
        }
        public void fillFieldInfo(Field Field, int length) {
            if(CurrentColumn + length > currentLineText.Length)
                Field.Text = currentLineText.Substring(CurrentColumn);
            else
                Field.Text = currentLineText.Substring(CurrentColumn, length);
            //rank++;
            Field.Line = CurrentLine;
            Field.Column = CurrentColumn;
            //position = rank;
            CurrentColumn += Field.Text.Length;
        }
        public T getField<T>() where T: Field, new() {
        T tk = new T();
            int length = FieldLengths[typeof(T)];
            length = Math.Min(length, currentLineText.Length - CurrentColumn);
            tk.Text = currentLineText.Substring(CurrentColumn, length);
            //rank++;
            tk.Line = CurrentLine;
            tk.Column = CurrentColumn;
            //position = rank;
            CurrentColumn += tk.Text.Length;
            return tk;
        }

    //public Field getRemaining() {
    //        var line = lines[CurrentLine];
    //        string txt = line.Substring(CurrentColumn);
    //        Field tk = new Field { Line = CurrentLine, Column = CurrentColumn, Text = txt };
    //        CurrentColumn += txt.Length;
    //        return tk;
    //    }

        public bool nextLine() {
            //rank = 0;
            CurrentColumn = 0;
            CurrentLine = CurrentLine < lines.Length ? CurrentLine + 1 : CurrentLine;
            currentLineText = CurrentLine < lines.Length ? lines[CurrentLine] : null;
            return CurrentLine < lines.Length;
        }

        public int getLineCount() {
            return lines.Length;
        }
    }
}
