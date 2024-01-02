using MandatChecker.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public class OrdField : Field {
        public const int Length = 8;

        public override void Validate() {
            ValidateTextLength(Length, true);
        }
    }
}
