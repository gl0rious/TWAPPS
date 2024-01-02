using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public class FullnameField : Field {
        public const int Length = 27;
        public override void Validate() {
            ValidateTextLength(Length);
        }
    }
}
