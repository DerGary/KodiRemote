using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class GenreField : IField {
        public bool Title { get; set; }
        public bool Thumbnail { get; set; }
        public void All() {
            Title = true;
            Thumbnail = true;
        }
        public List<String> ToList() {
            List<String> list = new List<string>();
            if (Title)
                list.Add("title");
            if (Thumbnail)
                list.Add("thumbnail");
            return list;
        }
    }
}
