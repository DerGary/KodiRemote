using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class PVRChannelField : IField {
        public bool Thumbnail { get; set; }
        public bool Channeltype { get; set; }
        public bool Hidden { get; set; }
        public bool Locked { get; set; }
        public bool Channel { get; set; }
        public bool Lastplayed { get; set; }
        public void All() {
            Thumbnail = true;
            Channeltype = true;
            Hidden = true;
            Locked = true;
            Channel = true;
            Lastplayed = true;
        }
        public List<string> ToList() {
            List<string> list = new List<string>();
            if (Thumbnail)
                list.Add("thumbnail");
            if (Channeltype)
                list.Add("channeltype");
            if (Hidden)
                list.Add("hidden");
            if (Locked)
                list.Add("locked");
            if (Channel)
                list.Add("channel");
            if (Lastplayed)
                list.Add("lastplayed");
            return list;
        }
    }
}
