using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Filter;
using KodiRemote.Code.JSON.General.Params;
using KodiRemote.Code.JSON.KAudioLibrary.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAudioLibrary.Params {

    [DataContract]
    public class ExportOption : Options {
        [DataMember(Name = "images", EmitDefaultValue = false)]
        public bool Images { get; set; }
        [DataMember(Name = "overwrite", EmitDefaultValue = false)]
        public bool Overwrite { get; set; }
    }

    [DataContract]
    public class GetAlbumDetails : PropertyBase {
        [DataMember(Name = "albumid")]
        public int AlbumId { get; set; }
    }

    [DataContract]
    public class GetAlbums : FilterLimitSortPropertyBase<AlbumFilter> { }

    [DataContract]
    public class GetArtistDetails : PropertyBase {
        [DataMember(Name = "artistid")]
        public int ArtistId { get; set; }
    }

    [DataContract]
    public class GetArtists : FilterLimitSortPropertyBase<ArtistFilter> {
        [DataMember(Name = "albumartistsonly", EmitDefaultValue = false)]
        public bool? AlbumArtistsOnly { get; set; }
    }
    [DataContract]
    public class GetGenres : LimitSortPropertyBase { }
    [DataContract]
    public class GetRecentlyAddedAlbums : LimitSortPropertyBase { }
    [DataContract]
    public class GetRecentlyAddedSongs : LimitSortPropertyBase {
        [DataMember(Name = "albumlimit", EmitDefaultValue = false)]
        public int? AlbumLimit { get; set; }
    }
    [DataContract]
    public class GetRecentlyPlayedAlbums : LimitSortPropertyBase { }
    [DataContract]
    public class GetRecentlyPlayedSongs : LimitSortPropertyBase { }
    [DataContract]
    public class GetSongDetails : PropertyBase {
        [DataMember(Name = "songid")]
        public int SongId { get; set; }
    }
    [DataContract]
    public class GetSongs : FilterLimitSortPropertyBase<SongFilter> { }
    [DataContract]
    public class Scan {
        [DataMember(Name = "directory", EmitDefaultValue = false)]
        public string Directory { get; set; }
    }
    [DataContract]
    public class SongAlbumBase {
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }
        [DataMember(Name = "artist", EmitDefaultValue = false)]
        public List<string> Artist { get; set; }
        [DataMember(Name = "genre", EmitDefaultValue = false)]
        public List<string> Genre { get; set; }
        [DataMember(Name = "year", EmitDefaultValue = false)]
        public int? Year { get; set; }
        [DataMember(Name = "rating", EmitDefaultValue = false)]
        public int? Rating { get; set; }
    }

    [DataContract]
    public class SetSongDetails : SongAlbumBase {
        [DataMember(Name = "songid")]
        public int SongId { get; set; }
        [DataMember(Name = "albumartist", EmitDefaultValue = false)]
        public List<string> AlbumArtist { get; set; }
        [DataMember(Name = "album", EmitDefaultValue = false)]
        public string Album { get; set; }
        [DataMember(Name = "track", EmitDefaultValue = false)]
        public int? Track { get; set; }
        [DataMember(Name = "disc", EmitDefaultValue = false)]
        public int? Disc { get; set; }
        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public int? Duration { get; set; }
        [DataMember(Name = "comment", EmitDefaultValue = false)]
        public string Comment { get; set; }
        [DataMember(Name = "musicbrainztrackid", EmitDefaultValue = false)]
        public string MusicBrainzTrackId { get; set; }
        [DataMember(Name = "musicbrainzartistid", EmitDefaultValue = false)]
        public string MusicBrainzArtistId { get; set; }
        [DataMember(Name = "musicbrainzalbumid", EmitDefaultValue = false)]
        public string MusicBrainzAlbumId { get; set; }
        [DataMember(Name = "musicbrainzalbumartistid", EmitDefaultValue = false)]
        public string MusicBrainzAlbumArtistId { get; set; }
    }
    [DataContract]
    public class SetAlbumDetails : SongAlbumBase {
        [DataMember(Name = "albumid")]
        public int AlbumId { get; set; }
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }
        [DataMember(Name = "theme", EmitDefaultValue = false)]
        public List<string> Theme { get; set; }
        [DataMember(Name = "mood", EmitDefaultValue = false)]
        public List<string> Mood { get; set; }
        [DataMember(Name = "style", EmitDefaultValue = false)]
        public List<string> Style { get; set; }
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }
        [DataMember(Name = "albumlabel", EmitDefaultValue = false)]
        public string AlbumLabel { get; set; }
    }
    [DataContract]
    public class SetArtistDetails {
        [DataMember(Name = "artistid")]
        public int ArtistId { get; set; }
        [DataMember(Name = "artist", EmitDefaultValue = false)]
        public string Artist { get; set; }
        [DataMember(Name = "instrument", EmitDefaultValue = false)]
        public List<string> Instrument { get; set; }
        [DataMember(Name = "style", EmitDefaultValue = false)]
        public List<string> Style { get; set; }
        [DataMember(Name = "mood", EmitDefaultValue = false)]
        public List<string> Mood { get; set; }
        [DataMember(Name = "born", EmitDefaultValue = false)]
        public string Born { get; set; }
        [DataMember(Name = "formed", EmitDefaultValue = false)]
        public string Formed { get; set; }
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }
        [DataMember(Name = "genre", EmitDefaultValue = false)]
        public List<string> Genre { get; set; }
        [DataMember(Name = "died", EmitDefaultValue = false)]
        public string Died { get; set; }
        [DataMember(Name = "disbanded", EmitDefaultValue = false)]
        public string Disbanded { get; set; }
        [DataMember(Name = "yearsactive", EmitDefaultValue = false)]
        public List<string> YearsActive { get; set; }
    }

}
