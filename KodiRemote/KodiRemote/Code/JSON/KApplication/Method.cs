using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KApplication {
    public sealed class Method : StringEnum {
        public static readonly Method GetProperties = new Method(201, "GetProperties");
        public static readonly Method Quit = new Method(202, "Quit");
        public static readonly Method SetMute = new Method(203, "SetMute");
        public static readonly Method SetVolume = new Method(204, "SetVolume");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Application." + name;
        }
    }
}
