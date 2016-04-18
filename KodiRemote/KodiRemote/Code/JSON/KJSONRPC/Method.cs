using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KJSONRPC {
    public sealed class Method : StringEnum {
        public static readonly Method GetConfiguration = new Method(701, "GetConfiguration");
        public static readonly Method Introspect = new Method(702, "Introspect");
        public static readonly Method NotifyAll = new Method(703, "NotifyAll");
        public static readonly Method Permission = new Method(704, "Permission");
        public static readonly Method Ping = new Method(705, "Ping");
        public static readonly Method Version = new Method(706, "Version");
        public static readonly Method SetConfiguration = new Method(707, "SetConfiguration");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "JSONRPC." + name;
        }
    }
}
