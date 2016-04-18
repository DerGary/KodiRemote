using KodiRemote.Code.JSON.General.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAudioLibrary.Filter {
    [DataContract]
    public class AlbumFilter : FilterBase {
        [DataMember(Name = "artistid", EmitDefaultValue = false)]
        public int? ArtistId { get; set; }
        [DataMember(Name = "artist", EmitDefaultValue = false)]
        public string Artist { get; set; }
    }
    [DataContract]
    public class ArtistFilter : FilterBase {
        [DataMember(Name = "albumid", EmitDefaultValue = false)]
        public int? AlbumId { get; set; }
        [DataMember(Name = "album", EmitDefaultValue = false)]
        public string Album { get; set; }
        [DataMember(Name = "songid", EmitDefaultValue = false)]
        public int? SongId { get; set; }
    }
    public class SongFilter : AlbumFilter {
        [DataMember(Name = "albumid", EmitDefaultValue = false)]
        public int? AlbumId { get; set; }
        [DataMember(Name = "album", EmitDefaultValue = false)]
        public string Album { get; set; }
    }
}