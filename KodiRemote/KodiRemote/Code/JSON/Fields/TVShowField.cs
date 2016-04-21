using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class TVShowField : Field<TVShowField> {
        public bool Title { get; set; }
        public bool Genre { get; set; }
        public bool Year { get; set; }
        public bool Rating { get; set; }
        public bool Plot { get; set; }
        public bool Studio { get; set; }
        public bool Mpaa { get; set; }
        public bool Cast { get; set; }
        public bool Playcount { get; set; }
        public bool Episode { get; set; }
        public bool Imdbnumber { get; set; }
        public bool Premiered { get; set; }
        public bool Votes { get; set; }
        public bool Lastplayed { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool File { get; set; }
        public bool Originaltitle { get; set; }
        public bool Sorttitle { get; set; }
        public bool Episodeguide { get; set; }
        public bool Season { get; set; }
        public bool Watchedepisodes { get; set; }
        public bool Dateadded { get; set; }
        public bool Tag { get; set; }
        public bool Art { get; set; }
        public override void All() {
            Title = true;
            Genre = true;
            Year = true;
            Rating = true;
            Plot = true;
            Studio = true;
            Mpaa = true;
            Cast = true;
            Playcount = true;
            Episode = true;
            Imdbnumber = true;
            Premiered = true;
            Votes = true;
            Lastplayed = true;
            Fanart = true;
            Thumbnail = true;
            File = true;
            Originaltitle = true;
            Sorttitle = true;
            Episodeguide = true;
            Season = true;
            Watchedepisodes = true;
            Dateadded = true;
            Tag = true;
            Art = true;
        }
        public void Mine() {
            Title = true;
            Genre = true;
            Rating = true;
            Plot = true;
            Cast = true;
            Episode = true;
            Imdbnumber = true;
            Watchedepisodes = true;
            Dateadded = true;
            Art = true;
        }
        public override List<string> ToList() {
            List<String> list = new List<string>();
            if (Title)
                list.Add("title");
            if (Genre)
                list.Add("genre");
            if (Year)
                list.Add("year");
            if (Rating)
                list.Add("rating");
            if (Plot)
                list.Add("plot");
            if (Studio)
                list.Add("studio");
            if (Mpaa)
                list.Add("mpaa");
            if (Cast)
                list.Add("cast");
            if (Playcount)
                list.Add("playcount");
            if (Episode)
                list.Add("episode");
            if (Imdbnumber)
                list.Add("imdbnumber");
            if (Premiered)
                list.Add("premiered");
            if (Votes)
                list.Add("votes");
            if (Lastplayed)
                list.Add("lastplayed");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            if (File)
                list.Add("file");
            if (Originaltitle)
                list.Add("originaltitle");
            if (Sorttitle)
                list.Add("sorttitle");
            if (Episodeguide)
                list.Add("episodeguide");
            if (Season)
                list.Add("season");
            if (Watchedepisodes)
                list.Add("watchedepisodes");
            if (Dateadded)
                list.Add("dateadded");
            if (Tag)
                list.Add("tag");
            if (Art)
                list.Add("art");
            return list;
        }
    }
}
