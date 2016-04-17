using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KApplication.Notifications {
    [DataContract]
    public class Data {
        [DataMember(Name = "volume")]
        public int Volume { get; set; }
        [DataMember(Name = "muted")]
        public bool Muted { get; set; }
    }
}
