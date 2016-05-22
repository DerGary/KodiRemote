using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class AlbumField : Field<AlbumField> {
        public bool Title { get; set; }
        public bool Description { get; set; }
        public bool Artist { get; set; }
        public bool Genre { get; set; }
        public bool Theme { get; set; }
        public bool Mood { get; set; }
        public bool Style { get; set; }
        public bool Type { get; set; }
        public bool Albumlabel { get; set; }
        public bool Rating { get; set; }
        public bool Year { get; set; }
        public bool Musicbrainzalbumid { get; set; }
        public bool Musicbrainzalbumartistid { get; set; }
        public bool Fanart { get; set; }
        public bool Thumbnail { get; set; }
        public bool Playcount { get; set; }
        public bool Genreid { get; set; }
        public bool Artistid { get; set; }
        public bool Displayartist { get; set; }
        public override void All() {
            Title = true;
            Description = true;
            Artist = true;
            Genre = true;
            Theme = true;
            Mood = true;
            Style = true;
            Type = true;
            Albumlabel = true;
            Rating = true;
            Year = true;
            Musicbrainzalbumid = true;
            Musicbrainzalbumartistid = true;
            Fanart = true;
            Thumbnail = true;
            Playcount = true;
            Genreid = true;
            Artistid = true;
            Displayartist = true;
        }
        public override List<String> ToList() {
            List<String> list = new List<string>();
            if (Title)
                list.Add("title");
            if (Description)
                list.Add("description");
            if (Artist)
                list.Add("artist");
            if (Genre)
                list.Add("genre");
            if (Theme)
                list.Add("theme");
            if (Mood)
                list.Add("mood");
            if (Style)
                list.Add("style");
            if (Type)
                list.Add("type");
            if (Albumlabel)
                list.Add("albumlabel");
            if (Rating)
                list.Add("rating");
            if (Year)
                list.Add("year");
            if (Musicbrainzalbumid)
                list.Add("musicbrainzalbumid");
            if (Musicbrainzalbumartistid)
                list.Add("musicbrainzalbumartistid");
            if (Fanart)
                list.Add("fanart");
            if (Thumbnail)
                list.Add("thumbnail");
            if (Playcount)
                list.Add("playcount");
            if (Genreid)
                list.Add("genreid");
            if (Artistid)
                list.Add("artistid");
            if (Displayartist)
                list.Add("displayartist");
            return list;
        }

        public override void Mine() {
            Title = true;
            Description = true;
            Artist = true;
            Type = true;
            Albumlabel = true;
            Rating = true;
            Year = true;
            Fanart = true;
            Thumbnail = true;
            Playcount = true;
            Artistid = true;
            Displayartist = true;
            Genre = true;
        }
    }
}
