using MandatChecker.Fields;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MandatChecker.UI {
    class InfoField : TextBox {
        private Field field;
        public Field Field {
            get {
                return field;
            }
            set {
                field = value;
                Text = field != null ? field.ToString() : "";
                BackColor = field != null && !field.HasErrors ? themeValidBackgroundColor : themeInvalidBackgroundColor;
                ForeColor = field != null && !field.HasErrors ? themeValidForeColor : themeInvalidForeColor;
            }
        }

        static Color themeValidBackgroundColor = Color.LimeGreen;
        static Color themeInvalidBackgroundColor = Color.Tomato;
        static Color themeValidForeColor = SystemColors.ControlText;
        static Color themeInvalidForeColor = Color.White;

        public InfoField() {
            BackColor = themeValidBackgroundColor;
            ForeColor = themeValidForeColor;
            BorderStyle = BorderStyle.None;
            ReadOnly = true;
        }

        protected override void OnEnter( EventArgs e ) {
            base.OnEnter(e);
            //BackColor = SystemColors.Highlight;
            //ForeColor = SystemColors.HighlightText;
            SelectAll();
        }

        protected override void OnLeave( EventArgs e ) {
            base.OnLeave(e);
            BackColor = field != null && !field.HasErrors ? themeValidBackgroundColor : themeInvalidBackgroundColor;
            ForeColor = field != null && !field.HasErrors ? themeValidForeColor : themeInvalidForeColor;
        }
        protected override void OnClick( EventArgs e ) {
            base.OnClick(e);
            SelectAll();
        }
    }
}
