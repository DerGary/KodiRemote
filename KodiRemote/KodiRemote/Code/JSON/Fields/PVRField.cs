using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class PVRField : IField {
        public bool Available { get; set; }
        public bool Recording { get; set; }
        public bool Scanning { get; set; }
        public void All() {
            Available = true;
            Recording = true;
            Scanning = true;
        }
        public List<string> ToList() {
            List<string> list = new List<string>();
            if (Available)
                list.Add("available");
            if (Recording)
                list.Add("recording");
            if (Scanning)
                list.Add("scanning");
            return list;
        }
    }
}
