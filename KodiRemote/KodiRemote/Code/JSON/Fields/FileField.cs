using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.Fields {
    public class FileField : Field<FileField> {
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
        public bool Director { get; set; }
        public bool Trailer { get; set; }
        public bool Tagline { get; set; }
        public bool Plot { get; set; }
        public bool Plotoutline { get; set; }
        public bool Originaltitle { get; set; }
        public bool Lastplayed { get; set; }
        public bool Writer { get; set; }
        public bool Studio { get; set; }
        public bool Mpaa { get; set; }
        public bool Cast { get; set; }
        public bool Country { get; set; }
        public bool Imdbnumber { get; set; }
        public bool Premiered { get; set; }
        public bool Productioncode { get; set; }
        public bool Runtime { get; set; }
        public bool Set { get; set; }
        public bool Showlink { get; set; }
        public bool Streamdetails { get; set; }
        public bool Top250 { get; set; }
        public bool Votes { get; set; }
        public bool Firstaired { get; set; }
        public bool Season { get; set; }
        public bool Episode { get; set; }
        public bool Showtitle { get; set; }
        public bool Thumbnail { get; set; }
        public bool File { get; set; }
        public bool Resume { get; set; }
        public bool Artistid { get; set; }
        public bool Albumid { get; set; }
        public bool Tvshowid { get; set; }
        public bool Setid { get; set; }
        public bool Watchedepisodes { get; set; }
        public bool Disc { get; set; }
        public bool Tag { get; set; }
        public bool Art { get; set; }
        public bool Genreid { get; set; }
        public bool Displayartist { get; set; }
        public bool Albumartistid { get; set; }
        public bool Description { get; set; }
        public bool Theme { get; set; }
        public bool Mood { get; set; }
        public bool Style { get; set; }
        public bool Albumlabel { get; set; }
        public bool Sorttitle { get; set; }
        public bool Episodeguide { get; set; }
        public bool Uniqueid { get; set; }
        public bool Dateadded { get; set; }
        public bool Size { get; set; }
        public bool Lastmodified { get; set; }
        public bool Mimetype { get; set; }
        public override void All() {
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
            Director = true;
            Trailer = true;
            Tagline = true;
            Plot = true;
            Plotoutline = true;
            Originaltitle = true;
            Lastplayed = true;
            Writer = true;
            Studio = true;
            Mpaa = true;
            Cast = true;
            Country = true;
            Imdbnumber = true;
            Premiered = true;
            Productioncode = true;
            Runtime = true;
            Set = true;
            Showlink = true;
            Streamdetails = true;
            Top250 = true;
            Votes = true;
            Firstaired = true;
            Season = true;
            Episode = true;
            Showtitle = true;
            Thumbnail = true;
            File = true;
            Resume = true;
            Artistid = true;
            Albumid = true;
            Tvshowid = true;
            Setid = true;
            Watchedepisodes = true;
            Disc = true;
            Tag = true;
            Art = true;
            Genreid = true;
            Displayartist = true;
            Albumartistid = true;
            Description = true;
            Theme = true;
            Mood = true;
            Style = true;
            Albumlabel = true;
            Sorttitle = true;
            Episodeguide = true;
            Uniqueid = true;
            Dateadded = true;
            Size = true;
            Lastmodified = true;
            Mimetype = true;
        }
        public override List<string> ToList() {
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
            if (Premiered)
                list.Add("premiered");
            if (Productioncode)
                list.Add("productioncode");
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
            if (Firstaired)
                list.Add("firstaired");
            if (Season)
                list.Add("season");
            if (Episode)
                list.Add("episode");
            if (Showtitle)
                list.Add("showtitle");
            if (Thumbnail)
                list.Add("thumbnail");
            if (File)
                list.Add("file");
            if (Resume)
                list.Add("resume");
            if (Artistid)
                list.Add("artistid");
            if (Albumid)
                list.Add("albumid");
            if (Tvshowid)
                list.Add("tvshowid");
            if (Setid)
                list.Add("setid");
            if (Watchedepisodes)
                list.Add("watchedepisodes");
            if (Disc)
                list.Add("disc");
            if (Tag)
                list.Add("tag");
            if (Art)
                list.Add("art");
            if (Genreid)
                list.Add("genreid");
            if (Displayartist)
                list.Add("displayartist");
            if (Albumartistid)
                list.Add("albumartistid");
            if (Description)
                list.Add("description");
            if (Theme)
                list.Add("theme");
            if (Mood)
                list.Add("mood");
            if (Style)
                list.Add("style");
            if (Albumlabel)
                list.Add("albumlabel");
            if (Sorttitle)
                list.Add("sorttitle");
            if (Episodeguide)
                list.Add("episodeguide");
            if (Uniqueid)
                list.Add("uniqueid");
            if (Dateadded)
                list.Add("dateadded");
            if (Size)
                list.Add("size");
            if (Lastmodified)
                list.Add("lastmodified");
            if (Mimetype)
                list.Add("mimetype");
            return list;
        }

        public override void Mine() {
            All();
        }
    }
}
