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
    public class ItemsResult {
        [DataMember(Name = "items")]
        public List<Item> Items { get; set; }
    }
    [DataContract]
    public class Item {
        [DataMember(Name = "album")]
        public string Album { get; set; }
        [DataMember(Name = "albumartist")]
        public string[] AlbumArtist { get; set; }
        [DataMember(Name = "albumid")]
        public int AlbumId { get; set; }
        [DataMember(Name = "art")]
        public ItemArt Art { get; set; }
        [DataMember(Name = "artist")]
        public string[] Artist { get; set; }
        [DataMember(Name = "comment")]
        public string Comment { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "disc")]
        public int Disc { get; set; }
        [DataMember(Name = "displayartist")]
        public string DisplayArtist { get; set; }
        [DataMember(Name = "duration")]
        public int Duration { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "file")]
        public string File { get; set; }
        [DataMember(Name = "genre")]
        public string[] Genre { get; set; }
        [DataMember(Name = "genreid")]
        public int[] GenreId { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "lastplayed")]
        public string LastPlayed { get; set; }
        [DataMember(Name = "lyrics")]
        public string Lyrics { get; set; }
        [DataMember(Name = "mood")]
        public string[] Mood { get; set; }
        [DataMember(Name = "musicbrainzalbumartistid")]
        public List<string> MusicBrainzAlbumArtistId { get; set; }
        [DataMember(Name = "musicbrainzalbumid")]
        public string MusicBrainzAlbumId { get; set; }
        [DataMember(Name = "musicbrainzartistid")]
        public List<string> MusicBrainzArtistId { get; set; }
        [DataMember(Name = "musicbrainztrackid")]
        public string MusicBrainzTrackId { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "rating")]
        public float Rating { get; set; }
        [DataMember(Name = "style")]
        public string[] Style { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "track")]
        public int Track { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
        [DataMember(Name = "director")]
        public string[] Director { get; set; }
        [DataMember(Name = "trailer")]
        public string Trailer { get; set; }
        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }
        [DataMember(Name = "plot")]
        public string Plot { get; set; }
        [DataMember(Name = "plotoutline")]
        public string PlotOutline { get; set; }
        [DataMember(Name = "originaltitle")]
        public string OriginalTitle { get; set; }
        [DataMember(Name = "writer")]
        public string[] Writer { get; set; }
        [DataMember(Name = "studio")]
        public string[] Studio { get; set; }
        [DataMember(Name = "mpaa")]
        public string MPAA { get; set; }
        [DataMember(Name = "cast")]
        public Actor[] Cast { get; set; }
        [DataMember(Name = "country")]
        public string[] Country { get; set; }
        [DataMember(Name = "imdbnumber")]
        public string IMDBNumber { get; set; }
        [DataMember(Name = "premiered")]
        public string Premiered { get; set; }
        [DataMember(Name = "productioncode")]
        public string ProductionCode { get; set; }
        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }
        [DataMember(Name = "set")]
        public string Set { get; set; }
        [DataMember(Name = "showlink")]
        public string[] ShowLink { get; set; }
        //[DataMember(Name = "streamdetails")]
        //public MovieStreamDetails streamdetails { get; set; }
        [DataMember(Name = "top250")]
        public int Top250 { get; set; }
        [DataMember(Name = "votes")]
        public string Votes { get; set; }
        [DataMember(Name = "firstaired")]
        public string FirstAired { get; set; }
        [DataMember(Name = "season")]
        public int Season { get; set; }
        [DataMember(Name = "episode")]
        public int Episode { get; set; }
        [DataMember(Name = "showtitle")]
        public string ShowTitle { get; set; }
        [DataMember(Name = "resume")]
        public ResumeTime Resume { get; set; }
        [DataMember(Name = "artistid")]
        public int[] ArtistId { get; set; }
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
        [DataMember(Name = "setid")]
        public int SetId { get; set; }
        [DataMember(Name = "watchedepisodes")]
        public int WatchedEpisodes { get; set; }
        [DataMember(Name = "tag")]
        public string[] Tag { get; set; }
        [DataMember(Name = "albumartistid")]
        public int[] AlbumArtistId { get; set; }
        [DataMember(Name = "theme")]
        public string Theme { get; set; }
        [DataMember(Name = "albumlabel")]
        public string AlbumLabel { get; set; }
        [DataMember(Name = "sorttitle")]
        public string SortTitle { get; set; }
        [DataMember(Name = "episodeguide")]
        public string EpisodeGuide { get; set; }
        //[DataMember(Name = "uniqueid")]
        //public UniqueID uniqueid { get; set; }
        [DataMember(Name = "dateadded")]
        public string DateAdded { get; set; }
        [DataMember(Name = "channel")]
        public string Channel { get; set; }
        [DataMember(Name = "channeltype")]
        public string ChannelType { get; set; }
        [DataMember(Name = "hidden")]
        public bool Hidden { get; set; }
        [DataMember(Name = "locked")]
        public bool Locked { get; set; }
        [DataMember(Name = "channelnumber")]
        public int ChannelNumber { get; set; }
        [DataMember(Name = "starttime")]
        public int StartTime { get; set; }
        [DataMember(Name = "endtime")]
        public int EndTime { get; set; }
    }

}
