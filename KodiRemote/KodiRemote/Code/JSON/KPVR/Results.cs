using KodiRemote.Code.JSON.KFiles.Params;
using KodiRemote.Code.JSON.KJSONRPC.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPVR.Results {

    [DataContract]
    public class PVRProperties {
        [DataMember(Name = "available")]
        public bool Available { get; set; }
        [DataMember(Name = "recording")]
        public bool Recording { get; set; }
        [DataMember(Name = "scanning")]
        public bool Scanning { get; set; }
    }
    [DataContract]
    public class ChannelDetails {
        [DataMember(Name = "channeltype")]
        public string ChannelType { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "channel")]
        public string Channel { get; set; }
        [DataMember(Name = "hidden")]
        public bool Hidden { get; set; }
        [DataMember(Name = "channelid")]
        public int ChannelId { get; set; }
        [DataMember(Name = "locked")]
        public bool Locked { get; set; }
        [DataMember(Name = "lastplayed")]
        public string LastPlayed { get; set; }
    }
    [DataContract]
    public class ChannelGroup {
        [DataMember(Name = "channeltype")]
        public string ChannelType { get; set; }
        [DataMember(Name = "channelgroupid")]
        public int ChannelGroupId { get; set; }
    }
    [DataContract]
    public class ChannelGroupDetails {
        [DataMember(Name = "channelgroupid")]
        public int ChannelGroupId { get; set; }
        [DataMember(Name = "channels")]
        public List<ChannelDetails> Channels { get; set; }
    }
}