using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KInput.Params {
    [DataContract]
    public class ExecAction {
        [DataMember(Name = "action")]
        public string Action { get; set; }
    }
    [DataContract]
    public class SendText {
        [DataMember(Name = "text")]
        public string Text { get; set; }
        [DataMember(Name = "done")]
        public bool Done { get; set; }
    }
}
