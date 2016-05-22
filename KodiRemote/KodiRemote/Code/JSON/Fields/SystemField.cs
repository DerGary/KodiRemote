using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class SystemField : Field<SystemField> {
        public bool Canshutdown { get; set; }
        public bool Cansuspend { get; set; }
        public bool Canhibernate { get; set; }
        public bool Canreboot { get; set; }
        public override void All() {
            Canshutdown = true;
            Cansuspend = true;
            Canhibernate = true;
            Canreboot = true;
        }
        public override List<string> ToList() {
            List<string> list = new List<string>();
            if (Canshutdown)
                list.Add("canshutdown");
            if (Cansuspend)
                list.Add("cansuspend");
            if (Canhibernate)
                list.Add("canhibernate");
            if (Canreboot)
                list.Add("canreboot");
            return list;
        }
        public override void Mine() {
            All();
        }
    }
}
