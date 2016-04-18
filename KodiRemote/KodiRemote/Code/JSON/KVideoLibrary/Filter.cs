using KodiRemote.Code.JSON.General.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KVideoLibrary.Filter {
    [DataContract]
    public class VideoLibraryFilterBase : FilterBase {
        [DataMember(Name = "year", EmitDefaultValue = false)]
        public int Year { get; set; }
        [DataMember(Name = "studio", EmitDefaultValue = false)]
        public string Studio { get; set; }
    }
    [DataContract]
    public abstract class VideoFilterBase : VideoLibraryFilterBase {
        [DataMember(Name = "actor", EmitDefaultValue = false)]
        public string Actor { get; set; }
    }

    [DataContract]
    public class TVShowFilter : VideoLibraryFilterBase { }

    [DataContract]
    public class MusicVideoFilter : VideoLibraryFilterBase {
        [DataMember(Name = "artist", EmitDefaultValue = false)]
        public string Artist { get; set; }
        [DataMember(Name = "director", EmitDefaultValue = false)]
        public string Director { get; set; }
    }

    [DataContract]
    public class MovieFilter : VideoFilterBase {
        [DataMember(Name = "director", EmitDefaultValue = false)]
        public string Director { get; set; }
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }
        [DataMember(Name = "setid", EmitDefaultValue = false)]
        public int? SetId { get; set; }
        [DataMember(Name = "set", EmitDefaultValue = false)]
        public string Set { get; set; }
        [DataMember(Name = "tag", EmitDefaultValue = false)]
        public string Tag { get; set; }
    }
}