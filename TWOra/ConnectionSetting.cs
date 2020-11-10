using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TWOra {
    public static class ConnectionSetting {
        const string template = "Data Source=(DESCRIPTION="
                + "(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))"
                + "(CONNECT_DATA=(SERVICE_NAME={2})));"
                + "User Id={3};Password={4};";
        public static string OracleConnectionString {
            get {
                return string.Format(template, Host, Port, Service, Username, Password);
            }
        }
        public static string Host { get; private set; }
        public static string Port { get; private set; }
        public static string Service { get; private set; }
        public static string Username;
        public static string Password;

        public static bool LoadConfig() {
            Host = ConfigurationManager.AppSettings["Host"];
            if(Host == null)
                Host = "10.5.108.1";
            Port = ConfigurationManager.AppSettings["Port"];
            if(Port == null)
                Port = "1522";
            Service = ConfigurationManager.AppSettings["Service"];
            if(Service == null)
                Service = "SIT08001";
            Username = ConfigurationManager.AppSettings["Username"];
            Password = ConfigurationManager.AppSettings["Password"];

            return Host != null && Host != "" &&
                Port != null && Port != "" &&
                Service != null && Service != "" &&
                Username != null && Username != "" &&
                Password != null && Password != "";
        }
    }
}
