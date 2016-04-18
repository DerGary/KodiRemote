using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using XBMCRemote.JSONRPCClasses;

namespace KodiRemote.Code.JSON.KPVR.Params {

    [DataContract]
    public class GetChannelDetails {
        [DataMember(Name = "channelid")]
        public int ChannelId { get; set; }
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
    }
    [DataContract]
    public class GetChannelGroupDetails {
        [DataMember(Name = "channelgroupid")]
        public int ChannelGroupId { get; set; }

        [DataMember(Name = "channels", EmitDefaultValue = false)]
        public Channels Channels { get; set; }

    }

    [DataContract]
    public class Channels {
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
    }
    [DataContract]
    public class GetChannelGroups {
        [DataMember(Name = "channeltype")]
        public int ChannelType { get; set; }
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
    }
    [DataContract]
    public class GetChannels {
        [DataMember(Name = "channelgroupid")]
        public int ChannelGroupId { get; set; }
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
    }
    [DataContract]
    public class GetProperties {
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
    }
    [DataContract]
    public class Record {
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public bool? RecordValue { get; set; }
        [DataMember(Name = "channel", EmitDefaultValue = false)]
        public int? ChannelId { get; set; }
    }
}
