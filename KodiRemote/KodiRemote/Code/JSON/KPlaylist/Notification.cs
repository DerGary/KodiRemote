using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlaylist {
    public class Notification : StringEnum {
        public static readonly Notification OnAdd = new Notification(1, "OnAdd");
        public static readonly Notification OnClear = new Notification(2, "OnClear");
        public static readonly Notification OnRemove = new Notification(3, "OnRemove");

        private Notification(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Playlist." + name;
        }
    }
}
