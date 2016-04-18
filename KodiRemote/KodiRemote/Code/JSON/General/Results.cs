using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.General.Results {
    [DataContract]
    public class LibraryCollectionResultBase {
        [DataMember(Name = "limits")]
        public LimitsWithTotal Limits { get; set; }
    }
    [DataContract]
    public class GenreResult : LibraryCollectionResultBase {
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
}
