using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KFiles.Params;
using KodiRemote.Code.JSON.KJSONRPC.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAudioLibrary.Results {

    [DataContract]
    public class AlbumResult : CollectionResultBase {
        [DataMember(Name = "albums")]
        public List<Album> Albums { get; set; }
    }
    [DataContract]
    public class ArtistResult : CollectionResultBase {
        [DataMember(Name = "artists")]
        public List<Artist> Artists { get; set; }
    }
    [DataContract]
    public class SongResult : CollectionResultBase {
        [DataMember(Name = "songs")]
        public List<Song> Songs { get; set; }
    }
    [DataContract]
    public class Album {
        [DataMember(Name = "albumid")]
        public int AlbumId { get; set; }
        [DataMember(Name = "albumlabel")]
        public string AlbumLabel { get; set; }
        [DataMember(Name = "artist")]
        public List<string> Artist { get; set; }
        [DataMember(Name = "artistid")]
        public List<int> ArtistId { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "displayartist")]
        public string DisplayArtist { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "genreid")]
        public List<int> GenreId { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "mood")]
        public List<string> Mood { get; set; }
        [DataMember(Name = "musicbrainzalbumartistid")]
        public string MusicBrainzAlbumArtistId { get; set; }
        [DataMember(Name = "musicbrainzalbumid")]
        public string MusicBrainzAlbumId { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "rating")]
        public float Rating { get; set; }
        [DataMember(Name = "style")]
        public List<string> Style { get; set; }
        [DataMember(Name = "theme")]
        public List<string> Theme { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
    }
    [DataContract]
    public class Artist {
        [DataMember(Name = "artist")]
        public string ArtistName { get; set; }
        [DataMember(Name = "artistid")]
        public int ArtistId { get; set; }
        [DataMember(Name = "born")]
        public string Born { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "died")]
        public string Died { get; set; }
        [DataMember(Name = "disbanded")]
        public string Disbanded { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "formed")]
        public string Formed { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "instrument")]
        public List<string> Instrument { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "mood")]
        public List<string> Mood { get; set; }
        [DataMember(Name = "musicbrainzartistid")]
        public string MusicBrainzArtistId { get; set; }
        [DataMember(Name = "style")]
        public List<string> Style { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "yearsactive")]
        public List<string> YearsActive { get; set; }
    }
    [DataContract]
    public class Song {
        [DataMember(Name = "album")]
        public string Album { get; set; }
        [DataMember(Name = "albumartist")]
        public List<string> AlbumArtist { get; set; }
        [DataMember(Name = "albumartistid")]
        public List<int> AlbumArtistId { get; set; }
        [DataMember(Name = "albumid")]
        public int AlbumId { get; set; }
        [DataMember(Name = "artist")]
        public List<string> Artist { get; set; }
        [DataMember(Name = "artistid")]
        public List<int> ArtistId { get; set; }
        [DataMember(Name = "comment")]
        public string Comment { get; set; }
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
        public List<string> Genre { get; set; }
        [DataMember(Name = "genreid")]
        public List<int> GenreId { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "lastplayed")]
        public string LastPlayed { get; set; }
        [DataMember(Name = "lyrics")]
        public string Lyrics { get; set; }
        [DataMember(Name = "musicbrainzalbumartistid")]
        public string MusicBrainzAlbumArtistId { get; set; }
        [DataMember(Name = "musicbrainzalbumid")]
        public string MusicBrainzAlbumId { get; set; }
        [DataMember(Name = "musicbrainzartistid")]
        public string MusicBrainzArtistId { get; set; }
        [DataMember(Name = "musicbrainztrackid")]
        public string MusicBrainzTrackId { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "rating")]
        public float Rating { get; set; }
        [DataMember(Name = "songid")]
        public int SongId { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "track")]
        public int Track { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
    }
}