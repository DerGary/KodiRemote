using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XBMCRemote.JSONRPCClasses {
    [DataContract]
    public class Sort {
        [DataMember(Name = "order")]
        public string Order { get; set; }
        [DataMember(Name = "ignorearticle")]
        public bool IgnoreArticle { get; set; }
        [DataMember(Name = "method")]
        public string Method { get; set; }
    }
}
