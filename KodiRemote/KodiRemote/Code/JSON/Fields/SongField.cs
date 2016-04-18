using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class SongField : IField {
        public bool Title { get; set; }
        public bool Artist { get; set; }
        public bool Albumartist { get; set; }
        public bool Genre { get; set; }
        public bool Year { get; set; }
        public bool Rating { get; set; }
        public bool Album { get; set; }
        public bool Track { get; set; }
        public bool Duration { get; set; }
        public bool Comment { get; set; }
        public bool Lyrics { get; set; }
        public bool Musicbrainztrackid { get; set; }
        public bool Musicbrainzartistid { get; set; }
        public bool Musicbrainzalbumid { get; set; }
        public bool Musicbrainzalbumartistid { get; set; }
        public bool Playcount { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool File { get; set; }
        public bool Albumid { get; set; }
        public bool Lastplayed { get; set; }
        public bool Disc { get; set; }
        public bool Genreid { get; set; }
        public bool Artistid { get; set; }
        public bool Displayartist { get; set; }
        public bool Albumartistid { get; set; }
        public void All() {
            Title = true;
            Artist = true;
            Albumartist = true;
            Genre = true;
            Year = true;
            Rating = true;
            Album = true;
            Track = true;
            Duration = true;
            Comment = true;
            Lyrics = true;
            Musicbrainztrackid = true;
            Musicbrainzartistid = true;
            Musicbrainzalbumid = true;
            Musicbrainzalbumartistid = true;
            Playcount = true;
            Fanart = true;
            Thumbnail = true;
            File = true;
            Albumid = true;
            Lastplayed = true;
            Disc = true;
            Genreid = true;
            Artistid = true;
            Displayartist = true;
            Albumartistid = true;
        }
        public List<string> ToList() {
            List<string> list = new List<string>();
            if (Title)
                list.Add("title");
            if (Artist)
                list.Add("artist");
            if (Albumartist)
                list.Add("albumartist");
            if (Genre)
                list.Add("genre");
            if (Year)
                list.Add("year");
            if (Rating)
                list.Add("rating");
            if (Album)
                list.Add("album");
            if (Track)
                list.Add("track");
            if (Duration)
                list.Add("duration");
            if (Comment)
                list.Add("comment");
            if (Lyrics)
                list.Add("lyrics");
            if (Musicbrainztrackid)
                list.Add("musicbrainztrackid");
            if (Musicbrainzartistid)
                list.Add("musicbrainzartistid");
            if (Musicbrainzalbumid)
                list.Add("musicbrainzalbumid");
            if (Musicbrainzalbumartistid)
                list.Add("musicbrainzalbumartistid");
            if (Playcount)
                list.Add("playcount");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            if (File)
                list.Add("file");
            if (Albumid)
                list.Add("albumid");
            if (Lastplayed)
                list.Add("lastplayed");
            if (Disc)
                list.Add("disc");
            if (Genreid)
                list.Add("genreid");
            if (Artistid)
                list.Add("artistid");
            if (Displayartist)
                list.Add("displayartist");
            if (Albumartistid)
                list.Add("albumartistid");
            return list;
        }

        internal void Mine() {
            Title = true;
            Artist = true;
            Genre = true;
            Year = true;
            Rating = true;
            Album = true;
            Track = true;
            Duration = true;
            Comment = true;
            Playcount = true;
            Fanart = true;
            Thumbnail = true;
            Albumid = true;
            Artistid = true;
            Displayartist = true;
        }
    }
}
