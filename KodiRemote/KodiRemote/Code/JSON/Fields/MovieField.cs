using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class MovieField : Field<MovieField> {
        public bool Title { get; set; }
        public bool Genre { get; set; }
        public bool Year { get; set; }
        public bool Rating { get; set; }
        public bool Director { get; set; }
        public bool Trailer { get; set; }
        public bool Tagline { get; set; }
        public bool Plot { get; set; }
        public bool Plotoutline { get; set; }
        public bool Originaltitle { get; set; }
        public bool Lastplayed { get; set; }
        public bool Playcount { get; set; }
        public bool Writer { get; set; }
        public bool Studio { get; set; }
        public bool Mpaa { get; set; }
        public bool Cast { get; set; }
        public bool Country { get; set; }
        public bool Imdbnumber { get; set; }
        public bool Runtime { get; set; }
        public bool Set { get; set; }
        public bool Showlink { get; set; }
        public bool Streamdetails { get; set; }
        public bool Top250 { get; set; }
        public bool Votes { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool File { get; set; }
        public bool Sorttitle { get; set; }
        public bool Resume { get; set; }
        public bool Setid { get; set; }
        public bool Dateadded { get; set; }
        public bool Tag { get; set; }
        public bool Art { get; set; }
        public override void All() {
            Title = true;
            Genre = true;
            Year = true;
            Rating = true;
            Director = true;
            Trailer = true;
            Tagline = true;
            Plot = true;
            Plotoutline = true;
            Originaltitle = true;
            Lastplayed = true;
            Playcount = true;
            Writer = true;
            Studio = true;
            Mpaa = true;
            Cast = true;
            Country = true;
            Imdbnumber = true;
            Runtime = true;
            Set = true;
            Showlink = true;
            Streamdetails = true;
            Top250 = true;
            Votes = true;
            Fanart = true;
            Thumbnail = true;
            File = true;
            Sorttitle = true;
            Resume = true;
            Setid = true;
            Dateadded = true;
            Tag = true;
            Art = true;
        }
        public override void Mine() {
            Year = true;
            Trailer = true;
            Imdbnumber = true;
            Setid = true;
            Genre = true;
            Director = true;
            Art = true;
            Rating = true;
            Plot = true;
            Playcount = true;
            Runtime = true;
            Streamdetails = true;
            Cast = true;
            Dateadded = true;
        }
        public override List<String> ToList() {
            List<String> list = new List<String>();
            if (Title)
                list.Add("title");
            if (Genre)
                list.Add("genre");
            if (Year)
                list.Add("year");
            if (Rating)
                list.Add("rating");
            if (Director)
                list.Add("director");
            if (Trailer)
                list.Add("trailer");
            if (Tagline)
                list.Add("tagline");
            if (Plot)
                list.Add("plot");
            if (Plotoutline)
                list.Add("plotoutline");
            if (Originaltitle)
                list.Add("originaltitle");
            if (Lastplayed)
                list.Add("lastplayed");
            if (Playcount)
                list.Add("playcount");
            if (Writer)
                list.Add("writer");
            if (Studio)
                list.Add("studio");
            if (Mpaa)
                list.Add("mpaa");
            if (Cast)
                list.Add("cast");
            if (Country)
                list.Add("country");
            if (Imdbnumber)
                list.Add("imdbnumber");
            if (Runtime)
                list.Add("runtime");
            if (Set)
                list.Add("set");
            if (Showlink)
                list.Add("showlink");
            if (Streamdetails)
                list.Add("streamdetails");
            if (Top250)
                list.Add("top250");
            if (Votes)
                list.Add("votes");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            if (File)
                list.Add("file");
            if (Sorttitle)
                list.Add("sorttitle");
            if (Resume)
                list.Add("resume");
            if (Setid)
                list.Add("setid");
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
