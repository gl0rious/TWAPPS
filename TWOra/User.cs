using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWOra {
    [Flags]
    public enum UserState {
        OPEN = 0,
        EXPIRED = 1,
        EXPIRED_GRACE = 2,
        LOCKED_TIMED = 4,
        LOCKED = 8
    }
    public class User : IComparable {
        internal Database db;
        public string Username { get; internal set; }
        public string Fullname { get; internal set; }
        public UserState State { get; internal set; }
        private List<Role> grantedRoles;
        private static List<User> users;
        //public string LockDate { get; internal set; }
        //public string LastLogin { get; set; }

        public static UserState Statefrom(string state) {
            var states = new Dictionary<string, int> {
                    { "OPEN", 0},
                    { "EXPIRED", 1},
                    { "EXPIRED(GRACE)", 2},
                    { "LOCKED(TIMED)", 4},
                    { "LOCKED", 8},
                    { "EXPIRED & LOCKED(TIMED)", 5},
                    { "EXPIRED(GRACE) & LOCKED(TIMED)", 6},
                    { "EXPIRED & LOCKED", 9},
                    { "EXPIRED(GRACE) & LOCKED",10}
            };
            return (UserState)states[state];
        }

        public List<Role> GetGrantedRoles() {
            if(grantedRoles == null) {
                List<string> perms = new List<string>();
                var rd = db.execute($"select granted_role from dba_role_privs where grantee = '{Username}'");
                while(rd.Read())
                    perms.Add(rd.GetString(0));
                grantedRoles = Role.GetAllTWRoles(db).Where(r => perms.Contains(r.Name)).ToList();
            }
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

        public static List<User> GetUsersList(Database db) {
            if(users != null)
                return users;
            users = new List<User>();
            var rd = db.execute(@"
                SELECT
                  d.USERNAME,
                  u.utilis,
                  d.ACCOUNT_STATUS
                FROM
                  utilisateur_app u
                JOIN dba_users d
                ON
                  u.nom_utilis = d.username
            ");
            while(rd.Read()) {
                string username = (string)rd["username"];
                string fullname = (string)rd["utilis"];
                UserState state = User.Statefrom((string)rd["ACCOUNT_STATUS"]);
                users.Add(new User {
                    db = db,
                    Username = username,
                    Fullname = fullname,
                    State = state
                });
            }
            return users;
        }

        public static User GetConnectedUser(Database db) {
            var connectedUsername = ConnectionSetting.Username;
            if(users != null)
                return users.Find(u => u.Username == connectedUsername);
            var rd = db.execute($@"
                SELECT
                  d.USERNAME,
                  u.utilis,
                  d.ACCOUNT_STATUS
                FROM
                  dba_users d
                LEFT JOIN utilisateur_app u
                ON
                  u.nom_utilis = d.username
                where d.username = '{connectedUsername.ToUpper()}'
            ");
            if(rd.Read()) {
                string username = rd["username"].ToString();
                string fullname = rd["utilis"].ToString();
                UserState state = User.Statefrom(rd["ACCOUNT_STATUS"].ToString());
                return new User {
                    db = db,
                    Username = username,
                    Fullname = fullname,
                    State = state
                };
            }
            return null;
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

        public bool isDBA() {
            var reader =db.execute(@"SELECT Count(*) FROM USER_ROLE_PRIVS where granted_role = 'DBA'");
            reader.Read();
            int count = reader.GetInt32(0);
            return count > 0;
        }
    }
    public static class Extensions {
        public static User FindByName(this List<User> users, string name) {
            return users.Find(u => u.Username == name);
        }
    }
}

