//using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWOra {
    public class Person {
        internal Database db;
        public int ID { get; internal set; }
        public string Fullname { get; set; }
        public string Account { get; set; }
        public string SSN { get; set; }
        public string Ord { get; set; }
        public string Address { get; set; }

        //public static bool Exists(Database db,string name, string account) {
        //    var rd = db.execute($@"SELECT count(*) FROM personne
        //                         WHERE nom='{name}' and num_compte='{account}'");
        //    return rd.Read() && rd.GetInt32(0) >= 1;
        //}
        //public static Person FindByAccount(Database db,string account) {
        //    var pers = db.connection.QueryFirstOrDefault<Person>($@"
        //        select 
        //            code_pers ID,
        //            nom Fullname,
        //            NUM_COMPTE Account,
        //            IDT_FISCAL SSN,
        //            CODE_ORD Ord,
        //            ADR Address 
        //        from personne where NUM_COMPTE='{account}'");

        //    return pers;
        //}
    }
}
