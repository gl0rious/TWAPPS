using MandatChecker.Fields;
using MandatChecker.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandatChecker.Tokens {
    public class ComputedAmountField : Field {
        public ComputedAmountField( decimal value, bool isValid ) {
            Value = value;
            Text = Value.FormatMoney();
            if( !isValid )
                Errors = new List<string> { "Montant total des lignes ne correspond pas a la valeur dans l'en-tete." };
        }
        public override string ToString() {
            return Value.FormatMoney();
        }

        public override void Validate() {
        }

        public decimal Value { get; set; }
    }
}
