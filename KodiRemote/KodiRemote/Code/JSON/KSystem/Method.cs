using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KSystem {
    public sealed class Method : StringEnum {
        public static readonly Method EjectOpticalDrive = new Method(1, "EjectOpticalDrive");
        public static readonly Method GetProperties = new Method(2, "GetProperties");
        public static readonly Method Hibernate = new Method(3, "Hibernate");
        public static readonly Method Reboot = new Method(4, "Reboot");
        public static readonly Method Shutdown = new Method(5, "Shutdown");
        public static readonly Method Suspend = new Method(6, "Suspend");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "System." + name;
        }
    }
}
