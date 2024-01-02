using MandatChecker.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public class AccountField : Field {
        public const int Length = 20;

        private string getCCPKey( string compte ) {
            //var compte = Text.Substring(8, 10);
            int sum = 0;
            int coef = 4;
            for( int i = compte.Length - 1; i >= 0; i-- ) {
                var d = compte[i];
                sum += int.Parse(d.ToString()) * coef;
                coef++;
            }
            int key = sum % 100;
            return key.ToString("D2");
        }

        private string getRIPKey( string compte ) {
            //var compte = Text.Substring(3, 15);
            long value = long.Parse(compte);
            //long key = 97 - (value % 97 * 3) % 97;
            long key = 97 - (value * 100) % 97;
            return key.ToString("D2");
        }

        public override string ToString() {
            return Text.PadRight(20);
        }

        public override void Validate() {
            if( ValidateTextLength(Length, true) ) {
                var codeBank = Text.Substring(0, 3);
                var agence = Text.Substring(3, 5);
                var account = Text.Substring(8, 10);
                var embededkey = Text.Substring(18, 2);
                var computedKey = codeBank == "000" ? getCCPKey(account) : getRIPKey(agence + account);
                if( computedKey != embededkey ) {
                    var message = $"Cle '{embededkey}' est uncorrect ";
                    switch( codeBank ) {
                        case "000":
                            var cleCCP = computedKey;
                            var cleRIP = getRIPKey("99999" + account);
                            message += $"[ CLE CCP '{cleCCP}', CLE RIP '{cleRIP}'].";
                            break;
                        case "007":
                            cleCCP = getCCPKey(account);
                            cleRIP = computedKey;
                            message += $"[ CLE CCP '{cleCCP}', CLE RIP '{cleRIP}'].";
                            break;
                        default:
                            message += $"[ CLE RIB '{computedKey}' ].";
                            break;
                    }
                    AddError(message);
                }
            }
        }
    }
}
