using MandatChecker.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MandatChecker.Fields {
    public abstract class Field {
        public int Line { get; set; }
        public int Column { get; set; }
        private string text;
        public string Text {
            get {
                return text;
            }
            set {
                text = value;
                Validate();
            }
        }

        public bool HasErrors {
            get {
                return Errors != null && Errors.Count > 0;
            }
        }

        public override string ToString() {
            return Text;
        }

        public static implicit operator string( Field Field ) => Field.Text;

        public int TextLength {
            get {
                return string.IsNullOrEmpty(Text) ? 0 : Text.Length;
            }
        }

        public abstract void Validate();

        protected bool ValidateTextLength( int length, bool isNumeric = false ) {
            if( Text == null )
                AddError("Text est Vide.");
            else if( Text.Length != length )
                AddError($"Text doit etre de longeur {length}.");
            else if( isNumeric && !Text.IsNumeric() )
                AddError($"Text contient des caracteres non numeriques.");
            return Errors == null || Errors.Count == 0;
        }

        protected void ValidateConstant( string constant ) {
            if( Text != constant )
                AddError($"valeur doit etre '{constant}'.");
        }

        public List<string> Errors { get; protected set; } = null;

        protected void AddError( string message ) {
            if( Errors == null )
                Errors = new List<string>();
            Errors.Add(message);
        }
    }
}
