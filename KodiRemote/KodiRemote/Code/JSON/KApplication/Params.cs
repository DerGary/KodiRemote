using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KApplication.Params {
    [DataContract]
    public class Properties {
        [DataMember(Name = "properties")]
        public List<string> PropertiesValue { get; set; }
    }
    [DataContract]
    public class Mute<T> {
        [DataMember(Name = "mute")]
        public T MuteValue { get; set; }
    }
    [DataContract]
    public class Volume<T> {
        [DataMember(Name = "volume")]
        public T VolumeValue { get; set; }
    }
}
