using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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

        private static List<string> dbRoles;
        public static List<string> GetAllDBRoles(Database db) {
            if(dbRoles != null)
                return dbRoles;
            dbRoles = new List<string>();
            var rd = db.execute(@"
                SELECT
                    ROLE
                FROM
                    DBA_ROLES
                WHERE
                    REGEXP_LIKE(ROLE, '^(DP|RC|CP|PF)_')
                    OR ROLE = 'EDIT_DIVERS'
                ORDER BY
                    1
            ");
            while(rd.Read())
                dbRoles.Add(rd.GetString(0));
            return dbRoles;
        }
        private static List<Role> appRoles;
        public static List<Role> GetAllAppRoles() {
            if(appRoles != null)
                return appRoles;
            appRoles = new List<Role>();
            var json = File.ReadAllText(Environment.CurrentDirectory + @"/AppRoles.json");
            JObject root = JObject.Parse(json);
            foreach(JProperty appSection in root.Properties()) {
                foreach(JProperty groupSection in appSection.Value) {
                    foreach(JProperty role in groupSection.Value) {
                        appRoles.Add(new Role {
                            AppName = appSection.Name,
                            GroupName = groupSection.Name,
                            Name = role.Name,
                            Title = (string)role.Value
                        });
                    }
                }
            }
            return appRoles;
        }
        private static List<Role> validRoles;
        public static List<Role> AllValidRoles(Database db) {
            if(validRoles != null)
                return validRoles;
            validRoles = new List<Role>();
            var dbRoles = GetAllDBRoles(db);
            var appRoles = GetAllAppRoles();
            appRoles.Where(r => dbRoles.Contains(r.Name))
                .ToList().ForEach(r => validRoles.Add(r));
            return validRoles;
        }

        public override string ToString() {
            return Name;
        }

        //public static List<User> GetAllUsersWithRole(Role role) {
        //    return User.AllUsers().Select(u => u.GetGrantedRoles().Contains(role));
        //}
    }
}
