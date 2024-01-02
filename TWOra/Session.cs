using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWOra {
    public class Session {
        internal Database db;
        public decimal? SID { get; set; }
        public decimal? Serial { get; set; }
        public decimal? BlockingSession { get; set; }
        public string Username { get; set; }
        public string Machine { get; set; }
        public DateTime? LogonTime { get; set; }

        public void Terminate() {
            var rd = db.execute($"ALTER SYSTEM DISCONNECT SESSION '{SID},{Serial}' IMMEDIATE");
        }

        public bool isOpen() {
            var sql = $@"
                SELECT
                  count(*)
                FROM
                  v$session
                WHERE
                  sid='{SID}'
                  and serial#='{Serial}'
            ";
            var rd = db.execute(sql);
            var count = rd.GetInt32(0);
            return count > 0;
        }

        public static List<Session> AllSessions(Database db) {
            var sessions = new List<Session>();
            var sql = $@"
                SELECT
                  sid,
                  serial#,
                  blocking_session,
                  username,
                  machine,
                  logon_time
                FROM
                  v$session
                  inner join utilisateur_app
                  on username=nom_utilis
                WHERE
                  status in ('ACTIVE','INACTIVE')
            ";
            var rd = db.execute(sql);
            while(rd.Read()) {
                decimal? sid = getNullableValue<decimal>(rd,"sid");
                decimal? serial = getNullableValue<decimal>(rd, "serial#");
                decimal? blockingSession = getNullableValue<decimal>(rd, "blocking_session");
                string username = getValue<string>(rd, "username");
                string machine = getValue<string>(rd, "machine");
                DateTime? logon = getNullableValue<DateTime>(rd, "logon_time");
                sessions.Add(new Session {
                    db = db,
                    SID = sid,
                    Serial = serial,
                    BlockingSession = blockingSession,
                    Username = username,
                    Machine = machine,
                    LogonTime = logon
                });
            }
            return sessions;
        }

        static T? getNullableValue<T>(OracleDataReader rd, string name) where T : struct {
            var value = rd[name];
            if(value is DBNull)
                return null;
            return (T)value;
        }
        static T getValue<T>(OracleDataReader rd, string name) where T : class {
            var value = rd[name];
            if(value is DBNull)
                return null;
            return (T)value;
        }
    }
}
