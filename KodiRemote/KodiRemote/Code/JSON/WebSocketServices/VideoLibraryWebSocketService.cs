using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary;
using KodiRemote.Code.JSON.KVideoLibrary.Filter;
using KodiRemote.Code.JSON.KVideoLibrary.Notifications;
using KodiRemote.Code.JSON.KVideoLibrary.Params;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.General.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class VideoLibraryWebSocketService : WebSocketServiceBase, IVideoLibraryService {
        #region Notifications
        public event ReceivedEventHandler OnCleanFinished;
        public event ReceivedEventHandler OnCleanStarted;
        public event ReceivedEventHandler<KVideoLibrary.Notifications.Item> OnRemove;
        public event ReceivedEventHandler OnScanFinished;
        public event ReceivedEventHandler OnScanStarted;
        public event ReceivedEventHandler<UpdateItem> OnUpdate;
        #endregion Notifications

        public VideoLibraryWebSocketService(RPCWebSocketHelper helper) : base(helper) { }
        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.Clean
                || methods[guid] == Method.Export
                || methods[guid] == Method.RemoveEpisode
                || methods[guid] == Method.RemoveMovie
                || methods[guid] == Method.RemoveMusicVideo
                || methods[guid] == Method.RemoveTVShow
                || methods[guid] == Method.Scan
                || methods[guid] == Method.SetEpisodeDetails
                || methods[guid] == Method.SetMovieDetails
                || methods[guid] == Method.SetMusicVideoDetails
                || methods[guid] == Method.SetTVShowDetails) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetEpisodeDetails) {
                DeserializeMessageAndTriggerTask<EpisodeResult>(guid, message);
            } else if (methods[guid] == Method.GetEpisodes) {
                DeserializeMessageAndTriggerTask<EpisodesResult>(guid, message);
            } else if (methods[guid] == Method.GetGenres) {
                DeserializeMessageAndTriggerTask<GenresResult>(guid, message);
            } else if (methods[guid] == Method.GetMovieDetails) {
                DeserializeMessageAndTriggerTask<MovieResult>(guid, message);
            } else if (methods[guid] == Method.GetMovieSetDetails) {
                DeserializeMessageAndTriggerTask<MovieSetDetailsResult>(guid, message);
            } else if (methods[guid] == Method.GetMovieSets) {
                DeserializeMessageAndTriggerTask<MovieSetsResult>(guid, message);
            } else if (methods[guid] == Method.GetMovies) {
                DeserializeMessageAndTriggerTask<MoviesResult>(guid, message);
            } else if (methods[guid] == Method.GetMusicVideoDetails) {
                DeserializeMessageAndTriggerTask<MusicVideoResult>(guid, message);
            } else if (methods[guid] == Method.GetMusicVideos) {
                DeserializeMessageAndTriggerTask<MusicVideosResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedEpisodes) {
                DeserializeMessageAndTriggerTask<EpisodesResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedMovies) {
                DeserializeMessageAndTriggerTask<MoviesResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedMusicVideos) {
                DeserializeMessageAndTriggerTask<MusicVideosResult>(guid, message);
            } else if (methods[guid] == Method.GetSeasons) {
                DeserializeMessageAndTriggerTask<TVShowSeasonsResult>(guid, message);
            } else if (methods[guid] == Method.GetTVShowDetails) {
                DeserializeMessageAndTriggerTask<TVShowResult>(guid, message);
            } else if (methods[guid] == Method.GetTVShows) {
                DeserializeMessageAndTriggerTask<TVShowsResult>(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == KVideoLibrary.Notification.OnCleanFinished.ToString()) {
                OnCleanFinished?.Invoke();
            } else if (method == KVideoLibrary.Notification.OnCleanStarted.ToString()) {
                OnCleanStarted?.Invoke();
            } else if (method == KVideoLibrary.Notification.OnRemove.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<KVideoLibrary.Notifications.Item>>>(notification);
                OnRemove?.Invoke(item.Params.Data);
            } else if (method == KVideoLibrary.Notification.OnScanFinished.ToString()) {
                OnScanFinished?.Invoke();
            } else if (method == KVideoLibrary.Notification.OnScanStarted.ToString()) {
                OnScanStarted?.Invoke();
            } else if (method == KVideoLibrary.Notification.OnUpdate.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<UpdateItem>>>(notification);
                OnUpdate?.Invoke(item.Params.Data);
            }
        }

        public Task<bool> Clean() {
            return SendRequest<bool>(Method.Clean);
        }

        public Task<bool> Export(string path = null) {
            return SendRequest<bool, Export<PathOption>>(Method.Export, new Export<PathOption>() { Options = new PathOption() { Path = path } });
        }

        public Task<bool> Export(bool overwrite = false, bool actorthumbs = false, bool images = false) {
            return SendRequest<bool, Export<ExportOption>>(Method.Export, new Export<ExportOption>() { Options = new ExportOption() { ActorThumbs = actorthumbs, Overwrite = overwrite, Images = images } });
        }

        public Task<EpisodeResult> GetEpisodeDetails(int episodeId, EpisodeField properties = null) {
            return SendRequest<EpisodeResult, GetEpisodeDetails>(Method.GetEpisodeDetails, new GetEpisodeDetails() { EpisodeId = episodeId, Properties = properties?.ToList() });
        }

        public Task<EpisodesResult> GetEpisodes(EpisodeField properties = null, int? tvShowId = null, int? season = null, Limits limits = null, Sort sort = null) {
            return SendRequest<EpisodesResult, GetEpisodes>(Method.GetEpisodes, new GetEpisodes() { Properties = properties?.ToList(), TVShowId = tvShowId, Season = season, Limits = limits, Sort = sort });
        }

        public Task<GenresResult> GetGenres(TypeEnum type, GenreField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<GenresResult, GetGenres>(Method.GetGenres, new GetGenres() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Type = type });
        }

        public Task<MovieResult> GetMovieDetails(int movieId, MovieField properties = null) {
            return SendRequest<MovieResult, GetMovieDetails>(Method.GetMovieDetails, new GetMovieDetails() { Properties = properties?.ToList(), MovieId = movieId });
        }

        public Task<MoviesResult> GetMovies(MovieField properties = null, MovieFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MoviesResult, GetMovies>(Method.GetMovies, new GetMovies() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<MovieSetDetailsResult> GetMovieSetDetails(int setId, MovieSetField properties = null, MovieField movieProperties = null, Limits movieLimits = null, Sort movieSort = null) {
            return SendRequest<MovieSetDetailsResult, GetMovieSetDetails>(Method.GetMovieSetDetails, new GetMovieSetDetails() { SetId = setId, Properties = properties?.ToList(), Movies = new LimitSortPropertyBase() { Limits = movieLimits, Properties = movieProperties?.ToList(), Sort = movieSort } });
        }

        public Task<MovieSetsResult> GetMovieSets(MovieSetField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MovieSetsResult, GetMovieSets>(Method.GetMovieSets, new GetMovieSets() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<MusicVideoResult> GetMusicVideoDetails(int musicvideoId, MusicVideoField properties = null) {
            return SendRequest<MusicVideoResult, GetMusicVideoDetails>(Method.GetMusicVideoDetails, new GetMusicVideoDetails() { Properties = properties?.ToList(), MusicVideoId = musicvideoId });
        }

        public Task<MusicVideosResult> GetMusicVideos(MusicVideoField properties = null, MusicVideoFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MusicVideosResult, GetMusicVideos>(Method.GetMusicVideos, new GetMusicVideos() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<EpisodesResult> GetRecentlyAddedEpisodes(EpisodeField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<EpisodesResult, GetRecentlyAddedEpisodes>(Method.GetRecentlyAddedEpisodes, new GetRecentlyAddedEpisodes() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<MoviesResult> GetRecentlyAddedMovies(MovieField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MoviesResult, GetRecentlyAddedMovies>(Method.GetRecentlyAddedMovies, new GetRecentlyAddedMovies() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<MusicVideosResult> GetRecentlyAddedMusicVideos(MusicVideoField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MusicVideosResult, GetRecentlyAddedMusicVideos>(Method.GetRecentlyAddedMusicVideos, new GetRecentlyAddedMusicVideos() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<TVShowSeasonsResult> GetSeasons(int tvShowId, SeasonField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<TVShowSeasonsResult, GetSeasons>(Method.GetSeasons, new GetSeasons() { Properties = properties?.ToList(), Limits = limits, Sort = sort, TVShowId = tvShowId });
        }

        public Task<TVShowResult> GetTVShowDetails(int tvShowId, TVShowField properties = null) {
            return SendRequest<TVShowResult, GetTVShowDetails>(Method.GetTVShowDetails, new GetTVShowDetails() { Properties = properties?.ToList(), TVShowId = tvShowId });
        }

        public Task<TVShowsResult> GetTVShows(TVShowField properties = null, TVShowFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<TVShowsResult, GetTVShows>(Method.GetTVShows, new GetTVShows() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<bool> RemoveEpisode(int episodeId) {
            return SendRequest<bool, RemoveEpisode>(Method.RemoveEpisode, new RemoveEpisode() { EpisodeId = episodeId });
        }

        public Task<bool> RemoveMovie(int movieId) {
            return SendRequest<bool, RemoveMovie>(Method.RemoveMovie, new RemoveMovie() { MovieId = movieId });
        }

        public Task<bool> RemoveMusicVideo(int musicVideoId) {
            return SendRequest<bool, RemoveMusicVideo>(Method.RemoveMusicVideo, new RemoveMusicVideo() { MusicVideoId = musicVideoId });
        }

        public Task<bool> RemoveTVShow(int tvShowId) {
            return SendRequest<bool, RemoveTVShow>(Method.RemoveTVShow, new RemoveTVShow() { TVShowId = tvShowId });
        }

        public Task<bool> Scan(string directory = null) {
            return SendRequest<bool, Scan>(Method.Scan, new Scan() { Directory = directory });
        }

        public Task<bool> SetEpisodeDetails(SetEpisodeDetails details) {
            return SendRequest<bool, SetEpisodeDetails>(Method.SetEpisodeDetails, details);
        }

        public Task<bool> SetMovieDetails(SetMovieDetails details) {
            return SendRequest<bool, SetMovieDetails>(Method.SetMovieDetails, details);
        }

        public Task<bool> SetMusicVideoDetails(SetMusicVideoDetails details) {
            return SendRequest<bool, SetMusicVideoDetails>(Method.SetMusicVideoDetails, details);
        }

        public Task<bool> SetTVShowDetails(SetTVShowDetails details) {
            return SendRequest<bool, SetTVShowDetails>(Method.SetTVShowDetails, details);
        }
    }
}
