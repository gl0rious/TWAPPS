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
using System.Xml.Linq;

namespace TWOra
{
    public class Database
    {
        OracleConnection connection;
        public string LastError;
        public User connectedUser;

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
            connectedUser = User.GetConnectedUser(this);
            return true;
        }
        
        public List<Session> GetUserSessions() {
            var users = new List<Session>();
            var sql = $@"select sid, serial#, username, utilis, 
                                REGEXP_SUBSTR(machine,'[^\]+$') machine,
                        logon_time from v$session, utilisateur_app where username=nom_utilis";
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

        internal OracleDataReader execute(string sql) {
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.CommandType = CommandType.Text;
            return cmd.ExecuteReader();
        }                
    }
}
