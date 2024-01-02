using MandatChecker.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public class MandatNumField : Field {
        public const int Length = 6;
        public override string ToString() {
            return HasErrors ? base.ToString() : Value.FormatCount();
        }

        public override void Validate() {
            ValidateTextLength(Length, true);
        }
        public int Value {
            get {
                return HasErrors ? 0 : int.Parse(Text);
            }
        }
    }
}
