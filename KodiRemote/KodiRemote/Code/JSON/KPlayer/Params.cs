using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlayer.Params {
    [DataContract]
    public class PlayerID {
        public PlayerID() { }

        public PlayerID(int playerId) {
            PlayerId = playerId;
        }

        [DataMember(Name = "playerid")]
        public int PlayerId { get; set; }
    }

    [DataContract]
    public class ActivePlayer : PlayerID {
        public ActivePlayer() : base() { }
        public ActivePlayer(int playerId, IField properties) : base(playerId) {
            Properties = properties.ToList();
        }
        [DataMember(Name = "properties")]
        public List<string> Properties { get; set; }
    }

    [DataContract]
    public class PlayPause : PlayerID {
        public PlayPause() : base() { }
        public PlayPause(int playerId, ToggleEnum toggle) : base(playerId) {
            if (toggle == ToggleEnum.True) {
                Play = true;
            } else if (toggle == ToggleEnum.False) {
                Play = false;
            }
        }

        [DataMember(Name = "play", EmitDefaultValue = false)]
        public bool? Play { get; set; }
    }

    [DataContract]
    public class Speed<T> : PlayerID {
        public Speed() : base() { }
        public Speed(int playerId, T speed) : base(playerId) {
            SpeedValue = speed;
        }
        [DataMember(Name = "speed")]
        public T SpeedValue { get; set; }
    }

    [DataContract]
    public class GoTo<T> : PlayerID {
        public GoTo() : base() { }
        public GoTo(int playerId, T to) : base(playerId) {
            To = to;
        }
        [DataMember(Name = "to")]
        public T To { get; set; }
    }

    [DataContract]
    public class Value<T> : PlayerID {
        public Value() : base() { }
        public Value(int playerId, T value) : base(playerId) {
            ValueValue = value;
        }
        [DataMember(Name = "value")]
        public T ValueValue { get; set; }
    }
    [DataContract]
    public class Direction : PlayerID {
        public Direction() : base() { }
        public Direction(int playerId, string direction) : base(playerId) {
            DirectionValue = direction;
        }
        [DataMember(Name = "direction")]
        public string DirectionValue { get; set; }
    }
    [DataContract]
    public class Zoom<T> : PlayerID {
        public Zoom() : base() { }
        public Zoom(int playerId, T zoom) : base(playerId) {
            ZoomValue = zoom;
        }
        [DataMember(Name = "zoom")]
        public T ZoomValue { get; set; }
    }
    [DataContract]
    public class Stream<T> : PlayerID {
        public Stream() : base() { }
        public Stream(int playerId, T stream) : base(playerId) {
            StreamValue = stream;
        }
        [DataMember(Name = "stream")]
        public T StreamValue { get; set; }
    }
    [DataContract]
    public class Subtitle<T> : PlayerID {
        public Subtitle() : base() { }
        public Subtitle(int playerId, T subtitle, bool enable) : base(playerId) {
            SubtitleValue = subtitle;
            Enable = enable;
        }
        [DataMember(Name = "subtitle")]
        public T SubtitleValue { get; set; }
        [DataMember(Name = "enable", EmitDefaultValue = false)]
        public bool Enable { get; set; }
    }
    [DataContract]
    public class PartyMode<T> : PlayerID {
        public PartyMode() : base() { }
        public PartyMode(int playerId, T partymode) : base(playerId) {
            PartyModeValue = partymode;
        }
        [DataMember(Name = "partymode")]
        public T PartyModeValue { get; set; }
    }

    [DataContract]
    public class Repeat : PlayerID {
        public Repeat() : base() { }
        public Repeat(int playerId, string repeat) : base(playerId) {
            RepeatValue = repeat;
        }
        [DataMember(Name = "repeat")]
        public string RepeatValue { get; set; }
    }
    [DataContract]
    public class Shuffle<T> : PlayerID {
        public Shuffle() : base() { }
        public Shuffle(int playerId, T shuffle) : base(playerId) {
            ShuffleValue = shuffle;
        }
        [DataMember(Name = "shuffle")]
        public T ShuffleValue { get; set; }
    }

    [DataContract]
    public class Open<T> where T : Item {
        [DataMember(Name = "item")]
        public T Item { get; set; }
        [DataMember(Name = "options", EmitDefaultValue = false)]
        public Options Options { get; set; }
    }
    [DataContract]
    public abstract class Item {

    }
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
    [DataContract]
    public class Options {
        [DataMember(Name = "shuffled", EmitDefaultValue = false)]
        public bool? Shuffled { get; set; }
        [DataMember(Name = "repeat", EmitDefaultValue = false)]
        public string Repeat { get; set; }
        [DataMember(Name = "resume", EmitDefaultValue = false)]
        public bool? Resume { get; set; }
    }
}
