using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlayer {
    public sealed class Method : StringEnum {
        public static readonly Method GetActivePlayers = new Method(1, "GetActivePlayers");
        public static readonly Method GetItem = new Method(2, "GetItem");
        public static readonly Method GetProperties = new Method(3, "GetProperties");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Player." + name;
        }
    }
}
