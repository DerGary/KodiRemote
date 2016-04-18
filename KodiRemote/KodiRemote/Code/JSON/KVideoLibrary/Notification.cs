using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KVideoLibrary {
    public class Notification : StringEnum {
        public static readonly Notification OnCleanFinished = new Notification(1, "OnCleanFinished");
        public static readonly Notification OnCleanStarted = new Notification(2, "OnCleanStarted");
        public static readonly Notification OnRemove = new Notification(3, "OnRemove");
        public static readonly Notification OnScanFinished = new Notification(4, "OnScanFinished");
        public static readonly Notification OnScanStarted = new Notification(5, "OnScanStarted");
        public static readonly Notification OnUpdate = new Notification(6, "OnUpdate");

        private Notification(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "VideoLibrary." + name;
        }
    }

}
