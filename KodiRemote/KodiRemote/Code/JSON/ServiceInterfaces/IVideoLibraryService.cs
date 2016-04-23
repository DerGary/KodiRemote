using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KVideoLibrary.Filter;
using KodiRemote.Code.JSON.KVideoLibrary.Notifications;
using KodiRemote.Code.JSON.KVideoLibrary.Params;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IVideoLibraryService {
        #region Notifications
        event ReceivedEventHandler OnCleanFinished;
        event ReceivedEventHandler OnCleanStarted;
        event ReceivedEventHandler<KVideoLibrary.Notifications.Item> OnRemove;
        event ReceivedEventHandler OnScanFinished;
        event ReceivedEventHandler OnScanStarted;
        event ReceivedEventHandler<UpdateItem> OnUpdate;
        #endregion Notifications

        Task<bool> Clean();
        Task<bool> Export(string path = null);
        Task<bool> Export(bool overwrite = false, bool actorthumbs = false, bool images = false);
        Task<EpisodeResult> GetEpisodeDetails(int episodeId, EpisodeField properties = null);
        Task<EpisodesResult> GetEpisodes(EpisodeField properties = null, int? tvShowId = null, int? season = null, Limits limits = null, Sort sort = null);
        Task<GenresResult> GetGenres(TypeEnum type, GenreField properties = null, Limits limits = null, Sort sort = null);
        Task<MovieResult> GetMovieDetails(int movieId, MovieField properties = null);
        Task<MovieSetDetailsResult> GetMovieSetDetails(int setId, MovieSetField properties = null, MovieField movieProperties = null, Limits movieLimits = null, Sort movieSort = null);
        Task<MovieSetsResult> GetMovieSets(MovieSetField properties = null, Limits limits = null, Sort sort = null);
        Task<MoviesResult> GetMovies(MovieField properties = null, MovieFilter filter = null, Limits limits = null, Sort sort = null);
        Task<MusicVideoResult> GetMusicVideoDetails(int musicvideoId, MusicVideoField properties = null);
        Task<MusicVideosResult> GetMusicVideos(MusicVideoField properties = null, MusicVideoFilter filter = null, Limits limits = null, Sort sort = null);
        Task<EpisodesResult> GetRecentlyAddedEpisodes(EpisodeField properties = null, Limits limits = null, Sort sort = null);
        Task<MoviesResult> GetRecentlyAddedMovies(MovieField properties = null, Limits limits = null, Sort sort = null);
        Task<MusicVideosResult> GetRecentlyAddedMusicVideos(MusicVideoField properties = null, Limits limits = null, Sort sort = null);
        Task<TVShowSeasonsResult> GetSeasons(int tvShowId, SeasonField properties = null, Limits limits = null, Sort sort = null);
        Task<TVShowResult> GetTVShowDetails(int tvShowId, TVShowField properties = null);
        Task<TVShowsResult> GetTVShows(TVShowField properties = null, TVShowFilter filter = null, Limits limits = null, Sort sort = null);
        Task<bool> RemoveEpisode(int episodeId);
        Task<bool> RemoveMovie(int movieId);
        Task<bool> RemoveMusicVideo(int musicVideoId);
        Task<bool> RemoveTVShow(int tvShowId);
        Task<bool> Scan(string directory = null);
        Task<bool> SetEpisodeDetails(KVideoLibrary.Params.SetEpisodeDetails details);
        Task<bool> SetMovieDetails(KVideoLibrary.Params.SetMovieDetails details);
        Task<bool> SetMusicVideoDetails(KVideoLibrary.Params.SetMusicVideoDetails details);
        Task<bool> SetTVShowDetails(KVideoLibrary.Params.SetTVShowDetails details);
    }
}
