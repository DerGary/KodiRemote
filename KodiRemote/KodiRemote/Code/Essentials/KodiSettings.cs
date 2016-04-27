using KodiRemote.Code.Common;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Essentials {
    [Table("Kodis")]
    public class KodiSettings : PropertyChangedBase {
        [PrimaryKey]
        public string Name { get; set; }
        public string Hostname { get; set; }
        public string Port { get; set; }
        public ConnectionType Type { get; set; }
        public bool Active { get; set; }

        public KodiSettings() { }
        public KodiSettings(string name, string hostname, string port, ConnectionType type, bool active) : this() {
            Name = name;
            Hostname = hostname;
            Port = port;
            Type = type;
            Active = active;
        }
    }
}
