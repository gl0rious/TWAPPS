﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandatChecker.Fields {
    public class OneField : Field {
        public const int Length = 1;
        public override void Validate() {
            ValidateConstant("1");
        }
    }
}
