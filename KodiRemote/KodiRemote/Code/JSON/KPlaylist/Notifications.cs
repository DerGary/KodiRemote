using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlaylist.Notifications {
    [DataContract]
    public abstract class PlaylistIdBase {
        [DataMember(Name = "playlistid")]
        public int PlaylistId { get; set; }
    }
    [DataContract]
    public abstract class PlaylistIdPositionBase {
        [DataMember(Name = "position")]
        public int Position { get; set; }
    }

    [DataContract]
    public class OnAdd : PlaylistIdPositionBase {
        [DataMember(Name = "item")]
        public Item Item { get; set; }
    }
    [DataContract]
    public class OnClear : PlaylistIdBase { }
    [DataContract]
    public class OnRemove : PlaylistIdPositionBase { }
}
