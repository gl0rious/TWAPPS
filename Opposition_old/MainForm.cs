using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Workspace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Opposition {
    public partial class MainForm : KryptonForm {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            KryptonPage page = new KryptonPage();

            page.Text = "title";
            page.TextTitle = "TextTitle";
            page.TextDescription = "TextDescription";
            //page.ImageSmall = MemoEditor.Properties.Resources.note16;
            //page.ImageMedium = MemoEditor.Properties.Resources.note24;
            //page.ImageLarge = MemoEditor.Properties.Resources.note32;

            ButtonSpecAny bsa = new ButtonSpecAny();
            bsa.Tag = page;
            bsa.Type = PaletteButtonSpecStyle.Close;
            bsa.Click += new EventHandler(OnClosePage);
            page.ButtonSpecs.Add(bsa);

            kryptonWorkspace1.ActiveCell.Pages.Add(page);
            kryptonWorkspace1.ActiveCell.SelectedPage = page;
        }

        private void OnClosePage(object sender, EventArgs e) {
            ButtonSpecAny bsa = (ButtonSpecAny)sender;
            var page = (KryptonPage)bsa.Tag;
            KryptonWorkspaceCell cell = kryptonWorkspace1.CellForPage(page);
            cell.Pages.Remove(page);
            page.Dispose();
        }
    }
}
