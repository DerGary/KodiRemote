using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlayer.Results {


    [DataContract]
    public class Player {
        [DataMember(Name = "playerid")]
        public int PlayerId { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract]
    public class Speed {
        [DataMember(Name = "speed")]
        public int CurrentSpeed { get; set; }
    }

    [DataContract]
    public class Seek {
        [DataMember(Name = "percentage")]
        public float Percentage { get; set; }
        [DataMember(Name = "time")]
        public Time Time { get; set; }
        [DataMember(Name = "totaltime")]
        public Time Totaltime { get; set; }
    }
    [DataContract]
    public class Properties {
        [DataMember(Name = "audiostreams")]
        public AudioStream[] Audiostreams { get; set; }
        [DataMember(Name = "canchangespeed")]
        public bool CanChangeSpeed { get; set; }
        [DataMember(Name = "canmove")]
        public bool CanMove { get; set; }
        [DataMember(Name = "canrepeat")]
        public bool CanRepeat { get; set; }
        [DataMember(Name = "canrotate")]
        public bool CanRotate { get; set; }
        [DataMember(Name = "canseek")]
        public bool CanSeek { get; set; }
        [DataMember(Name = "canshuffle")]
        public bool CanShuffle { get; set; }
        [DataMember(Name = "canzoom")]
        public bool CanZoom { get; set; }
        [DataMember(Name = "currentaudiostream")]
        public AudioStream CurrentAudiostream { get; set; }
        [DataMember(Name = "currentsubtitle")]
        public SubtitleStream CurrentSubtitle { get; set; }
        [DataMember(Name = "live")]
        public bool Live { get; set; }
        [DataMember(Name = "partymode")]
        public bool Partymode { get; set; }
        [DataMember(Name = "percentage")]
        public float Percentage { get; set; }
        [DataMember(Name = "playlistid")]
        public int PlaylistId { get; set; }
        [DataMember(Name = "position")]
        public int Position { get; set; }
        [DataMember(Name = "repeat")]
        public string Repeat { get; set; }
        [DataMember(Name = "shuffled")]
        public bool Shuffled { get; set; }
        [DataMember(Name = "speed")]
        public float Speed { get; set; }
        [DataMember(Name = "subtitleenabled")]
        public bool SubtitleEnabled { get; set; }
        [DataMember(Name = "subtitles")]
        public SubtitleStream[] Subtitles { get; set; }
        [DataMember(Name = "time")]
        public Time Time { get; set; }
        [DataMember(Name = "totaltime")]
        public Time TotalTime { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }


}
