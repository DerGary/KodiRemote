using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class Actor {
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "role")]
        public string role { get; set; }
        [DataMember(Name = "thumbnail")]
        public string thumbnail { get; set; }
    }
}
