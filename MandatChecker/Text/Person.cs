using MandatChecker.Fields;
using MandatChecker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandatChecker.Text {
    public class Person {
        public int Index { get; set; }
        public StarField Star { get; set; }
        public AccountField Account { get; set; }
        public AmountField Amount { get; set; }
        public FullnameField Fullname { get; set; }
        public OneField One { get; set; }
        public TailField Tail { get; set; }

        public bool HasErrors {
            get {
                return Star.HasErrors || Account.HasErrors || Amount.HasErrors ||
                    Fullname.HasErrors || One.HasErrors || Tail.HasErrors;
            }
        }
    }
}
