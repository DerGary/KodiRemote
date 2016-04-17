using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KInput {
    public class Notification : StringEnum {
        public static readonly Notification OnInputFinished = new Notification(1, "OnInputFinished");
        public static readonly Notification OnInputRequested = new Notification(2, "OnInputRequested");

        private Notification(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Input." + name;
        }
    }
}
