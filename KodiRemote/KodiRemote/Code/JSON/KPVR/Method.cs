using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPVR {
    public sealed class Method : StringEnum {
        public static readonly Method GetChannelDetails = new Method(801, "GetChannelDetails");
        public static readonly Method GetChannelGroupDetails = new Method(802, "GetChannelGroupDetails");
        public static readonly Method GetChannelGroups = new Method(803, "GetChannelGroups");
        public static readonly Method GetChannels = new Method(804, "GetChannels");
        public static readonly Method GetProperties = new Method(805, "GetProperties");
        public static readonly Method Record = new Method(806, "Record");
        public static readonly Method Scan = new Method(807, "Scan");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "PVR." + name;
        }
    }
}
