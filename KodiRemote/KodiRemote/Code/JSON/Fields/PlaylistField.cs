using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class PlaylistField : Field<PlaylistField> {
        public bool Type { get; set; }
        public bool Size { get; set; }
        public override void All() {
            Type = true;
            Size = true;
        }
        public override List<string> ToList() {
            List<string> list = new List<string>();
            if (Type)
                list.Add("type");
            if (Size)
                list.Add("size");
            return list;
        }
        public override void Mine() {
            All();
        }
    }
}
