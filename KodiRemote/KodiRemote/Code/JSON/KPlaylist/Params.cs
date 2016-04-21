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

namespace KodiRemote.Code.JSON.KPlaylist.Params {
    [DataContract]
    public abstract class PlaylistIdBase {
        [DataMember(Name = "playlistid")]
        public int PlaylistId { get; set; }
    }

    [DataContract]
    public abstract class PlaylistIdPositionBase : PlaylistIdBase {
        [DataMember(Name = "position")]
        public int Position { get; set; }
    }

    [DataContract]
    public abstract class AddAble { }

    [DataContract]
    public class Add<T> : PlaylistIdBase where T : AddAble {
        [DataMember(Name = "item")]
        public T Item { get; set; }
    }

    [DataContract]
    public class File : AddAble {
        [DataMember(Name = "file")]
        public string FileValue { get; set; }
    }

    [DataContract]
    public class Directory : AddAble {
        [DataMember(Name = "directory")]
        public string DirectoryValue { get; set; }
    }

    [DataContract]
    public class Movie : AddAble {
        [DataMember(Name = "movieid")]
        public int? MovieId { get; set; }
    }

    [DataContract]
    public class Episode : AddAble {
        [DataMember(Name = "episodeid")]
        public int? EpisodeId { get; set; }
    }

    [DataContract]
    public class MusicVideo : AddAble {
        [DataMember(Name = "musicvideoid")]
        public int? MusicVideoId { get; set; }
    }

    [DataContract]
    public class Artist : AddAble {
        [DataMember(Name = "artistid")]
        public int? ArtistId { get; set; }
    }

    [DataContract]
    public class Album : AddAble {
        [DataMember(Name = "albumid")]
        public int? AlbumId { get; set; }
    }

    [DataContract]
    public class Song : AddAble {
        [DataMember(Name = "songid")]
        public int? SongId { get; set; }
    }

    [DataContract]
    public class Genre : AddAble {
        [DataMember(Name = "genreid")]
        public int? GenreId { get; set; }
    }

    [DataContract]
    public class Clear : PlaylistIdBase { }

    [DataContract]
    public class GetItems : PlaylistIdBase { }

    [DataContract]
    public class GetProperties : PropertyBase {
        [DataMember(Name = "playlistid")]
        public int PlaylistId { get; set; }
    }

    [DataContract]
    public class Insert<T> : PlaylistIdPositionBase where T : AddAble {
        [DataMember(Name = "item")]
        public T Item { get; set; }
    }

    [DataContract]
    public class Remove : PlaylistIdPositionBase { }

    [DataContract]
    public class Swap : PlaylistIdBase {
        [DataMember(Name = "position1")]
        public int Position1 { get; set; }
        [DataMember(Name = "position2")]
        public int Position2 { get; set; }
    }
}
