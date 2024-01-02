using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Data.Informix;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {
            string ConnectionString = "Host=" + HOST + "; " +
             "Service=" + SERVICENUM + "; " +
             "Server=" + SERVER + "; " +
             "Database=" + DATABASE + "; " +
             "User Id=" + USER + "; " +
             "Password=" + PASSWORD + "; ";
            //Can add other DB parameters here like DELIMIDENT, DB_LOCALE etc
            //Full list in Client SDK's .Net Provider Reference Guide p 3:13
            IfxConnection conn = new IfxConnection();
            conn.ConnectionString = ConnectionString;
            try {
                conn.Open();
                Console.WriteLine("Made connection!");
                Console.ReadLine();
            }
            catch(IfxException ex) {
                Console.WriteLine("Problem with connection attempt: "
                                  + ex.Message);
            }
        }
        static string HOST = "192.168.2.55";
        static string SERVICENUM = "9088";
        static string SERVER = "tresor";
        static string DATABASE = "pension08";
        static string USER = "pension";
        static string PASSWORD = "max";
        static void MakeConnection() {
            string ConnectionString = "Host=" + HOST + "; " +
             "Service=" + SERVICENUM + "; " +
             "Server=" + SERVER + "; " +
             "Database=" + DATABASE + "; " +
             "User Id=" + USER + "; " +
             "Password=" + PASSWORD + "; ";
            //Can add other DB parameters here like DELIMIDENT, DB_LOCALE etc
            //Full list in Client SDK's .Net Provider Reference Guide p 3:13
            IfxConnection conn = new IfxConnection();
            conn.ConnectionString = ConnectionString;
            try {
                conn.Open();
                Console.WriteLine("Made connection!");
                Console.ReadLine();
            }
            catch(IfxException ex) {
                Console.WriteLine("Problem with connection attempt: "
                                  + ex.Message);
            }
        }
    }
}
