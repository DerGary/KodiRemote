using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlaylist {
    public sealed class Method : StringEnum {
        public static readonly Method Add = new Method(1101, "Add");
        public static readonly Method Clear = new Method(1102, "Clear");
        public static readonly Method GetItems = new Method(1103, "GetItems");
        public static readonly Method GetPlaylists = new Method(1104, "GetPlaylists");
        public static readonly Method GetProperties = new Method(1105, "GetProperties");
        public static readonly Method Insert = new Method(1106, "Insert");
        public static readonly Method Remove = new Method(1107, "Remove");
        public static readonly Method Swap = new Method(1108, "Swap");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Playlist." + name;
        }
    }
}
