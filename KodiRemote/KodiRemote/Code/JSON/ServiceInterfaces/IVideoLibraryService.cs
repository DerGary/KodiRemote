using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
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
        event ReceivedEventHandler<Item> OnRemove;
        event ReceivedEventHandler OnScanFinished;
        event ReceivedEventHandler OnScanStarted;
        event ReceivedEventHandler<UpdateItem> OnUpdate;
        #endregion Notifications


        event ReceivedEventHandler<bool> CleanReceived;
        event ReceivedEventHandler<bool> ExportReceived;
        event ReceivedEventHandler<Episode> GetEpisodeDetailsReceived;
        event ReceivedEventHandler<List<Episode>> GetEpisodesReceived;
        event ReceivedEventHandler<List<Genre>> GetGenresReceived;
        event ReceivedEventHandler<Movie> GetMovieDetailsReceived;
        event ReceivedEventHandler<MovieSetDetails> GetMovieSetDetailsReceived;
        event ReceivedEventHandler<List<MovieSet>> GetMovieSetsReceived;
        event ReceivedEventHandler<List<Movie>> GetMoviesReceived;
        event ReceivedEventHandler<MusicVideo> GetMusicVideoDetailsReceived;
        event ReceivedEventHandler<List<MusicVideo>> GetMusicVideosReceived;
        event ReceivedEventHandler<List<Episode>> GetRecentlyAddedEpisodesReceived;
        event ReceivedEventHandler<List<Movie>> GetRecentlyAddedMoviesReceived;
        event ReceivedEventHandler<List<MusicVideo>> GetRecentlyAddedMusicVideosReceived;
        event ReceivedEventHandler<List<TvShowSeason>> GetSeasonsReceived;
        event ReceivedEventHandler<TvShow> GetTVShowDetailsReceived;
        event ReceivedEventHandler<List<TvShow>> GetTVShowsReceived;
        event ReceivedEventHandler<bool> RemoveEpisodeReceived;
        event ReceivedEventHandler<bool> RemoveMovieReceived;
        event ReceivedEventHandler<bool> RemoveMusicVideoReceived;
        event ReceivedEventHandler<bool> RemoveTVShowReceived;
        event ReceivedEventHandler<bool> ScanReceived;
        event ReceivedEventHandler<bool> SetEpisodeDetailsReceived;
        event ReceivedEventHandler<bool> SetMovieDetailsReceived;
        event ReceivedEventHandler<bool> SetMusicVideoDetailsReceived;
        event ReceivedEventHandler<bool> SetTVShowDetailsReceived;

        void Clean();
        void Export(string path = null);
        void Export(bool overwrite = false, bool actorthumbs = false, bool images = false);
        void GetEpisodeDetails(int episodeId, EpisodeField properties = null);
        void GetEpisodes(EpisodeField properties = null, int? tvShowId = null, int? season = null, Limits limits = null, Sort sort = null);
        void GetGenres(TypeEnum type, GenreField properties = null, Limits limits = null, Sort sort = null);
        void GetMovieDetails(int movieId, MovieField properties = null);
        void GetMovieSetDetails(int setId, MovieSetField properties = null, MovieField movieProperties = null, Limits movieLimits = null, Sort movieSort = null);
        void GetMovieSets(MovieSetField properties = null, Limits limits = null, Sort sort = null);
        void GetMovies(MovieField properties = null, MovieFilter filter = null, Limits limits = null, Sort sort = null);
        void GetMusicVideoDetails(int musicvideoId, MusicVideoField properties = null);
        void GetMusicVideos(MusicVideoField properties = null, MusicVideoFilter filter = null, Limits limits = null, Sort sort = null);
        void GetRecentlyAddedEpisodes(EpisodeField properties = null, Limits limits = null, Sort sort = null);
        void GetRecentlyAddedMovies(MovieField properties = null, Limits limits = null, Sort sort = null);
        void GetRecentlyAddedMusicVideos(MusicVideoField properties = null, Limits limits = null, Sort sort = null);
        void GetSeasons(int tvShowId, SeasonField properties = null, Limits limits = null, Sort sort = null);
        void GetTVShowDetails(int tvShowId, TVShowField properties = null);
        void GetTVShows(TVShowField properties = null, TVShowFilter filter = null, Limits limits = null, Sort sort = null);
        void RemoveEpisode(int episodeId);
        void RemoveMovie(int movieId);
        void RemoveMusicVideo(int musicVideoId);
        void RemoveTVShow(int tvShowId);
        void Scan(string directory = null);
        void SetEpisodeDetails(EpisodeDetails details);
        void SetMovieDetails(MovieDetails details);
        void SetMusicVideoDetails(MusicVideoDetails details);
        void SetTVShowDetails(TVShowDetails details);
    }
}
