using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class UniqueID {
        [DataMember(Name = "unknown")]
        public string Unknown { get; set; }
    }
}
