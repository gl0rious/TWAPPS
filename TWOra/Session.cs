using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWOra {
    public class Session {
        internal Database db;
        public int SID { get; set; }
        public int Serial { get; set; }
        public string Username { get; set; }
        public string Machine { get; set; }
        public DateTime LogonTime { get; set; }

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
                int sid = (int)((decimal)rd["sid"]);
                int serial = (int)((decimal)rd["serial#"]);
                string username = (string)rd["username"];
                string machine = (string)rd["machine"];
                DateTime logon = (DateTime)rd["logon_time"];
                sessions.Add(new Session {
                    db = db,
                    SID = sid,
                    Serial = serial,
                    Username = username,
                    Machine = machine,
                    LogonTime = logon
                });
            }
            return sessions;
        }
    }
}
