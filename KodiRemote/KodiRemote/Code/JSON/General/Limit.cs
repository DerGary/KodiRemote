using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class LimitsWithTotal : Limits {
        public LimitsWithTotal(int start, int end, int total) : base(start, end) {
            Total = total;
        }

        [DataMember(Name = "total")]
        public int Total { get; set; }
    }
}
