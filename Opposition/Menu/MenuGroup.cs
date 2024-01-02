using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Opposition.Menu {
    public class MenuGroup {
        public string Name = string.Empty;
        public ICollection<MenuItem> Items = new List<MenuItem>();


        public MenuGroup AddMenuItem(string name, string icon = null) {
            Items.Add(new MenuItem { Name = name });
            return this;
        }
    }
}
