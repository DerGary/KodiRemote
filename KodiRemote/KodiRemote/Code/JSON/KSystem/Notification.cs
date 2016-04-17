using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KSystem {
    public class Notification : StringEnum {
        public static readonly Notification OnLowBattery = new Notification(1, "OnLowBattery");
        public static readonly Notification OnQuit = new Notification(2, "OnQuit");
        public static readonly Notification OnRestart = new Notification(3, "OnRestart");
        public static readonly Notification OnSleep = new Notification(4, "OnSleep");
        public static readonly Notification OnWake = new Notification(5, "OnWake");

        private Notification(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "System." + name;
        }
    }

}
