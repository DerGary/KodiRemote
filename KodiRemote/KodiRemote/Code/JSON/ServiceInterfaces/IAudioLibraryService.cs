using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Filter;
using KodiRemote.Code.JSON.KAudioLibrary.Notifications;
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
        event ReceivedEventHandler<Item> OnRemove;
        event ReceivedEventHandler OnScanFinished;
        event ReceivedEventHandler OnScanStarted;
        event ReceivedEventHandler<Item> OnUpdate;
        #endregion Notifications

        Task<bool> Clean();
        Task<bool> Export(string path = null);
        Task<bool> Export(bool overwrite = false, bool images = false);
        Task<Album> GetAlbumDetails(int albumID, AlbumField properties = null);
        Task<AlbumResult> GetAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null, AlbumFilter filter = null);
        Task<Artist> GetArtistDetails(int artistID, ArtistField properties = null);
        Task<ArtistResult> GetArtists(ArtistField properties = null, bool? albumartistsonly = null, ArtistFilter filter = null, Limits limits = null, Sort sort = null);
        Task<GenreResult> GetGenres(GenreField properties = null, Limits limits = null, Sort sort = null);
        Task<AlbumResult> GetRecentlyAddedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null);
        Task<SongResult> GetRecentlyAddedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null);
        Task<AlbumResult> GetRecentlyPlayedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null);
        Task<SongResult> GetRecentlyPlayedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null);
        Task<Song> GetSongDetails(int songID, SongField properties = null);
        Task<SongResult> GetSongs(SongField properties = null, Limits limits = null, Sort sort = null, SongFilter filter = null);
        Task<bool> Scan(string directory = null);
        Task<bool> SetAlbumDetails(SetAlbumDetails album);
        Task<bool> SetArtistDetails(SetArtistDetails artist);
        Task<bool> SetSongDetails(SetSongDetails song);
    }
}
