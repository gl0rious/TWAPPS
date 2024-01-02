using MandatChecker.Fields;
using TWOra;

namespace MandatChecker.UI {
    public interface MandatView {
        //void hintField(Field Field, MandatHint hint = MandatHint.Normal);
        void addErrorMsg( Field Field, string msg, string action = "" );

        void setHeaderAmount( double amount );
        void setHeaderLineCount( int count );
        void setHeaderOrd( string ord );
        void setHeaderMandatNum( int num );


        void addDataGridLine( int line, string star, string acct, string amnt, string name, string one );

        //int LineNumWidth { get; set; }
        //string LineNumSep { get; set; }
    }
}
