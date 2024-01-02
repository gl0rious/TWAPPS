using MandatChecker.Fields;
using MandatChecker.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MandatChecker.Text {
    public static class Parser {
        public static Mandat parseHeader( Scanner scanner ) {
            var mandat = new Mandat();
            mandat.Star = scanner.getField<StarField>();
            mandat.Account = scanner.getField<AccountField>();
            mandat.Amount = scanner.getField<AmountField>();
            mandat.LineCount = scanner.getField<LineCountField>();
            mandat.Date = scanner.getField<DateField>();
            mandat.Ordonnateur = scanner.getField<OrdField>();
            mandat.Number = scanner.getField<MandatNumField>();
            mandat.Zero = scanner.getField<ZeroField>();
            mandat.Tail = scanner.getField<TailField>();
            return mandat;
            //if(!star.isStar())
            //    view.addErrorMsg(star, "star_expected");
            //if(!acct.isAccount())
            //    view.addErrorMsg(acct, "unvalid_account");
            //if(amnt.isAmount())
            //    view.setHeaderAmount(double.Parse(amnt.txt) / 100);                
            //else
            //    view.addErrorMsg(amnt, "not a valid amount");
            //if(bcnt.isBenifCount())
            //    view.setHeaderLineCount(int.Parse(bcnt.txt));
            //else
            //    view.addErrorMsg(bcnt, "not a benif count");
            //if(!mnth.isMonth())
            //    view.addErrorMsg(mnth, "not a valid month");
            //if(!year.isYear())
            //    view.addErrorMsg(year, "not a valid year");
            //if(!ordn.isOrd())
            //    view.addErrorMsg(ordn, "not a valid ordonateur");
            //else
            //    view.setHeaderOrd(ordn.txt);
            //if(mndt.isMandatNumber())
            //    view.setHeaderMandatNum(int.Parse(mndt.txt));
            //else
            //    view.addErrorMsg(mndt, "not a valid mandat number");
            //if(!zero.isZero())
            //    view.addErrorMsg(zero, "'0' expected");
            //if(!tail.isTailWhiteSpace())
            //    view.addErrorMsg(tail, "excessive text");
        }


        public static Person parsePerson( Scanner scanner ) {
            var person = new Person();
            person.Index = scanner.CurrentLine;
            person.Star = scanner.getField<StarField>();
            person.Account = scanner.getField<AccountField>();
            person.Amount = scanner.getField<AmountField>();
            person.Fullname = scanner.getField<FullnameField>();
            person.One = scanner.getField<OneField>();
            person.Tail = scanner.getField<TailField>();
            return person;
            //accounts.Add(acct);
            //var benif = new Person();

            //if(!star.isStar())
            //    view.addErrorMsg(star, "'*' expected");
            //if(!acct.isAccount())
            //    view.addErrorMsg(acct, "not a valid account");
            //if(!acct.IsValidAccount())
            //    view.addErrorMsg(acct, $"account key not valid, expected key [{acct.getAccountKey()}]");
            //else
            //benif.Account = acct.txt;
            //if(!amnt.isAmount())
            //    view.addErrorMsg(amnt, "not a valid amount");
            //if(!name.isBenifName())
            //    view.addErrorMsg(name, "not a valid name");
            //else
            //benif.Fullname = name.txt;
            //if(!one.isOne())
            //    view.addErrorMsg(one, "'1' expected");
            //if(!tail.isTailWhiteSpace())
            //    view.addErrorMsg(tail, "excessive text");
            //if(acct.IsValidAccount() && name.isBenifName())
            //Lines.Add(benif);

            //view.addDataGridLine(star.line, star.txt, acct.txt, amnt.txt, name.txt, one.txt);
            //dgUsers.Invoke(new Action(() =>{
            //usersGridView.Rows.Add(star.line, star.txt, acct.txt, amnt.txt, name.txt, one.txt);
            //}));
        }
    }
}
