using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class ResumeTime {
        [DataMember(Name = "position")]
        public float Position { get; set; }
        [DataMember(Name = "total")]
        public float Total { get; set; }
    }
}
