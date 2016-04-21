using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KPlaylist.Notifications;
using KodiRemote.Code.JSON.KPlaylist.Params;
using KodiRemote.Code.JSON.KPlaylist.Results;
using KodiRemote.Code.JSON.KPlaylist;
using KodiRemote.Code.Utils;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class PlaylistWebSocketService : WebSocketServiceBase, IPlaylistService {
        #region Notifications
        public event ReceivedEventHandler<OnAdd> OnAdd;
        public event ReceivedEventHandler<OnClear> OnClear;
        public event ReceivedEventHandler<OnRemove> OnRemove;
        #endregion Notifications

        public PlaylistWebSocketService(WebSocketHelper helper) : base(helper) {
        }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.Add
                || methods[guid] == Method.Clear
                || methods[guid] == Method.Insert
                || methods[guid] == Method.Remove
                || methods[guid] == Method.Swap) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetItems) {
                DeserializeMessageAndTriggerTask<List<Item>>(guid, message);
            } else if (methods[guid] == Method.GetPlaylists) {
                DeserializeMessageAndTriggerTask<List<Playlist>>(guid, message);
            } else if (methods[guid] == Method.GetProperties) {
                DeserializeMessageAndTriggerTask<PlaylistProperties>(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == Notification.OnAdd.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnAdd, notification);
            } else if (method == Notification.OnClear.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnClear, notification);
            } else if (method == Notification.OnRemove.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnRemove, notification);
            }
        }

        public Task<bool> Add<T>(int playlistID, T item) where T : AddAble {
            return SendRequest<bool, Add<T>>(Method.Add, new Add<T> { Item = item, PlaylistId = playlistID });
        }

        public Task<bool> Clear(int playlistID) {
            return SendRequest<bool, Clear>(Method.Clear, new Clear { PlaylistId = playlistID });
        }

        public Task<List<Item>> GetItems(int playlistID) {
            return SendRequest<List<Item>, GetItems>(Method.GetItems, new GetItems { PlaylistId = playlistID });
        }

        public Task<List<Playlist>> GetPlaylists() {
            return SendRequest<List<Playlist>>(Method.GetPlaylists);
        }

        public Task<PlaylistProperties> GetProperties(int playlistID, PlaylistField properties = null) {
            return SendRequest<PlaylistProperties, GetProperties>(Method.GetProperties, new GetProperties { PlaylistId = playlistID, Properties = properties?.ToList() });
        }

        public Task<bool> Insert<T>(int playlistID, int position, T item) where T : AddAble {
            return SendRequest<bool, Insert<T>>(Method.Insert, new Insert<T> { PlaylistId = playlistID, Item = item, Position = position });
        }

        public Task<bool> Remove(int playlistID, int position) {
            return SendRequest<bool, Remove>(Method.Remove, new Remove { PlaylistId = playlistID, Position = position });
        }

        public Task<bool> Swap(int playlistID, int position1, int position2) {
            return SendRequest<bool, Swap>(Method.Swap, new Swap { PlaylistId = playlistID, Position1 = position1, Position2 = position2 });
        }
    }
}
