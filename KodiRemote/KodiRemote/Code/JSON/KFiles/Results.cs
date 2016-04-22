using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KFiles.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KFiles.Results {
    [DataContract]
    public class FilesResult : CollectionResultBase {
        [DataMember(Name = "files")]
        public List<FileDetails> Files { get; set; }
    }
    [DataContract]
    public class FileResult {
        [DataMember(Name = "filedetails")]
        public FileDetails File { get; set; }
    }
    [DataContract]
    public class FileDetails {
        //public art  { get; set;}
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "file")]
        public string File { get; set; }
        [DataMember(Name = "filetype")]
        public string Filetype { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "lastmodified")]
        public string Lastmodified { get; set; }
        [DataMember(Name = "mimetype")]
        public string Mimetype { get; set; }
        [DataMember(Name = "size")]
        public int Size { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
    [DataContract]
    public class PrepareDownloadResult {
        [DataMember(Name = "details")]
        public DownloadDetails Details { get; set; }
        [DataMember(Name = "mode")]
        public string Mode { get; set; }
        [DataMember(Name = "protocol")]
        public string Protocol { get; set; }
    }
    [DataContract]
    public class DownloadDetails : Download { }

    [DataContract]
    public class SourcesResult : CollectionResultBase {

        [DataMember(Name = "sources")]
        public List<Sources> Sources { get; set; }
    }
    [DataContract]
    public class Sources {
        [DataMember(Name = "file")]
        public string File { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
    }
}
