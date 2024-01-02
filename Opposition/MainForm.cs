using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
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
            SetUpMenus();
            InsertNewPage();
            InsertNewPage();
            InsertNewPage();
        }

        private void SetUpMenus() {
            var menus = Opposition.Menu.Menu.getRootMenus();
            foreach(var menu in menus) {
                var item = new ToolStripMenuItem(menu.Name);
                mainMenu.Items.Add(item);
                foreach(var group in menu.Groups) {
                    if(item.DropDownItems.Count > 0)
                        item.DropDownItems.Add(new ToolStripSeparator());
                    foreach(var groupItem in group.Items) {
                        item.DropDownItems.Add(new ToolStripMenuItem(groupItem.Name));
                    }
                }
            }
        }

        private void InsertNewPage() {
            KryptonPage page = new KryptonPage();

            page.Text = "title "+ kryptonNavigator.Pages.Count;
            page.TextTitle = "TextTitle";
            page.TextDescription = "TextDescription";
            //page.ImageSmall = MemoEditor.Properties.Resources.note16;
            //page.ImageMedium = MemoEditor.Properties.Resources.note24;
            //page.ImageLarge = MemoEditor.Properties.Resources.note32;

            //ButtonSpecAny bsa = new ButtonSpecAny();
            //bsa.Tag = page;
            //bsa.Type = PaletteButtonSpecStyle.Close;
            //bsa.Click += new EventHandler(OnClosePage);
            //page.ButtonSpecs.Add(bsa);

            //kryptonNavigator.Pages.Insert(kryptonNavigator.Pages.Count - 1, page);
            kryptonNavigator.Pages.Add(page);
            kryptonNavigator.SelectedPage = page;
        }

        //private void OnClosePage(object sender, EventArgs e) {
        //    ButtonSpecAny bsa = (ButtonSpecAny)sender;
        //    var page = (KryptonPage)bsa.Tag;
        //    var cell = kryptonWorkspace.CellForPage(page);
        //    cell.Pages.Remove(page);
        //    page.Dispose();
        //}
    }
}
