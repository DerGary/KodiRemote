using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KSystems.Params {
    [DataContract]
    public class GetProperties {
        [DataMember(Name = "properties")]
        public List<string> Properties { get; set; }
    }

}
