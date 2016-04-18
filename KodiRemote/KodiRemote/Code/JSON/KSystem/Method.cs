using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KSystem {
    public sealed class Method : StringEnum {
        public static readonly Method EjectOpticalDrive = new Method(601, "EjectOpticalDrive");
        public static readonly Method GetProperties = new Method(602, "GetProperties");
        public static readonly Method Hibernate = new Method(603, "Hibernate");
        public static readonly Method Reboot = new Method(604, "Reboot");
        public static readonly Method Shutdown = new Method(605, "Shutdown");
        public static readonly Method Suspend = new Method(606, "Suspend");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "System." + name;
        }
    }
}
