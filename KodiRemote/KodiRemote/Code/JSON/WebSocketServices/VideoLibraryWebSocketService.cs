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

        public VideoLibraryWebSocketService(WebSocketHelper helper) : base(helper) { }
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
                DeserializeMessageAndTriggerTask<Episode>(guid, message);
            } else if (methods[guid] == Method.GetEpisodes) {
                DeserializeMessageAndTriggerTask<EpisodeResult>(guid, message);
            } else if (methods[guid] == Method.GetGenres) {
                DeserializeMessageAndTriggerTask<GenreResult>(guid, message);
            } else if (methods[guid] == Method.GetMovieDetails) {
                DeserializeMessageAndTriggerTask<Movie>(guid, message);
            } else if (methods[guid] == Method.GetMovieSetDetails) {
                DeserializeMessageAndTriggerTask<MovieSetDetails>(guid, message);
            } else if (methods[guid] == Method.GetMovieSets) {
                DeserializeMessageAndTriggerTask<MovieSetResult>(guid, message);
            } else if (methods[guid] == Method.GetMovies) {
                DeserializeMessageAndTriggerTask<MovieResult>(guid, message);
            } else if (methods[guid] == Method.GetMusicVideoDetails) {
                DeserializeMessageAndTriggerTask<MusicVideo>(guid, message);
            } else if (methods[guid] == Method.GetMusicVideos) {
                DeserializeMessageAndTriggerTask<MusicVideoResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedEpisodes) {
                DeserializeMessageAndTriggerTask<EpisodeResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedMovies) {
                DeserializeMessageAndTriggerTask<MovieResult>(guid, message);
            } else if (methods[guid] == Method.GetRecentlyAddedMusicVideos) {
                DeserializeMessageAndTriggerTask<MusicVideoResult>(guid, message);
            } else if (methods[guid] == Method.GetSeasons) {
                DeserializeMessageAndTriggerTask<TVShowSeasonResult>(guid, message);
            } else if (methods[guid] == Method.GetTVShowDetails) {
                DeserializeMessageAndTriggerTask<TVShow>(guid, message);
            } else if (methods[guid] == Method.GetTVShows) {
                DeserializeMessageAndTriggerTask<TVShowResult>(guid, message);
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

        public Task<Episode> GetEpisodeDetails(int episodeId, EpisodeField properties = null) {
            return SendRequest<Episode, GetEpisodeDetails>(Method.GetEpisodeDetails, new GetEpisodeDetails() { EpisodeId = episodeId, Properties = properties?.ToList() });
        }

        public Task<EpisodeResult> GetEpisodes(EpisodeField properties = null, int? tvShowId = null, int? season = null, Limits limits = null, Sort sort = null) {
            return SendRequest<EpisodeResult, GetEpisodes>(Method.GetEpisodes, new GetEpisodes() { Properties = properties?.ToList(), TVShowId = tvShowId, Season = season, Limits = limits, Sort = sort });
        }

        public Task<GenreResult> GetGenres(TypeEnum type, GenreField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<GenreResult, GetGenres>(Method.GetGenres, new GetGenres() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Type = type });
        }

        public Task<Movie> GetMovieDetails(int movieId, MovieField properties = null) {
            return SendRequest<Movie, GetMovieDetails>(Method.GetMovieDetails, new GetMovieDetails() { Properties = properties?.ToList(), MovieId = movieId });
        }

        public Task<MovieResult> GetMovies(MovieField properties = null, MovieFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MovieResult, GetMovies>(Method.GetMovies, new GetMovies() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<MovieSetDetails> GetMovieSetDetails(int setId, MovieSetField properties = null, MovieField movieProperties = null, Limits movieLimits = null, Sort movieSort = null) {
            return SendRequest<MovieSetDetails, GetMovieSetDetails>(Method.GetMovieSetDetails, new GetMovieSetDetails() { Properties = properties?.ToList(), Movies = new LimitSortPropertyBase() { Limits = movieLimits, Properties = movieProperties?.ToList(), Sort = movieSort } });
        }

        public Task<MovieSetResult> GetMovieSets(MovieSetField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MovieSetResult, GetMovieSets>(Method.GetMovieSets, new GetMovieSets() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<MusicVideo> GetMusicVideoDetails(int musicvideoId, MusicVideoField properties = null) {
            return SendRequest<MusicVideo, GetMusicVideoDetails>(Method.GetMusicVideoDetails, new GetMusicVideoDetails() { Properties = properties?.ToList(), MusicVideoId = musicvideoId });
        }

        public Task<MusicVideoResult> GetMusicVideos(MusicVideoField properties = null, MusicVideoFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MusicVideoResult, GetMusicVideos>(Method.GetMusicVideos, new GetMusicVideos() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public Task<EpisodeResult> GetRecentlyAddedEpisodes(EpisodeField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<EpisodeResult, GetRecentlyAddedEpisodes>(Method.GetRecentlyAddedEpisodes, new GetRecentlyAddedEpisodes() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<MovieResult> GetRecentlyAddedMovies(MovieField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MovieResult, GetRecentlyAddedMovies>(Method.GetRecentlyAddedMovies, new GetRecentlyAddedMovies() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<MusicVideoResult> GetRecentlyAddedMusicVideos(MusicVideoField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<MusicVideoResult, GetRecentlyAddedMusicVideos>(Method.GetRecentlyAddedMusicVideos, new GetRecentlyAddedMusicVideos() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public Task<TVShowSeasonResult> GetSeasons(int tvShowId, SeasonField properties = null, Limits limits = null, Sort sort = null) {
            return SendRequest<TVShowSeasonResult, GetSeasons>(Method.GetSeasons, new GetSeasons() { Properties = properties?.ToList(), Limits = limits, Sort = sort, TVShowId = tvShowId });
        }

        public Task<TVShow> GetTVShowDetails(int tvShowId, TVShowField properties = null) {
            return SendRequest<TVShow, GetTVShowDetails>(Method.GetTVShowDetails, new GetTVShowDetails() { Properties = properties?.ToList(), TVShowId = tvShowId });
        }

        public Task<TVShowResult> GetTVShows(TVShowField properties = null, TVShowFilter filter = null, Limits limits = null, Sort sort = null) {
            return SendRequest<TVShowResult, GetTVShows>(Method.GetTVShows, new GetTVShows() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
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
