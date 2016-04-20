using KodiRemote.Code.JSON.General.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KApplication.Params {
    [DataContract]
    public class GetProperties : PropertyBase { }

    [DataContract]
    public class SetMute<T> {
        [DataMember(Name = "mute")]
        public T MuteValue { get; set; }
    }
    [DataContract]
    public class SetVolume<T> {
        [DataMember(Name = "volume")]
        public T VolumeValue { get; set; }
    }
}
