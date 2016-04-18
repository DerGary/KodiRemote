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

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class VideoLibraryWebSocketService : WebSocketServiceBase, IVideoLibraryService {
        #region Notifications
        public event ReceivedEventHandler OnCleanFinished;
        public event ReceivedEventHandler OnCleanStarted;
        public event ReceivedEventHandler<Item> OnRemove;
        public event ReceivedEventHandler OnScanFinished;
        public event ReceivedEventHandler OnScanStarted;
        public event ReceivedEventHandler<UpdateItem> OnUpdate;
        #endregion Notifications

        #region Events
        public event ReceivedEventHandler<bool> CleanReceived;
        public event ReceivedEventHandler<bool> ExportReceived;
        public event ReceivedEventHandler<Episode> GetEpisodeDetailsReceived;
        public event ReceivedEventHandler<EpisodeResult> GetEpisodesReceived;
        public event ReceivedEventHandler<GenreResult> GetGenresReceived;
        public event ReceivedEventHandler<Movie> GetMovieDetailsReceived;
        public event ReceivedEventHandler<MovieSetDetails> GetMovieSetDetailsReceived;
        public event ReceivedEventHandler<MovieSetResult> GetMovieSetsReceived;
        public event ReceivedEventHandler<MovieResult> GetMoviesReceived;
        public event ReceivedEventHandler<MusicVideo> GetMusicVideoDetailsReceived;
        public event ReceivedEventHandler<MusicVideoResult> GetMusicVideosReceived;
        public event ReceivedEventHandler<EpisodeResult> GetRecentlyAddedEpisodesReceived;
        public event ReceivedEventHandler<MovieResult> GetRecentlyAddedMoviesReceived;
        public event ReceivedEventHandler<MusicVideoResult> GetRecentlyAddedMusicVideosReceived;
        public event ReceivedEventHandler<TVShowSeasonResult> GetSeasonsReceived;
        public event ReceivedEventHandler<TVShow> GetTVShowDetailsReceived;
        public event ReceivedEventHandler<TVShowResult> GetTVShowsReceived;
        public event ReceivedEventHandler<bool> RemoveEpisodeReceived;
        public event ReceivedEventHandler<bool> RemoveMovieReceived;
        public event ReceivedEventHandler<bool> RemoveMusicVideoReceived;
        public event ReceivedEventHandler<bool> RemoveTVShowReceived;
        public event ReceivedEventHandler<bool> ScanReceived;
        public event ReceivedEventHandler<bool> SetEpisodeDetailsReceived;
        public event ReceivedEventHandler<bool> SetMovieDetailsReceived;
        public event ReceivedEventHandler<bool> SetMusicVideoDetailsReceived;
        public event ReceivedEventHandler<bool> SetTVShowDetailsReceived;
        #endregion Events
        public VideoLibraryWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == KVideoLibrary.Method.Clean.ToInt()) {
                ConvertResultToBool(CleanReceived, message);
            } else if (id == KVideoLibrary.Method.Export.ToInt()) {
                ConvertResultToBool(ExportReceived, message);
            } else if (id == KVideoLibrary.Method.GetEpisodeDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<Episode>>(message);
                GetEpisodeDetailsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetEpisodes.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<EpisodeResult>>(message);
                GetEpisodesReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetGenres.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<GenreResult>>(message);
                GetGenresReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetMovieDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<Movie>>(message);
                GetMovieDetailsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetMovieSetDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<MovieSetDetails>>(message);
                GetMovieSetDetailsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetMovieSets.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<MovieSetResult>>(message);
                GetMovieSetsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetMovies.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<MovieResult>>(message);
                GetMoviesReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetMusicVideoDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<MusicVideo>>(message);
                GetMusicVideoDetailsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetMusicVideos.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<MusicVideoResult>>(message);
                GetMusicVideosReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetRecentlyAddedEpisodes.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<EpisodeResult>>(message);
                GetRecentlyAddedEpisodesReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetRecentlyAddedMovies.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<MovieResult>>(message);
                GetRecentlyAddedMoviesReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetRecentlyAddedMusicVideos.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<MusicVideoResult>>(message);
                GetRecentlyAddedMusicVideosReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetSeasons.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<TVShowSeasonResult>>(message);
                GetSeasonsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetTVShowDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<TVShow>>(message);
                GetTVShowDetailsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.GetTVShows.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<TVShowResult>>(message);
                GetTVShowsReceived?.Invoke(item.Result);
            } else if (id == KVideoLibrary.Method.RemoveEpisode.ToInt()) {
                ConvertResultToBool(RemoveEpisodeReceived, message);
            } else if (id == KVideoLibrary.Method.RemoveMovie.ToInt()) {
                ConvertResultToBool(RemoveMovieReceived, message);
            } else if (id == KVideoLibrary.Method.RemoveMusicVideo.ToInt()) {
                ConvertResultToBool(RemoveMusicVideoReceived, message);
            } else if (id == KVideoLibrary.Method.RemoveTVShow.ToInt()) {
                ConvertResultToBool(RemoveTVShowReceived, message);
            } else if (id == KVideoLibrary.Method.Scan.ToInt()) {
                ConvertResultToBool(ScanReceived, message);
            } else if (id == KVideoLibrary.Method.SetEpisodeDetails.ToInt()) {
                ConvertResultToBool(SetEpisodeDetailsReceived, message);
            } else if (id == KVideoLibrary.Method.SetMovieDetails.ToInt()) {
                ConvertResultToBool(SetMovieDetailsReceived, message);
            } else if (id == KVideoLibrary.Method.SetMusicVideoDetails.ToInt()) {
                ConvertResultToBool(SetMusicVideoDetailsReceived, message);
            } else if (id == KVideoLibrary.Method.SetTVShowDetails.ToInt()) {
                ConvertResultToBool(SetTVShowDetailsReceived, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            if (method == KVideoLibrary.Notification.OnCleanFinished.ToString()) {
                OnCleanFinished?.Invoke();
            } else if (method == KVideoLibrary.Notification.OnCleanStarted.ToString()) {
                OnCleanStarted?.Invoke();
            } else if (method == KVideoLibrary.Notification.OnRemove.ToString()) {
                var item = JsonSerializer.FromJson<RPCNotification<NotificationParams<Item>>>(notification);
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

        public void Clean() {
            SendRequest(Method.Clean);
        }

        public void Export(string path = null) {
            SendRequest(Method.Export, new Export() { Options = new PathOption() { Path = path } });
        }

        public void Export(bool overwrite = false, bool actorthumbs = false, bool images = false) {
            SendRequest(Method.Export, new Export() { Options = new ExportOption() { ActorThumbs = actorthumbs, Overwrite = overwrite, Images = images } });
        }

        public void GetEpisodeDetails(int episodeId, EpisodeField properties = null) {
            SendRequest(Method.GetEpisodeDetails, new GetEpisodeDetails() { EpisodeId = episodeId, Properties = properties?.ToList() });
        }

        public void GetEpisodes(EpisodeField properties = null, int? tvShowId = null, int? season = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetEpisodes, new GetEpisodes() { Properties = properties?.ToList(), TVShowId = tvShowId, Season = season, Limits = limits, Sort = sort });
        }

        public void GetGenres(TypeEnum type, GenreField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetGenres, new GetGenres() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Type = type });
        }

        public void GetMovieDetails(int movieId, MovieField properties = null) {
            SendRequest(Method.GetMovieDetails, new GetMovieDetails() { Properties = properties?.ToList(), MovieId = movieId });
        }

        public void GetMovies(MovieField properties = null, MovieFilter filter = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetMovies, new GetMovies() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public void GetMovieSetDetails(int setId, MovieSetField properties = null, MovieField movieProperties = null, Limits movieLimits = null, Sort movieSort = null) {

            SendRequest(Method.GetMovieSetDetails, new GetMovieSetDetails() { Properties = properties?.ToList(), Movies = new LimitSortPropertyBase() { Limits = movieLimits, Properties = movieProperties?.ToList(), Sort = movieSort } });
        }

        public void GetMovieSets(MovieSetField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetMovieSets, new GetMovieSets() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public void GetMusicVideoDetails(int musicvideoId, MusicVideoField properties = null) {
            SendRequest(Method.GetMusicVideoDetails, new GetMusicVideoDetails() { Properties = properties?.ToList(), MusicVideoId = musicvideoId });
        }

        public void GetMusicVideos(MusicVideoField properties = null, MusicVideoFilter filter = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetMusicVideos, new GetMusicVideos() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public void GetRecentlyAddedEpisodes(EpisodeField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetRecentlyAddedEpisodes, new GetRecentlyAddedEpisodes() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public void GetRecentlyAddedMovies(MovieField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetRecentlyAddedMovies, new GetRecentlyAddedMovies() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public void GetRecentlyAddedMusicVideos(MusicVideoField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetRecentlyAddedMusicVideos, new GetRecentlyAddedMusicVideos() { Properties = properties?.ToList(), Limits = limits, Sort = sort });
        }

        public void GetSeasons(int tvShowId, SeasonField properties = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetSeasons, new GetSeasons() { Properties = properties?.ToList(), Limits = limits, Sort = sort, TVShowId = tvShowId });
        }

        public void GetTVShowDetails(int tvShowId, TVShowField properties = null) {
            SendRequest(Method.GetTVShowDetails, new GetTVShowDetails() { Properties = properties?.ToList(), TVShowId = tvShowId });
        }

        public void GetTVShows(TVShowField properties = null, TVShowFilter filter = null, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetTVShows, new GetTVShows() { Properties = properties?.ToList(), Limits = limits, Sort = sort, Filter = filter });
        }

        public void RemoveEpisode(int episodeId) {
            SendRequest(Method.RemoveEpisode, new RemoveEpisode() { EpisodeId = episodeId });
        }

        public void RemoveMovie(int movieId) {
            SendRequest(Method.RemoveMovie, new RemoveMovie() { MovieId = movieId });
        }

        public void RemoveMusicVideo(int musicVideoId) {
            SendRequest(Method.RemoveMusicVideo, new RemoveMusicVideo() { MusicVideoId = musicVideoId });
        }

        public void RemoveTVShow(int tvShowId) {
            SendRequest(Method.RemoveTVShow, new RemoveTVShow() { TVShowId = tvShowId });
        }

        public void Scan(string directory = null) {
            SendRequest(Method.Scan, new Scan() { Directory = directory });
        }

        public void SetEpisodeDetails(EpisodeDetails details) {
            SendRequest(Method.SetEpisodeDetails, details);
        }

        public void SetMovieDetails(MovieDetails details) {
            SendRequest(Method.SetMovieDetails, details);
        }

        public void SetMusicVideoDetails(MusicVideoDetails details) {
            SendRequest(Method.SetMusicVideoDetails, details);
        }

        public void SetTVShowDetails(TVShowDetails details) {
            SendRequest(Method.SetTVShowDetails, details);
        }


    }
}
