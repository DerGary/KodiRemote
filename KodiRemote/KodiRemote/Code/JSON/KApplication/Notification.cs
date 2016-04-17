using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KApplication {
    public class Notification : StringEnum {
        public static readonly Notification OnVolumeChanged = new Notification(1, "OnVolumeChanged");

        private Notification(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Application." + name;
        }
    }
}
