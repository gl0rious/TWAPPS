using MandatChecker.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public class AmountField : Field {
        public const int Length = 13;

        public override string ToString() {
            var text = HasErrors ? tryFormat(Text) : Value.FormatMoney();
            return text.PadLeft(17);
        }

        private string tryFormat( string text ) {
            //var stack = new Stack<char>(text);
            text = text.TrimStart('0');
            var prec = new string(text.Reverse().Take(2).ToArray());
            var remain = text.Reverse().Skip(2).ToArray();
            prec = prec.Length < 2 ? prec.PadRight(2, '0') : prec;
            var builder = new StringBuilder(prec);
            builder.Append('.');
            if( remain.Count() == 0 )
                builder.Append('0');
            while( remain.Count() > 0 ) {
                builder.Append(remain.Take(3).ToArray());
                remain = remain.Skip(3).ToArray();
                if( remain.Count() > 0 )
                    builder.Append(',');
            }
            return new string(builder.ToString().Reverse().ToArray());
        }

        public override void Validate() {
            ValidateTextLength(Length, true);
        }

        public decimal Value {
            get {
                return HasErrors ? 0 : decimal.Parse(Text) / 100;
            }
        }
    }
}
