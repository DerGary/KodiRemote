using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class MovieSetField : IField {
        public bool Title { get; set; }
        public bool Playcount { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool Art { get; set; }
        public void All() {
            Title = true;
            Playcount = true;
            Fanart = true;
            Thumbnail = true;
            Art = true;
        }
        public List<String> ToList() {
            List<string> list = new List<string>();
            if (Title)
                list.Add("title");
            if (Playcount)
                list.Add("playcount");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            if (Art)
                list.Add("art");
            return list;
        }
    }
}
