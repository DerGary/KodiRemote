using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Filter;
using KodiRemote.Code.JSON.KAudioLibrary.Params;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IAudioLibraryService {
        #region Notifications
        event ReceivedEventHandler OnCleanFinished;
        event ReceivedEventHandler OnCleanStarted;
        event ReceivedEventHandler<KAudioLibrary.Notifications.Item> OnRemove;
        event ReceivedEventHandler OnScanFinished;
        event ReceivedEventHandler OnScanStarted;
        event ReceivedEventHandler<KAudioLibrary.Notifications.Item> OnUpdate;
        #endregion Notifications

        Task<bool> Clean();
        Task<bool> Export(string path = null);
        Task<bool> Export(bool overwrite = false, bool images = false);
        Task<AlbumResult> GetAlbumDetails(int albumId, AlbumField properties = null);
        Task<AlbumsResult> GetAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null, AlbumFilter filter = null);
        Task<ArtistResult> GetArtistDetails(int artistId, ArtistField properties = null);
        Task<ArtistsResult> GetArtists(ArtistField properties = null, bool? albumartistsonly = null, ArtistFilter filter = null, Limits limits = null, Sort sort = null);
        Task<GenresResult> GetGenres(GenreField properties = null, Limits limits = null, Sort sort = null);
        Task<AlbumsResult> GetRecentlyAddedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null);
        Task<SongsResult> GetRecentlyAddedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null);
        Task<AlbumsResult> GetRecentlyPlayedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null);
        Task<SongsResult> GetRecentlyPlayedSongs(SongField properties = null, Limits limits = null, Sort sort = null);
        Task<SongResult> GetSongDetails(int songId, SongField properties = null);
        Task<SongsResult> GetSongs(SongField properties = null, Limits limits = null, Sort sort = null, SongFilter filter = null);
        Task<bool> Scan(string directory = null);
        Task<bool> SetAlbumDetails(SetAlbumDetails album);
        Task<bool> SetArtistDetails(SetArtistDetails artist);
        Task<bool> SetSongDetails(SetSongDetails song);
    }
}
