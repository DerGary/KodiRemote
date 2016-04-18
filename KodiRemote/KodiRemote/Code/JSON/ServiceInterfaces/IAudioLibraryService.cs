using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KAudioLibrary.Filter;
using KodiRemote.Code.JSON.KAudioLibrary.Notifications;
using KodiRemote.Code.JSON.KAudioLibrary.Params;
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


        event ReceivedEventHandler<bool> CleanReceived;
        event ReceivedEventHandler<bool> ExportReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.Album> GetAlbumDetailsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.AlbumResult> GetAlbumsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.Artist> GetArtistDetailsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.ArtistResult> GetArtistsReceived;
        event ReceivedEventHandler<GenreResult> GetGenresReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.AlbumResult> GetRecentlyAddedAlbumsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.SongResult> GetRecentlyAddedSongsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.AlbumResult> GetRecentlyPlayedAlbumsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.SongResult> GetRecentlyPlayedSongsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.Song> GetSongDetailsReceived;
        event ReceivedEventHandler<KAudioLibrary.Results.SongResult> GetSongsReceived;
        event ReceivedEventHandler<bool> ScanReceived;
        event ReceivedEventHandler<bool> SetAlbumDetailsReceived;
        event ReceivedEventHandler<bool> SetArtistDetailsReceived;
        event ReceivedEventHandler<bool> SetSongDetailsReceived;

        void Clean();
        void Export(string path = null);
        void Export(bool overwrite = false, bool images = false);
        void GetAlbumDetails(int albumID, AlbumField properties = null);
        void GetAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null, AlbumFilter filter = null);
        void GetArtistDetails(int artistID, ArtistField properties = null);
        void GetArtists(ArtistField properties = null, bool? albumartistsonly = null, ArtistFilter filter = null, Limits limits = null, Sort sort = null);
        void GetGenres(GenreField properties = null, Limits limits = null, Sort sort = null);
        void GetRecentlyAddedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null);
        void GetRecentlyAddedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null);
        void GetRecentlyPlayedAlbums(AlbumField properties = null, Limits limits = null, Sort sort = null);
        void GetRecentlyPlayedSongs(SongField properties = null, int? albumlimit = null, Limits limits = null, Sort sort = null);
        void GetSongDetails(int songID, SongField properties = null);
        void GetSongs(SongField properties = null, Limits limits = null, Sort sort = null, SongFilter filter = null);
        void Scan(string directory = null);
        void SetAlbumDetails(SetAlbumDetails album);
        void SetArtistDetails(SetArtistDetails artist);
        void SetSongDetails(SetSongDetails song);
    }
}
