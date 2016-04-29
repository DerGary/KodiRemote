using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KApplication.Results {
    [DataContract]
    public class ApplicationProperties {
        [DataMember(Name = "muted")]
        public bool Muted { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "version")]
        public ApplicationVersion Version { get; set; }
        [DataMember(Name = "volume")]
        public int Volume { get; set; }
    }
    [DataContract]
    public class ApplicationVersion {
        [DataMember(Name = "major")]
        public int Major { get; set; }
        [DataMember(Name = "minor")]
        public int Minor { get; set; }
        [DataMember(Name = "revision")]
        public string Revision { get; set; }
        [DataMember(Name = "tag")]
        public string Tag { get; set; }
    }
}