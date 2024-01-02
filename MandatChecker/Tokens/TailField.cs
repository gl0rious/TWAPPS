using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public class TailField : Field {
        public override void Validate() {
            if( !string.IsNullOrWhiteSpace(Text) )
                AddError("Text excessif doit etre supprime.");
        }
    }
}
