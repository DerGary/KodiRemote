using KodiRemote.Code.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Essentials {
    public class KodiSettings : PropertyChangedBase {

        public string Hostname { get; private set; }
        public string Port { get; private set; }
        public ConnectionType Type { get; private set; }

        public KodiSettings(string hostname, string port, ConnectionType type) {
            Hostname = hostname;
            Port = port;
            Type = type;
        }
    }
}
