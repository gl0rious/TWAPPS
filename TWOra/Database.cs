using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWOra
{
    public class Database
    {
        OracleConnection connection;
        public string LastError;
        public string connectedUser;

        public bool Connect() {
            if(connection == null)
                connection = new OracleConnection();
            if(connection.State == System.Data.ConnectionState.Closed ||
                connection.State == System.Data.ConnectionState.Broken) {
                connection.ConnectionString = ConnectionSetting.OracleConnectionString;
                try {
                    connection.Open();
                }
                catch(Exception e) {
                    LastError = e.Message;
                    return false;
                }
            }
            connectedUser = ConnectionSetting.Username;
            return true;
        }

        public bool isDBA() {
            var reader = execute(@"SELECT Count(*) FROM USER_ROLE_PRIVS where granted_role = 'DBA'");
            reader.Read();
            int count = reader.GetInt32(0);
            return count > 0;
        }

        public List<User> GetUsersList() {
            var users = new List<User>();
            var rd = execute(@"
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
                    Username = username,
                    Fullname = fullname,
                    State = state
                });
            }
            return users;
        }


        public List<User> GetUsersList2() {
            List<User> users = new List<User>();
            var rd = execute(@"
                SELECT
                  d.USERNAME,
                  u.utilis fullname,
                  d.ACCOUNT_STATUS,
                  d.LOCK_DATE,
                  MAX(s.logon_time) lastlogin
                FROM
                  dba_users d,
                  utilisateur_app u,
                  v$session s
                WHERE
                  d.username   = u.nom_utilis
                AND d.username = s.username
                GROUP BY
                  d.USERNAME,
                  u.utilis,
                  d.ACCOUNT_STATUS,
                  d.LOCK_DATE
                ");
            while(rd.Read()) {
                string username = (string)rd["username"];
                string fullname = (string)rd["fullname"];
                UserState state = User.Statefrom((string)rd["ACCOUNT_STATUS"]);
                string date = rd["LOCK_DATE"].ToString();
                string lastlogin = rd["lastlogin"].ToString();
                users.Add(new User { Username=username,Fullname=fullname,State=state,
                    LockDate =date});
            }
            return users;
        }

        public List<Session> GetUserSessions(string _username=null) {
            var users = new List<Session>();
            var sql = $@"select sid, serial#, username, utilis, 
                                REGEXP_SUBSTR(machine,'[^\]+$') machine,
                        logon_time from v$session, utilisateur_app where username=nom_utilis";
            if(_username != null)
                sql += $" and username='{_username}'";
            var rd = execute(sql);
            while(rd.Read()) {
                int sid = (int)((decimal)rd["sid"]);
                int serial = (int)((decimal)rd["serial#"]);
                string username = (string)rd["username"];
                string fullname = (string)rd["utilis"];
                string machine = (string)rd["machine"];
                DateTime logon = (DateTime)rd["logon_time"];
                users.Add(new Session { SID=sid,Serial=serial,
                Username=username,Machine=machine,LogonTime=logon
                });
            }
            return users;
        }

        public string GetUserIP(string host) {
            try {
                host = Regex.Match(host, @"[^\\]+$").Value;
                return Dns.GetHostAddresses(host).First(ip => ip.GetAddressBytes().Length == 4).ToString();
            }
            catch {
                Debug.WriteLine($"Couldn't resolve host : \"{host}\"");
            }
            return "";
        }

        OracleDataReader execute(string sql) {
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteReader();
        }

        public List<string> GetAllRoles() {
            List<string> validRoles = new List<string>();
            var rd = execute(@"SELECT role FROM DBA_ROLES order by 1");
            while(rd.Read())
                validRoles.Add(rd.GetString(0));
            return validRoles;
        }

        public List<string> GetUserRoles(string user) {
            List<string> perms = new List<string>();
            var rd = execute($@"SELECT distinct upper(ROLE_UTILIS) FROM ROLE_UTILISATEUR
                                 WHERE(NOM_UTILIS='{user}')");
            while(rd.Read()) {
                perms.Add(rd.GetString(0));
                //Debug.WriteLine(rd.GetString(0));
            }
            return perms;
        }

        public void addRoleToUser(string user, string role) {
            execute($@"INSERT INTO ROLE_UTILISATEUR VALUES('{user}', '{role}')");
            execute($@"GRANT {role} TO {user}");
            Debug.WriteLine($"Added {role} to {user}");
        }

        public void removeRoleFromUser(string user, string role) {
            execute($@"DELETE FROM ROLE_UTILISATEUR WHERE NOM_UTILIS = '{user}' and ROLE_UTILIS = '{role}'");
            execute($@"revoke {role} from {user}");
            Debug.WriteLine($"Removed {role} from {user}");
        }
    }
}
