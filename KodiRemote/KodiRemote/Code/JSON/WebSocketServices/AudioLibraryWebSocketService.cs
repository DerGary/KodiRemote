using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Filter;
using KodiRemote.Code.JSON.KAudioLibrary.Notifications;
using KodiRemote.Code.JSON.KAudioLibrary.Params;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KAudioLibrary;
using KodiRemote.Code.JSON.General.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class AudioLibraryWebSocketService : WebSocketServiceBase, IAudioLibraryService {
        #region Notifications
        public event ReceivedEventHandler OnCleanFinished;
        public event ReceivedEventHandler OnCleanStarted;
        public event ReceivedEventHandler<Item> OnRemove;
        public event ReceivedEventHandler OnScanFinished;
        public event ReceivedEventHandler OnScanStarted;
        public event ReceivedEventHandler<Item> OnUpdate;
        #endregion Notifications
        #region Events
        public event ReceivedEventHandler<bool> CleanReceived;
        public event ReceivedEventHandler<bool> ExportReceived;
        public event ReceivedEventHandler<Album> GetAlbumDetailsReceived;
        public event ReceivedEventHandler<AlbumResult> GetAlbumsReceived;
        public event ReceivedEventHandler<Artist> GetArtistDetailsReceived;
        public event ReceivedEventHandler<ArtistResult> GetArtistsReceived;
        public event ReceivedEventHandler<GenreResult> GetGenresReceived;
        public event ReceivedEventHandler<AlbumResult> GetRecentlyAddedAlbumsReceived;
        public event ReceivedEventHandler<SongResult> GetRecentlyAddedSongsReceived;
        public event ReceivedEventHandler<AlbumResult> GetRecentlyPlayedAlbumsReceived;
        public event ReceivedEventHandler<SongResult> GetRecentlyPlayedSongsReceived;
        public event ReceivedEventHandler<Song> GetSongDetailsReceived;
        public event ReceivedEventHandler<SongResult> GetSongsReceived;
        public event ReceivedEventHandler<bool> ScanReceived;
        public event ReceivedEventHandler<bool> SetAlbumDetailsReceived;
        public event ReceivedEventHandler<bool> SetArtistDetailsReceived;
        public event ReceivedEventHandler<bool> SetSongDetailsReceived;
        #endregion Events

        public AudioLibraryWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == Method.Clean.ToInt()) {
                DeserializeMessageAndTriggerEvent(CleanReceived, message);
            } else if (id == Method.Export.ToInt()) {
                DeserializeMessageAndTriggerEvent(ExportReceived, message);
            } else if (id == Method.GetAlbumDetails.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetAlbumDetailsReceived, message);
            } else if (id == Method.GetAlbums.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetAlbumsReceived, message);
            } else if (id == Method.GetArtistDetails.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetArtistDetailsReceived, message);
            } else if (id == Method.GetArtists.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetArtistsReceived, message);
            } else if (id == Method.GetGenres.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetGenresReceived, message);
            } else if (id == Method.GetRecentlyAddedAlbums.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetRecentlyAddedAlbumsReceived, message);
            } else if (id == Method.GetRecentlyAddedSongs.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetRecentlyAddedSongsReceived, message);
            } else if (id == Method.GetRecentlyPlayedAlbums.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetRecentlyPlayedAlbumsReceived, message);
            } else if (id == Method.GetRecentlyPlayedSongs.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetRecentlyPlayedSongsReceived, message);
            } else if (id == Method.GetSongDetails.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetSongDetailsReceived, message);
            } else if (id == Method.GetSongs.ToInt()) {
                DeserializeMessageAndTriggerEvent(GetSongsReceived, message);
            } else if (id == Method.Scan.ToInt()) {
                DeserializeMessageAndTriggerEvent(ScanReceived, message);
            } else if (id == Method.SetAlbumDetails.ToInt()) {
                DeserializeMessageAndTriggerEvent(SetAlbumDetailsReceived, message);
            } else if (id == Method.SetArtistDetails.ToInt()) {
                DeserializeMessageAndTriggerEvent(SetArtistDetailsReceived, message);
            } else if (id == Method.SetSongDetails.ToInt()) {
                DeserializeMessageAndTriggerEvent(SetSongDetailsReceived, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == Notification.OnCleanFinished.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnCleanFinished, notification);
            } else if (method == Notification.OnCleanStarted.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnCleanStarted, notification);
            } else if (method == Notification.OnRemove.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnRemove, notification);
            } else if (method == Notification.OnScanFinished.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnScanFinished, notification);
            } else if (method == Notification.OnScanStarted.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnScanStarted, notification);
            } else if (method == Notification.OnUpdate.ToString()) {
                DeserializeNotificationAndTriggerEvent(OnUpdate, notification);
            }
        }


        public void Clean() {
            SendRequest(Method.Clean);
        }

        public void Export(string path = null) {
            SendRequest(Method.Export, new Export { Options = new PathOption { Path = path } });
        }

        public void Export(bool overwrite = false, bool images = false) {
            SendRequest(Method.Export, new Export { Options = new ExportOption { Images = images, Overwrite = overwrite } });
        }

        public void GetAlbumDetails(int albumID, AlbumField properties = null) {
            SendRequest(Method.GetAlbumDetails, new GetAlbumDetails { AlbumId = albumID, Properties = properties?.ToList() });
        }

        public void GetAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null, AlbumFilter filter = null) {
            SendRequest(Method.GetAlbums, new GetAlbums { Properties = properties?.ToList(), Filter = filter, Limits = limits, Sort = sort });
        }

        public void GetArtistDetails(int artistID, ArtistField properties = null) {
            SendRequest(Method.GetArtistDetails, new GetArtistDetails { Properties = properties?.ToList(), ArtistId = artistID });
        }

        public void GetArtists(ArtistField properties = null, bool? albumartistsonly = null, ArtistFilter filter = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetArtists, new GetArtists { Properties = properties?.ToList(), AlbumArtistsOnly = albumartistsonly, Filter = filter, Limits = limits, Sort = sort });
        }

        public void GetGenres(GenreField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetGenres, new GetGenres { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public void GetRecentlyAddedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetRecentlyAddedAlbums, new GetRecentlyAddedAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public void GetRecentlyAddedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetRecentlyAddedSongs, new GetRecentlyAddedSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, AlbumLimit = albumlimit });
        }

        public void GetRecentlyPlayedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetRecentlyPlayedAlbums, new GetRecentlyPlayedAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public void GetRecentlyPlayedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetRecentlyPlayedSongs, new GetRecentlyPlayedSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, AlbumLimit = albumlimit });
        }

        public void GetSongDetails(int songId, SongField properties = null) {
            SendRequest(Method.GetSongDetails, new GetSongDetails { Properties = properties?.ToList(), SongId = songId });
        }

        public void GetSongs(SongField properties = null, Limits limits = null, Sort sort = null, SongFilter filter = null) {
            SendRequest(Method.GetSongs, new GetSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public void Scan(string directory = null) {
            SendRequest(Method.Scan, new Scan { Directory = directory });
        }

        public void SetAlbumDetails(SetAlbumDetails album) {
            SendRequest(Method.SetAlbumDetails, album);
        }

        public void SetArtistDetails(SetArtistDetails artist) {
            SendRequest(Method.SetArtistDetails, artist);
        }

        public void SetSongDetails(SetSongDetails song) {
            SendRequest(Method.SetSongDetails, song);
        }
    }
}
