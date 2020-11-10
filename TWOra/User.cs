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
    public class User {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public UserState State { get; set; }
        public string LockDate { get; set; }
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
    }
}
