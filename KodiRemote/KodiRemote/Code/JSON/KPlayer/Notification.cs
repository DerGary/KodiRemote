using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlayer {
    public class Notification : StringEnum {
        public static readonly Notification OnPause = new Notification(1, "OnPause");
        public static readonly Notification OnPlay = new Notification(2, "OnPlay");
        public static readonly Notification OnPropertyChanged = new Notification(3, "OnPropertyChanged");
        public static readonly Notification OnSeek = new Notification(4, "OnSeek");
        public static readonly Notification OnSpeedChanged = new Notification(5, "OnSpeedChanged");
        public static readonly Notification OnStop = new Notification(6, "OnStop");

        private Notification(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Player." + name;
        }
    }

}
