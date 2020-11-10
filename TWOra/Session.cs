using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWOra {
    public class Session {
        public int SID { get; set; }
        public int Serial { get; set; }
        public string Username { get; set; }
        public string Machine { get; set; }
        public DateTime LogonTime { get; set; }
    }
}
