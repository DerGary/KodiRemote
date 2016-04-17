using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class Limits {
        [DataMember(Name = "end")]
        public int End { get; set; }
        [DataMember(Name = "start")]
        public int Start { get; set; }
        public Limits(int start, int end) {
            this.Start = start;
            this.End = end;
        }
    }
}
