using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAddons {
    public sealed class Method : StringEnum {
        public static readonly Method ExecuteAddon = new Method(401, "ExecuteAddon");
        public static readonly Method GetAddonDetails = new Method(402, "GetAddonDetails");
        public static readonly Method GetAddons = new Method(403, "GetAddons");
        public static readonly Method SetAddonEnabled = new Method(404, "SetAddonEnabled");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Addons." + name;
        }
    }
}
