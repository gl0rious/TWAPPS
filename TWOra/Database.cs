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
        internal OracleConnection connection;
        public string LastError;

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
            return true;
        }

        public bool isDBASession() {
            var rd = execute($@"
                SELECT
                  count(*) count
                FROM
                  USER_ROLE_PRIVS
                WHERE granted_role = 'DBA'
            ");
            return rd.Read() && (decimal)rd["count"] > 0;
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
        ~Database() {
            if(connection != null)
                connection.Close();
        }         
    }
}
