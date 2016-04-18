using KodiRemote.Code.JSON.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KFiles.Params {
    [DataContract]
    public class Download {
        [DataMember(Name = "path")]
        public string Path { get; set; }
    }
    [DataContract]
    public class PrepareDownload : Download { }
    [DataContract]
    public class GetDirectory {
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
        [DataMember(Name = "media", EmitDefaultValue = false)]
        public string Media { get; set; }
        [DataMember(Name = "directory", EmitDefaultValue = false)]
        public string Directory { get; set; }
        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public Sort Sort { get; set; }
    }
    [DataContract]
    public class GetFileDetails {
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
        [DataMember(Name = "media")]
        public string Media { get; set; }
        [DataMember(Name = "file")]
        public string File { get; set; }
    }
    [DataContract]
    public class GetSources {
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public Sort Sort { get; set; }
        [DataMember(Name = "media")]
        public string Media { get; set; }
    }
}
