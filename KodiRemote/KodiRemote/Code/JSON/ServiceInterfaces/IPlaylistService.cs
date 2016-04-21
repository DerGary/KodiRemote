using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KPlaylist.Notifications;
using KodiRemote.Code.JSON.KPlaylist.Params;
using KodiRemote.Code.JSON.KPlaylist.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IPlaylistService {
        #region Notifications
        event ReceivedEventHandler<OnClear> OnClear;
        event ReceivedEventHandler<OnRemove> OnRemove;
        event ReceivedEventHandler<OnAdd> OnAdd;
        #endregion Notifications

        Task<bool> Add<T>(int playlistID, T item) where T : AddAble;
        Task<bool> Clear(int playlistID);
        Task<List<Item>> GetItems(int playlistID);
        Task<List<Playlist>> GetPlaylists();
        Task<PlaylistProperties> GetProperties(int playlistID, PlaylistField properties = null);
        Task<bool> Insert<T>(int playlistID, int position, T item) where T : AddAble;
        Task<bool> Remove(int playlistID, int position);
        Task<bool> Swap(int playlistID, int position1, int position2);
    }
}
