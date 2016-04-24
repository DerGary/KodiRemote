﻿using KodiRemote.Code.JSON.ServiceInterfaces;
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
        public event ReceivedEventHandler<KAudioLibrary.Notifications.Item> OnRemove;
        public event ReceivedEventHandler OnScanFinished;
        public event ReceivedEventHandler OnScanStarted;
        public event ReceivedEventHandler<KAudioLibrary.Notifications.Item> OnUpdate;
        #endregion Notifications


        public AudioLibraryWebSocketService(RPCWebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.Clean
                || methods[guid] == Method.Export
                || methods[guid] == Method.Scan
                || methods[guid] == Method.SetAlbumDetails
                || methods[guid] == Method.SetArtistDetails
                || methods[guid] == Method.SetSongDetails) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetAlbumDetails) {
                DeserializeMessageAndTriggerTask<AlbumResult>(guid, message);
            } else if (methods[guid] == Method.GetAlbums) {
                DeserializeMessageAndTriggerTask<AlbumsResult>(guid, message);
            } else if (methods[guid] == Method.GetArtistDetails) {
                DeserializeMessageAndTriggerTask<ArtistResult>(guid, message);
            } else if (methods[guid] == Method.GetArtists) {
                DeserializeMessageAndTriggerTask<ArtistsResult>(guid, message);
            } else if (methods[guid] == Method.GetGenres) {
                DeserializeMessageAndTriggerTask<GenresResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedAlbums) {
                DeserializeMessageAndTriggerTask<AlbumsResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedSongs) {
                DeserializeMessageAndTriggerTask<SongsResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyPlayedAlbums) {
                DeserializeMessageAndTriggerTask<AlbumsResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyPlayedSongs) {
                DeserializeMessageAndTriggerTask<SongsResult>(guid, message);
            } else if (methods[guid] == Method.GetSongDetails) {
                DeserializeMessageAndTriggerTask<SongResult>(guid, message);
            } else if (methods[guid] == Method.GetSongs) {
                DeserializeMessageAndTriggerTask<SongsResult>(guid, message);
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

        public Task<AlbumResult> GetAlbumDetails(int albumId, AlbumField properties = null) {
            return SendRequest<AlbumResult, GetAlbumDetails>(Method.GetAlbumDetails, new GetAlbumDetails { AlbumId = albumId, Properties = properties?.ToList() });
        }

        public Task<AlbumsResult> GetAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null, AlbumFilter filter = null) {
            return SendRequest<AlbumsResult, GetAlbums>(Method.GetAlbums, new GetAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<ArtistResult> GetArtistDetails(int artistId, ArtistField properties = null) {
            return SendRequest<ArtistResult, GetArtistDetails>(Method.GetArtistDetails, new GetArtistDetails { Properties = properties?.ToList(), ArtistId = artistId });
        }

        public Task<ArtistsResult> GetArtists(ArtistField properties = null, bool? albumartistsonly = null, ArtistFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<ArtistsResult, GetArtists>(Method.GetArtists, new GetArtists { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter, AlbumArtistsOnly = albumartistsonly });
        }

        public Task<GenresResult> GetGenres(GenreField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<GenresResult, GetGenres>(Method.GetGenres, new GetGenres { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<AlbumsResult> GetRecentlyAddedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<AlbumsResult, GetRecentlyAddedAlbums>(Method.GetRecentlyAddedAlbums, new GetRecentlyAddedAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<SongsResult> GetRecentlyAddedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null) {
            return SendRequest<SongsResult, GetRecentlyAddedSongs>(Method.GetRecentlyAddedSongs, new GetRecentlyAddedSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, AlbumLimit = albumlimit });
        }

        public Task<AlbumsResult> GetRecentlyPlayedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<AlbumsResult, GetRecentlyPlayedAlbums>(Method.GetRecentlyPlayedAlbums, new GetRecentlyPlayedAlbums { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<SongsResult> GetRecentlyPlayedSongs(SongField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<SongsResult, GetRecentlyPlayedSongs>(Method.GetRecentlyPlayedSongs, new GetRecentlyPlayedSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<SongResult> GetSongDetails(int songId, SongField properties = null) {
            return SendRequest<SongResult, GetSongDetails>(Method.GetSongDetails, new GetSongDetails { Properties = properties?.ToList(), SongId = songId });
        }

        public Task<SongsResult> GetSongs(SongField properties = null, Limits limits = null, Sort sort = null, SongFilter filter = null) {
            return SendRequest<SongsResult, GetSongs>(Method.GetSongs, new GetSongs { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
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
