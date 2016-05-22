using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class EpisodeField : Field<EpisodeField> {
        public bool Title { get; set; }
        public bool Plot { get; set; }
        public bool Votes { get; set; }
        public bool Rating { get; set; }
        public bool Writer { get; set; }
        public bool Firstaired { get; set; }
        public bool Playcount { get; set; }
        public bool Runtime { get; set; }
        public bool Director { get; set; }
        public bool Productioncode { get; set; }
        public bool Season { get; set; }
        public bool Episode { get; set; }
        public bool Originaltitle { get; set; }
        public bool Showtitle { get; set; }
        public bool Cast { get; set; }
        public bool Streamdetails { get; set; }
        public bool Lastplayed { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool File { get; set; }
        public bool Resume { get; set; }
        public bool Tvshowid { get; set; }
        public bool Dateadded { get; set; }
        public bool Uniqueid { get; set; }
        public bool Art { get; set; }
        public override void All() {
            Title = true;
            Plot = true;
            Votes = true;
            Rating = true;
            Writer = true;
            Firstaired = true;
            Playcount = true;
            Runtime = true;
            Director = true;
            Productioncode = true;
            Season = true;
            Episode = true;
            Originaltitle = true;
            Showtitle = true;
            Cast = true;
            Streamdetails = true;
            Lastplayed = true;
            Fanart = true;
            Thumbnail = true;
            File = true;
            Resume = true;
            Tvshowid = true;
            Dateadded = true;
            Uniqueid = true;
            Art = true;
        }
        public override void Mine() {
            Episode = true;
            Tvshowid = true;
            Season = true;
            Rating = true;
            Plot = true;
            Playcount = true;
            Runtime = true;
            Thumbnail = true;
            Title = true;
            Cast = true;
            Streamdetails = true;
            Dateadded = true;
            Director = true;
        }
        public override List<String> ToList() {
            List<String> list = new List<string>();
            if (Title)
                list.Add("title");
            if (Plot)
                list.Add("plot");
            if (Votes)
                list.Add("votes");
            if (Rating)
                list.Add("rating");
            if (Writer)
                list.Add("writer");
            if (Firstaired)
                list.Add("firstaired");
            if (Playcount)
                list.Add("playcount");
            if (Runtime)
                list.Add("runtime");
            if (Director)
                list.Add("director");
            if (Productioncode)
                list.Add("productioncode");
            if (Season)
                list.Add("season");
            if (Episode)
                list.Add("episode");
            if (Originaltitle)
                list.Add("originaltitle");
            if (Showtitle)
                list.Add("showtitle");
            if (Cast)
                list.Add("cast");
            if (Streamdetails)
                list.Add("streamdetails");
            if (Lastplayed)
                list.Add("lastplayed");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            if (File)
                list.Add("file");
            if (Resume)
                list.Add("resume");
            if (Tvshowid)
                list.Add("tvshowid");
            if (Dateadded)
                list.Add("dateadded");
            if (Uniqueid)
                list.Add("uniqueid");
            if (Art)
                list.Add("art");
            return list;
        }
    }
}
