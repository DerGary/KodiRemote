using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KFiles.Params;
using KodiRemote.Code.JSON.KJSONRPC.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlaylist.Results {
    [DataContract]
    public class Playlist {
        [DataMember(Name = "playlistid")]
        public int PlaylistId { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }

    [DataContract]
    public class PlaylistProperties {
        [DataMember(Name = "size")]
        public int Size { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}