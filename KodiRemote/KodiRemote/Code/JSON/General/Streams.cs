using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General {
    [DataContract]
    public class AudioStream {
        [DataMember(Name = "channels")]
        public int Channels { get; set; }
        [DataMember(Name = "bitrate")]
        public int Bitrate { get; set; }
        [DataMember(Name = "codec")]
        public string Codec { get; set; }
        [DataMember(Name = "language")]
        public string Language { get; set; }
        [DataMember(Name = "index")]
        public int Index { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
    [DataContract]
    public class SubtitleStream {
        [DataMember(Name = "language")]
        public string Language { get; set; }
        [DataMember(Name = "index")]
        public int Index { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
    [DataContract]
    public class VideoStream {
        [DataMember(Name = "aspect")]
        public float Aspect { get; set; }
        [DataMember(Name = "codec")]
        public string Codec { get; set; }
        [DataMember(Name = "duration")]
        public int Duration { get; set; }
        [DataMember(Name = "height")]
        public int Height { get; set; }
        [DataMember(Name = "width")]
        public int Width { get; set; }
    }
}
