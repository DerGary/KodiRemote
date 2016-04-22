using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General.Results {
    [DataContract]
    public class CollectionResultBase {
        [DataMember(Name = "limits")]
        public LimitsWithTotal Limits { get; set; }
    }
    [DataContract]
    public class GenresResult : CollectionResultBase {
        [DataMember(Name = "genres")]
        public List<Genre> Genres { get; set; }
    }
    [DataContract]
    public class Genre {
        [DataMember(Name = "genreid")]
        public int GenreId { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
    }

    [DataContract]
    public class ItemArt {
        [DataMember(Name = "album.thumb")]
        public string Albumthumb { get; set; }
        [DataMember(Name = "artist.fanart")]
        public string Artistfanart { get; set; }
        public string Fanart { get; set; }
        public string Poster { get; set; }
    }
    [DataContract]
    public class ItemResult {
        [DataMember(Name = "item")]
        public Item Item { get; set; }
    }
    [DataContract]
    public class Item {
        [DataMember(Name = "album")]
        public string album { get; set; }
        [DataMember(Name = "albumartist")]
        public string[] albumartist { get; set; }
        [DataMember(Name = "albumid")]
        public int albumid { get; set; }
        [DataMember(Name = "art")]
        public ItemArt art { get; set; }
        [DataMember(Name = "artist")]
        public string[] artist { get; set; }
        [DataMember(Name = "comment")]
        public string comment { get; set; }
        [DataMember(Name = "description")]
        public string description { get; set; }
        [DataMember(Name = "disc")]
        public int disc { get; set; }
        [DataMember(Name = "displayartist")]
        public string displayartist { get; set; }
        [DataMember(Name = "duration")]
        public int duration { get; set; }
        [DataMember(Name = "fanart")]
        public string fanart { get; set; }
        [DataMember(Name = "file")]
        public string file { get; set; }
        [DataMember(Name = "genre")]
        public string[] genre { get; set; }
        [DataMember(Name = "genreid")]
        public int[] genreid { get; set; }
        [DataMember(Name = "id")]
        public int id { get; set; }
        [DataMember(Name = "label")]
        public string label { get; set; }
        [DataMember(Name = "lastplayed")]
        public string lastplayed { get; set; }
        [DataMember(Name = "lyrics")]
        public string lyrics { get; set; }
        [DataMember(Name = "mood")]
        public string[] mood { get; set; }
        [DataMember(Name = "musicbrainzalbumartistid")]
        public string musicbrainzalbumartistid { get; set; }
        [DataMember(Name = "musicbrainzalbumid")]
        public string musicbrainzalbumid { get; set; }
        [DataMember(Name = "musicbrainzartistid")]
        public string musicbrainzartistid { get; set; }
        [DataMember(Name = "musicbrainztrackid")]
        public string musicbrainztrackid { get; set; }
        [DataMember(Name = "playcount")]
        public int playcount { get; set; }
        [DataMember(Name = "rating")]
        public float rating { get; set; }
        [DataMember(Name = "style")]
        public string[] style { get; set; }
        [DataMember(Name = "thumbnail")]
        public string thumbnail { get; set; }
        [DataMember(Name = "title")]
        public string title { get; set; }
        [DataMember(Name = "track")]
        public int track { get; set; }
        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "year")]
        public int year { get; set; }
        [DataMember(Name = "director")]
        public string[] director { get; set; }
        [DataMember(Name = "trailer")]
        public string trailer { get; set; }
        [DataMember(Name = "tagline")]
        public string tagline { get; set; }
        [DataMember(Name = "plot")]
        public string plot { get; set; }
        [DataMember(Name = "plotoutline")]
        public string plotoutline { get; set; }
        [DataMember(Name = "originaltitle")]
        public string originaltitle { get; set; }
        [DataMember(Name = "writer")]
        public string[] writer { get; set; }
        [DataMember(Name = "studio")]
        public string[] studio { get; set; }
        [DataMember(Name = "mpaa")]
        public string mpaa { get; set; }
        [DataMember(Name = "cast")]
        public Actor[] cast { get; set; }
        [DataMember(Name = "country")]
        public string[] country { get; set; }
        [DataMember(Name = "imdbnumber")]
        public string imdbnumber { get; set; }
        [DataMember(Name = "premiered")]
        public string premiered { get; set; }
        [DataMember(Name = "productioncode")]
        public string productioncode { get; set; }
        [DataMember(Name = "runtime")]
        public int runtime { get; set; }
        [DataMember(Name = "set")]
        public string set { get; set; }
        [DataMember(Name = "showlink")]
        public string[] showlink { get; set; }
        //[DataMember(Name = "streamdetails")]
        //public MovieStreamDetails streamdetails { get; set; }
        [DataMember(Name = "top250")]
        public int top250 { get; set; }
        [DataMember(Name = "votes")]
        public string votes { get; set; }
        [DataMember(Name = "firstaired")]
        public string firstaired { get; set; }
        [DataMember(Name = "season")]
        public int season { get; set; }
        [DataMember(Name = "episode")]
        public int episode { get; set; }
        [DataMember(Name = "showtitle")]
        public string showtitle { get; set; }
        [DataMember(Name = "resume")]
        public ResumeTime resume { get; set; }
        [DataMember(Name = "artistid")]
        public int[] artistid { get; set; }
        [DataMember(Name = "tvshowid")]
        public int tvshowid { get; set; }
        [DataMember(Name = "setid")]
        public int setid { get; set; }
        [DataMember(Name = "watchedepisodes")]
        public int watchedepisodes { get; set; }
        [DataMember(Name = "tag")]
        public string[] tag { get; set; }
        [DataMember(Name = "albumartistid")]
        public int[] albumartistid { get; set; }
        [DataMember(Name = "theme")]
        public string theme { get; set; }
        [DataMember(Name = "albumlabel")]
        public string albumlabel { get; set; }
        [DataMember(Name = "sorttitle")]
        public string sorttitle { get; set; }
        [DataMember(Name = "episodeguide")]
        public string episodeguide { get; set; }
        //[DataMember(Name = "uniqueid")]
        //public UniqueID uniqueid { get; set; }
        [DataMember(Name = "dateadded")]
        public string dateadded { get; set; }
        [DataMember(Name = "channel")]
        public string channel { get; set; }
        [DataMember(Name = "channeltype")]
        public string channeltype { get; set; }
        [DataMember(Name = "hidden")]
        public bool hidden { get; set; }
        [DataMember(Name = "locked")]
        public bool locked { get; set; }
        [DataMember(Name = "channelnumber")]
        public int channelnumber { get; set; }
        [DataMember(Name = "starttime")]
        public int starttime { get; set; }
        [DataMember(Name = "endtime")]
        public int endtime { get; set; }
    }

}
