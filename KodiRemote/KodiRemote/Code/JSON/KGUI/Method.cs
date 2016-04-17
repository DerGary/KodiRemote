using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KGUI {
    public sealed class Method : StringEnum {
        public static readonly Method ActivateWindow = new Method(301, "ActivateWindow");
        public static readonly Method GetProperties = new Method(302, "GetProperties");
        public static readonly Method SetFullscreen = new Method(303, "SetFullscreen");
        public static readonly Method ShowNotification = new Method(304, "ShowNotification");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "GUI." + name;
        }
    }
}
