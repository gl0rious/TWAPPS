using MandatChecker.Text;
using MandatChecker.Fields;
using MandatChecker.UI;
using System.Collections.Generic;
using System.IO;
using MandatChecker.Tokens;

namespace MandatChecker {
    public class Mandat {
        public StarField Star { get; set; }
        public AccountField Account { get; set; }
        public AmountField Amount { get; set; }
        public ComputedAmountField ComputedAmount { get; set; }
        public LineCountField LineCount { get; set; }
        public ComputedLineCountField ComputedLineCount { get; set; }
        public DateField Date { get; set; }
        public OrdField Ordonnateur { get; set; }
        public MandatNumField Number { get; set; }
        public ZeroField Zero { get; set; }
        public TailField Tail { get; set; }

        public List<Person> PersonList { get; set; } = new List<Person>();

        public static Mandat fromFile( string filePath ) {
            var lines = File.ReadAllLines(filePath);
            var scanner = new Scanner(lines);
            var mandat = Parser.parseHeader(scanner);
            decimal computedAmount = 0;
            while( scanner.nextLine() ) {
                var person = Parser.parsePerson(scanner);
                if( person != null ) {
                    mandat.PersonList.Add(person);
                    computedAmount += person.Amount.Value;
                }
            }
            mandat.ComputedAmount = new ComputedAmountField(computedAmount, computedAmount == mandat.Amount.Value);
            mandat.ComputedLineCount = new ComputedLineCountField(mandat.PersonList.Count,
                mandat.PersonList.Count == mandat.LineCount.Value);
            return mandat;
        }
    }
}
