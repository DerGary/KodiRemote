using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class MusicVideoField : IField {
        public bool Title { get; set; }
        public bool Playcount { get; set; }
        public bool Runtime { get; set; }
        public bool Director { get; set; }
        public bool Studio { get; set; }
        public bool Year { get; set; }
        public bool Plot { get; set; }
        public bool Album { get; set; }
        public bool Artist { get; set; }
        public bool Genre { get; set; }
        public bool Track { get; set; }
        public bool Streamdetails { get; set; }
        public bool Lastplayed { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool File { get; set; }
        public bool Resume { get; set; }
        public bool Dateadded { get; set; }
        public bool Tag { get; set; }
        public bool Art { get; set; }
        public void All() {
            Title = true;
            Playcount = true;
            Runtime = true;
            Director = true;
            Studio = true;
            Year = true;
            Plot = true;
            Album = true;
            Artist = true;
            Genre = true;
            Track = true;
            Streamdetails = true;
            Lastplayed = true;
            Fanart = true;
            Thumbnail = true;
            File = true;
            Resume = true;
            Dateadded = true;
            Tag = true;
            Art = true;
        }
        public void Mine() {
            Title = true;
            Playcount = true;
            Runtime = true;
            Director = true;
            Year = true;
            Plot = true;
            Album = true;
            Artist = true;
            Genre = true;
            Track = true;
            Streamdetails = true;
            Fanart = true;
            Thumbnail = true;
            Dateadded = true;
            Art = true;
        }
        public List<String> ToList() {
            List<string> list = new List<string>();
            if (Title)
                list.Add("title");
            if (Playcount)
                list.Add("playcount");
            if (Runtime)
                list.Add("runtime");
            if (Director)
                list.Add("director");
            if (Studio)
                list.Add("studio");
            if (Year)
                list.Add("year");
            if (Plot)
                list.Add("plot");
            if (Album)
                list.Add("album");
            if (Artist)
                list.Add("artist");
            if (Genre)
                list.Add("genre");
            if (Track)
                list.Add("track");
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
