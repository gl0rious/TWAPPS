using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace TWOra {
    public class Role {
        public string AppName { get; internal set; }
        public string GroupName { get; internal set; }
        public string Name { get; internal set; }
        public string Title { get; internal set; }

        public override bool Equals(object other) {
            if(other is Role) {
                var otherRole = other as Role;
                return Name.Equals(otherRole.Name);
            }
            return base.Equals(other);
        }
        public override int GetHashCode() {
            return Name.GetHashCode();
        }


        public static List<string> GetAllDBRoles(Database db) {
            List<string> validRoles = new List<string>();
            var rd = db.execute(@"SELECT role FROM DBA_ROLES order by 1");
            while(rd.Read())
                validRoles.Add(rd.GetString(0));
            return validRoles;
        }

        private static List<Role> validRoles;
        public static List<Role> GetAllTWRoles(Database db) {
            if(validRoles != null)
                return validRoles;
            var configRoles = XDocument.Parse(Properties.Resources.FormRoles);
            var dbRoles = GetAllDBRoles(db);
            validRoles = new List<Role>();
            foreach(var appSection in configRoles.Elements().Elements()) {
                var appName = appSection.Name.LocalName;
                foreach(var groupSection in appSection.Elements()) {
                    var groupName = groupSection.Name.LocalName;
                    groupSection.Elements().Where(e => dbRoles.Contains(e.Name.LocalName))
                        .ToList().ForEach(xe => validRoles.Add(
                            new Role { AppName=appName,GroupName=groupName,
                                Name =xe.Name.LocalName,Title=xe.Value}));
                }
            }
            return validRoles;
        }
    }
}
