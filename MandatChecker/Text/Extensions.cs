using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Text {
    public static class Extensions {
        static Regex numericRule = new Regex(@"^\d+$");
        public static bool IsNumeric( this string text ) {
            return numericRule.IsMatch(text);
        }

        //public static Regex nameRule { get; } = new Regex(@"^[A-Z][A-Z0-9' \/\-\_\.°]*$");

        //public override string ToString() {
        //    decimal value;
        //    if( decimal.TryParse(Text, out value) ) {
        //        value /= 100;
        //        return value.ToString("N2", CultureInfo.InvariantCulture);
        //    }
        //    return base.ToString();
        //}
        public static string FormatMoney( this decimal value ) {
            return value.ToString("N2", CultureInfo.InvariantCulture);
        }

        public static string FormatCount( this int value ) {
            return value.ToString("N0", CultureInfo.InvariantCulture);
        }
    }
}
