using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Opposition.Menu {
    public class Menu {

        public string Name;
        public ICollection<MenuGroup> Groups  = new List<MenuGroup>();

        public MenuGroup AddGroup(string name) {
            var group = new MenuGroup { Name = name };
            Groups.Add(group);
            return group;
        }

        public static ICollection<Menu> getRootMenus() {
            var entrees = new Menu { Name = "Entrees" };//("entrees", "Entrees");
            entrees.AddGroup("Redevables")
                .AddMenuItem("Redevables");
            entrees.AddGroup("Oppositions")
                .AddMenuItem("Oppositions")
                .AddMenuItem("ATD Expires")
                .AddMenuItem("Main Levees");
            entrees.AddGroup("Reglement")
                .AddMenuItem("Reglement")
                .AddMenuItem("Regularisation")
                .AddMenuItem("Contre Partie")
                .AddMenuItem("TP");
            var imprimer = new Menu { Name = "Impression" };
            imprimer.AddGroup("Solde")
                .AddMenuItem("TR6")
                .AddMenuItem("Ordre de Paiement")
                .AddMenuItem("Etat 43003")
                .AddMenuItem("Development de Solde");
            imprimer.AddGroup("ATD")
                .AddMenuItem("ATD")
                .AddMenuItem("ATD Expires")
                .AddMenuItem("ATD Recouvres")
                .AddMenuItem("ATD Annulees");

            var menus = new List<Menu> {
                entrees,
                imprimer
            };

            return menus;
        }
    }
}
