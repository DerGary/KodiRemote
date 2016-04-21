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


        public AudioLibraryWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.Clean.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.Export.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetAlbumDetails.ToInt()) {
                DeserializeMessageAndTriggerTask<Album>(guid, message);
            } else if (methods[guid] == Method.GetAlbums.ToInt()) {
                DeserializeMessageAndTriggerTask<AlbumResult>(guid, message);
            } else if (methods[guid] == Method.GetArtistDetails.ToInt()) {
                DeserializeMessageAndTriggerTask<Artist>(guid, message);
            } else if (methods[guid] == Method.GetArtists.ToInt()) {
                DeserializeMessageAndTriggerTask<ArtistResult>(guid, message);
            } else if (methods[guid] == Method.GetGenres.ToInt()) {
                DeserializeMessageAndTriggerTask<GenreResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedAlbums.ToInt()) {
                DeserializeMessageAndTriggerTask<AlbumResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedSongs.ToInt()) {
                DeserializeMessageAndTriggerTask<SongResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyPlayedAlbums.ToInt()) {
                DeserializeMessageAndTriggerTask<AlbumResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyPlayedSongs.ToInt()) {
                DeserializeMessageAndTriggerTask<SongResult>(guid, message);
            } else if (methods[guid] == Method.GetSongDetails.ToInt()) {
                DeserializeMessageAndTriggerTask<Song>(guid, message);
            } else if (methods[guid] == Method.GetSongs.ToInt()) {
                DeserializeMessageAndTriggerTask<SongResult>(guid, message);
            } else if (methods[guid] == Method.Scan.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.SetAlbumDetails.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.SetArtistDetails.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.SetSongDetails.ToInt()) {
                DeserializeMessageAndTriggerTask(guid, message);
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

        public Task<bool> Clean() {
            return SendRequest<bool>(Method.Clean);
        }

        public Task<bool> Export(string path = null) {
            return SendRequest<bool, Export<PathOption>>(Method.Export, new Export<PathOption> { Options = new PathOption { Path = path } });
        }

        public Task<bool> Export(bool overwrite = false, bool images = false) {
            return SendRequest<bool, Export<ExportOption>>(Method.Export, new Export<ExportOption> { Options = new ExportOption { Images = images, Overwrite = overwrite } });
        }

        public Task<Album> GetAlbumDetails(int albumID, AlbumField properties = null) {
            return SendRequest<Album, GetAlbumDetails>(Method.GetAlbumDetails, new GetAlbumDetails { AlbumId = albumID, Properties = properties?.ToList() });
        }

        public Task<AlbumResult> GetAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null, AlbumFilter filter = null) {
            return SendRequest<AlbumResult, GetAlbums>(Method.GetAlbums, new GetAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<Artist> GetArtistDetails(int artistID, ArtistField properties = null) {
            throw new NotImplementedException();
        }

        public Task<ArtistResult> GetArtists(ArtistField properties = null, bool? albumartistsonly = null, ArtistFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<ArtistResult, GetArtists>(Method.GetArtists, new GetArtists { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter, AlbumArtistsOnly = albumartistsonly });
        }

        public Task<GenreResult> GetGenres(GenreField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<GenreResult, GetGenres>(Method.GetGenres, new GetGenres { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<AlbumResult> GetRecentlyAddedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<AlbumResult, GetRecentlyAddedAlbums>(Method.GetRecentlyAddedAlbums, new GetRecentlyAddedAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<SongResult> GetRecentlyAddedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null) {
            return SendRequest<SongResult, GetRecentlyAddedSongs>(Method.GetRecentlyAddedSongs, new GetRecentlyAddedSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, AlbumLimit = albumlimit });
        }

        public Task<AlbumResult> GetRecentlyPlayedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<AlbumResult, GetRecentlyPlayedAlbums>(Method.GetRecentlyPlayedAlbums, new GetRecentlyPlayedAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<SongResult> GetRecentlyPlayedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null) {
            return SendRequest<SongResult, GetRecentlyPlayedSongs>(Method.GetRecentlyPlayedSongs, new GetRecentlyPlayedSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, AlbumLimit = albumlimit });
        }

        public Task<Song> GetSongDetails(int songID, SongField properties = null) {
            return SendRequest<Song, GetSongDetails>(Method.GetSongDetails, new GetSongDetails { Properties = properties?.ToList(), SongId = songID });
        }

        public Task<SongResult> GetSongs(SongField properties = null, Limits limits = null, Sort sort = null, SongFilter filter = null) {
            return SendRequest<SongResult, GetSongs>(Method.GetSongs, new GetSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<bool> Scan(string directory = null) {
            return SendRequest<bool, Scan>(Method.Scan, new Scan { Directory = directory });
        }

        public Task<bool> SetAlbumDetails(SetAlbumDetails album) {
            return SendRequest<bool, SetAlbumDetails>(Method.SetAlbumDetails, album);
        }

        public Task<bool> SetArtistDetails(SetArtistDetails artist) {
            return SendRequest<bool, SetArtistDetails>(Method.SetArtistDetails, artist);
        }

        public Task<bool> SetSongDetails(SetSongDetails song) {
            return SendRequest<bool, SetSongDetails>(Method.SetSongDetails, song);
        }
    }
}
