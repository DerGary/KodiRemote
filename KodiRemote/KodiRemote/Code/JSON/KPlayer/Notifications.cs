using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KPlayer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlayer.Notifications {
    [DataContract]
    public class Data {
        [DataMember(Name = "player")]
        public Player Player { get; set; }
        [DataMember(Name = "item")]
        public Item Item { get; set; }
    }

    [DataContract]
    public class Player {
        [DataMember(Name = "playerid")]
        public int PlayerId { get; set; }
        [DataMember(Name = "speed")]
        public int Speed { get; set; }
    }

    [DataContract]
    public class PlayerSeek : Player {
        [DataMember(Name = "seekoffset")]
        public Time SeekOffset { get; set; }
        [DataMember(Name = "time")]
        public Time Time { get; set; }
    }
}
