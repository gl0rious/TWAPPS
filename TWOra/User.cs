using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TWOra {
    public class User : IComparable {
        internal Database db;
        public int ID { get; internal set; }
        public string Username { get; internal set; }
        public string Fullname { get; internal set; }
        public bool Locked { get; internal set; }
        private List<Role> grantedRoles;
        private static List<User> users;       

        public List<Role> GetGrantedRoles() {
            if(grantedRoles != null)
                return grantedRoles;
            List<string> perms = new List<string>();
            var rd = db.execute($"select granted_role from dba_role_privs where grantee = '{Username}'");
            while(rd.Read())
                perms.Add(rd.GetString(0));
            grantedRoles = Role.AllValidRoles(db).Where(r => perms.Contains(r.Name)).ToList();
            return grantedRoles;
        }

        public void addRoleToUser(Role role) {
            db.execute($@"INSERT INTO ROLE_UTILISATEUR VALUES('{Username}', '{role.Name}')");
            db.execute($@"GRANT {role.Name} TO {Username}");
            if(!grantedRoles.Contains(role))
                grantedRoles.Add(role);
        }

        public void removeRoleFromUser(Role role) {
            db.execute($@"DELETE FROM ROLE_UTILISATEUR WHERE NOM_UTILIS = '{Username}' and ROLE_UTILIS = '{role.Name}'");
            db.execute($@"revoke {role.Name} from {Username}");
            if(grantedRoles.Contains(role))
                grantedRoles.Remove(role);
        }

        public void LockUser() {
            db.execute($"ALTER USER {Username} ACCOUNT LOCK");
            Locked = true;
        }

        public void UnlockUser() {
            db.execute($"ALTER USER {Username} ACCOUNT UNLOCK");
            Locked = false;
        }

        public static List<User> AllUsers(Database db) {
            if(users != null)
                return users;
            users = new List<User>();
            var rd = db.execute(@"
                SELECT
                  d.user_id,
                  d.USERNAME,
                  u.utilis,
                  d.ACCOUNT_STATUS
                FROM
                  utilisateur_app u
                JOIN dba_users d
                ON
                  u.nom_utilis = d.username
                where d.account_status in ('OPEN','LOCKED','LOCKED(TIMED)')
            ");
            while(rd.Read()) {
                int user_id = (int)(decimal)rd["user_id"];
                string username = (string)rd["username"];
                string fullname = ((string)rd["utilis"]).ToUpper();
                string state = (string)rd["ACCOUNT_STATUS"];
                users.Add(new User {
                    db = db,
                    ID = user_id,
                    Username = username,
                    Fullname = fullname,
                    Locked = state != "OPEN"
                });
            }
            return users;
        }
       
        public override bool Equals(object obj) {
            if(obj is User) {
                var other = obj as User;
                return Username.Equals(other.Username);
            }
            return base.Equals(obj);
        }

        public int CompareTo(object obj) {
            var other = obj as User;
            return Username.CompareTo(other.Username);
        }

        public override int GetHashCode() {
            return Username.GetHashCode();
        }

        public void ActivateAllRoles() {
            db.execute($"alter user {Username} default role all");
        }
    }
    //public static class Extensions {
    //    public static User FindByName(this List<User> users, string name) {
    //        return users.Find(u => u.Username == name);
    //    }
    //}
}

