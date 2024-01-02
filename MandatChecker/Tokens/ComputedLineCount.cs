using MandatChecker.Fields;
using MandatChecker.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandatChecker.Tokens {
    public class ComputedLineCountField : Field {
        public ComputedLineCountField( int value, bool isValid ) {
            Value = value;
            Text = Value.FormatCount();
            if( !isValid )
                Errors = new List<string> { "Nombre des lignes ne correspond pas a la valeur dans l'en-tete." };
        }
        public override string ToString() {
            return Value.FormatCount();
        }

        public override void Validate() {
        }

        public int Value { get; set; }
    }
}
