using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class Sort {
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public string Order { get; set; }
        [DataMember(Name = "ignorearticle", EmitDefaultValue = false)]
        public bool? IgnoreArticle { get; set; }
        [DataMember(Name = "method", EmitDefaultValue = false)]
        public string Method { get; set; }
    }
}
