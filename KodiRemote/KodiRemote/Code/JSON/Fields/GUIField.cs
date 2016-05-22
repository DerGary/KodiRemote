using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class GUIField : Field<GUIField> {
        public bool Currentwindow { get; set; }
        public bool Currentcontrol { get; set; }
        public bool Skin { get; set; }
        public bool Fullscreen { get; set; }
        public override void All() {
            Currentwindow = true;
            Currentcontrol = true;
            Skin = true;
            Fullscreen = true;
        }
        public override List<String> ToList() {
            List<string> list = new List<string>();
            if (Currentwindow)
                list.Add("currentwindow");
            if (Currentcontrol)
                list.Add("currentcontrol");
            if (Skin)
                list.Add("skin");
            if (Fullscreen)
                list.Add("fullscreen");
            return list;
        }
        public override void Mine() {
            All();
        }
    }
}
