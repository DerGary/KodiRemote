using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlayer.Params {
    [DataContract]
    public class PlayerIdBase {
        [DataMember(Name = "playerid")]
        public int PlayerId { get; set; }
    }
    [DataContract]
    public class PlayerIdPropertyBase : PropertyBase {
        [DataMember(Name = "playerid")]
        public int PlayerId { get; set; }
    }

    [DataContract]
    public class GetItem : PlayerIdPropertyBase { }
    [DataContract]
    public class GetProperties : PlayerIdPropertyBase { }


    [DataContract]
    public class PlayPause : PlayerIdBase {
        [DataMember(Name = "play", EmitDefaultValue = false)]
        public bool? Play { get; set; }
    }

    [DataContract]
    public class SetSpeed<T> : PlayerIdBase {
        [DataMember(Name = "speed")]
        public T Speed { get; set; }
    }
    [DataContract]
    public class Stop : PlayerIdBase { }

    [DataContract]
    public class GoTo<T> : PlayerIdBase {
        [DataMember(Name = "to")]
        public T To { get; set; }
    }

    [DataContract]
    public abstract class ValuePlayerIdBase<T> : PlayerIdBase {

        [DataMember(Name = "value")]
        public T Value { get; set; }
    }

    [DataContract]
    public class Seek<T> : ValuePlayerIdBase<T> { }
    [DataContract]
    public class Move : PlayerIdBase {
        [DataMember(Name = "direction")]
        public string Direction { get; set; }
    }
    [DataContract]
    public class Rotate : ValuePlayerIdBase<string> { }

    [DataContract]
    public class Zoom<T> : PlayerIdBase {
        [DataMember(Name = "zoom")]
        public T ZoomValue { get; set; }
    }
    [DataContract]
    public class SetAudioStream<T> : PlayerIdBase {
        [DataMember(Name = "stream")]
        public T Stream { get; set; }
    }
    [DataContract]
    public class SetSubtitle<T> : PlayerIdBase {
        [DataMember(Name = "subtitle")]
        public T Subtitle { get; set; }
        [DataMember(Name = "enable", EmitDefaultValue = false)]
        public bool Enable { get; set; }
    }
    [DataContract]
    public class SetPartymode<T> : PlayerIdBase {
        [DataMember(Name = "partymode")]
        public T PartyMode { get; set; }
    }

    [DataContract]
    public class SetRepeat : PlayerIdBase {
        [DataMember(Name = "repeat")]
        public string Repeat { get; set; }
    }
    [DataContract]
    public class SetShuffle<T> : PlayerIdBase {
        [DataMember(Name = "shuffle")]
        public T Shuffle { get; set; }
    }

    [DataContract]
    public class Open<T> where T : Item {
        [DataMember(Name = "item")]
        public T Item { get; set; }
        [DataMember(Name = "options", EmitDefaultValue = false)]
        public Options Options { get; set; }
    }

    [DataContract]
    public class Options {
        [DataMember(Name = "shuffled", EmitDefaultValue = false)]
        public bool? Shuffled { get; set; }
        [DataMember(Name = "repeat", EmitDefaultValue = false)]
        public string Repeat { get; set; }
        [DataMember(Name = "resume", EmitDefaultValue = false)]
        public bool? Resume { get; set; }
    }

    [DataContract]
    public abstract class Item { }

    [DataContract]
    public class Playlist : Item {
        [DataMember(Name = "playlistid")]
        public int PlaylistId { get; set; }
        [DataMember(Name = "position")]
        public int Position { get; set; }
    }
    [DataContract]
    public class Picture : Item {
        [DataMember(Name = "path")]
        public string Path { get; set; }
        [DataMember(Name = "recursive")]
        public bool Recursive { get; set; }
    }
    [DataContract]
    public class Movie : Item {
        [DataMember(Name = "movieid")]
        public int MovieId { get; set; }
    }
    [DataContract]
    public class Episode : Item {
        [DataMember(Name = "episodeid")]
        public int EpisodeId { get; set; }
    }
    [DataContract]
    public class MusicVideo : Item {
        [DataMember(Name = "musicvideoid")]
        public int MusicVideoId { get; set; }
    }
    [DataContract]
    public class Artist : Item {
        [DataMember(Name = "artistid")]
        public int ArtistId { get; set; }
    }
    [DataContract]
    public class Album : Item {
        [DataMember(Name = "albumid")]
        public int AlbumId { get; set; }
    }
    [DataContract]
    public class Song : Item {
        [DataMember(Name = "songid")]
        public int SongId { get; set; }
    }
    [DataContract]
    public class Genre : Item {
        [DataMember(Name = "genreid")]
        public int GenreId { get; set; }
    }
    [DataContract]
    public class PartyMode : Item {
        [DataMember(Name = "partymode")]
        public string PartyModeValue { get; set; }
    }
    [DataContract]
    public class Channel : Item {
        [DataMember(Name = "channelid")]
        public int ChannelId { get; set; }
    }

}
