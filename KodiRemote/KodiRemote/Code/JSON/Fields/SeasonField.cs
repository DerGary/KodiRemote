using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class SeasonField : Field<SeasonField> {
        public bool Season { get; set; }
        public bool Showtitle { get; set; }
        public bool Playcount { get; set; }
        public bool Episode { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool Tvshowid { get; set; }
        public bool Watchedepisodes { get; set; }
        public bool Art { get; set; }
        public override void All() {
            Season = true;
            Showtitle = true;
            Playcount = true;
            Episode = true;
            Fanart = true;
            Thumbnail = true;
            Tvshowid = true;
            Watchedepisodes = true;
            Art = true;
        }
        public override void Mine() {
            Season = true;
            Episode = true;
            Tvshowid = true;
            Watchedepisodes = true;
            Art = true;
        }
        public override List<string> ToList() {
            List<string> list = new List<string>();
            if (Season)
                list.Add("season");
            if (Showtitle)
                list.Add("showtitle");
            if (Playcount)
                list.Add("playcount");
            if (Episode)
                list.Add("episode");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            if (Tvshowid)
                list.Add("tvshowid");
            if (Watchedepisodes)
                list.Add("watchedepisodes");
            if (Art)
                list.Add("art");
            return list;
        }
    }
}
