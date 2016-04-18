using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using XBMCRemote.JSONRPCClasses;

namespace KodiRemote.Code.JSON.KJSONRPC.Params {
    [DataContract]
    public class Introspect {
        [DataMember(Name = "getdescriptions", EmitDefaultValue = false)]
        public bool? GetDescriptions { get; set; }
        [DataMember(Name = "getmetadata", EmitDefaultValue = false)]
        public bool? GetMetadata { get; set; }
        [DataMember(Name = "filterbytransport", EmitDefaultValue = false)]
        public bool? FilterByTransport { get; set; }
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public Dictionary<string, object> Filter { get; set; }
    }
    [DataContract]
    public class NotifyAll {
        [DataMember(Name = "sender")]
        public string Sender { get; set; }
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
    [DataContract]
    public class SetConfiguration {
        [DataMember(Name = "notifications", EmitDefaultValue = false)]
        public Notifications Notifications { get; set; }
    }
    [DataContract]
    public class Notifications {
        [DataMember(Name = "GUI", EmitDefaultValue = false)]
        public bool? GUI { get; set; }
        [DataMember(Name = "Other", EmitDefaultValue = false)]
        public bool? Other { get; set; }
        [DataMember(Name = "Input", EmitDefaultValue = false)]
        public bool? Input { get; set; }
        [DataMember(Name = "VideoLibrary", EmitDefaultValue = false)]
        public bool? VideoLibrary { get; set; }
        [DataMember(Name = "AudioLibrary", EmitDefaultValue = false)]
        public bool? AudioLibrary { get; set; }
        [DataMember(Name = "PVR", EmitDefaultValue = false)]
        public bool? PVR { get; set; }
        [DataMember(Name = "Playlist", EmitDefaultValue = false)]
        public bool? Playlist { get; set; }
        [DataMember(Name = "System", EmitDefaultValue = false)]
        public bool? System { get; set; }
        [DataMember(Name = "Player", EmitDefaultValue = false)]
        public bool? Player { get; set; }
        [DataMember(Name = "Application", EmitDefaultValue = false)]
        public bool? Application { get; set; }
    }
}
