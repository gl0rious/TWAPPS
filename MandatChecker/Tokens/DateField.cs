using MandatChecker.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public class DateField : Field {
        public const int Length = 6;
        public override string ToString() {
            return HasErrors ? base.ToString() : $"{Text.Substring(0, 2)}/{Text.Substring(2)}";
        }

        public override void Validate() {
            if( ValidateTextLength(Length, true) ) {
                var month = int.Parse(Text.Substring(0, 2));
                var year = int.Parse(Text.Substring(2));
                if( month < 1 || month > 12 )
                    AddError("Mois doit etre comprise entre 1 et 12.");
                if( year < 2000 || year > 2099 )
                    AddError("Annee doit etre comprise entre 2000 et 2099.");
            }
        }
    }
}
