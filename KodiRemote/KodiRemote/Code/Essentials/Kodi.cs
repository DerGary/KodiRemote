using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General.Notifications;
using KodiRemote.Code.JSON.KAudioLibrary.Results;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using KodiRemote.Code.JSON.ServiceInterfaces;
using KodiRemote.Code.JSON.WebSocketServices;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace KodiRemote.Code.Essentials {

    public abstract class Kodi : PropertyChangedBase, IDisposable {
        protected KodiSettings settings;

        public IPlayerService Player { get; protected set; }
        public IInputService Input { get; protected set; }
        public IApplicationService Application { get; protected set; }
        public IGUIService GUI { get; protected set; }
        public ISystemService System { get; protected set; }
        public IAddonsService Addons { get; protected set; }
        public IFilesService Files { get; protected set; }
        public IJSONRPCService JSONRPC { get; protected set; }
        public IPVRService PVR { get; protected set; }
        public IVideoLibraryService VideoLibrary { get; protected set; }
        public IAudioLibraryService AudioLibrary { get; protected set; }
        public IPlaylistService Playlist { get; protected set; }
        public abstract bool Muted { get; protected set; }
        public abstract double Volume { get; protected set; }
        public abstract bool Paused { get; protected set; }
        public abstract Item CurrentlyPlayingItem { get; protected set; }
        public abstract bool Connected { get; protected set; }
        public DatabaseConnection Database { get; protected set; }


        public abstract ObservableCollection<Song> CurrentAudioPlaylist { get; protected set; }
        public abstract ObservableCollection<object> CurrentVideoPlaylist { get; protected set; }
        public abstract ObservableCollection<object> CurrentPicturePlaylist { get; protected set; }

        private static Kodi instance;
        public static Kodi ActiveInstance {
            get {
                return instance;
            }
            private set {
                instance = value;
                KodiChanged?.Invoke(instance, null);
            }
        }

        protected Kodi(KodiSettings settings) {
            this.settings = settings;
            this.Database = new DatabaseConnection();
        }

        public static event KodiChangedEventHandler KodiChanged;
        public static async Task Init(KodiSettings settings) {
            if (settings.Type == ConnectionType.Websocket) {
                ActiveInstance = new KodiWebSocket(settings);
            }
            await ActiveInstance.Init();
        }

        public abstract Task Init();
        public abstract Task Connect();
        public abstract void Dispose();

        const int LIMIT = 20;

        public async Task UpdateDatabase() {
            var first = DateTime.Now;
            //var tvShowIds = await UpdateTVShows();
            //var tvShowAndSeasonIds = await UpdateTVShowSeasons(tvShowIds);
            //await UpdateEpisodes(tvShowAndSeasonIds);
            //await UpdateMovieSets();
            //await UpdateMovies();
            await UpdateMusicVideos();
            Debug.WriteLine("time taken: " + DateTime.Now.Subtract(first).TotalSeconds);
        }
        public async Task UpdateMusicVideos() {
            MusicVideoField field = new MusicVideoField();
            field.Mine();
            MusicVideosResult result;
            List<MusicVideo> musicvideos = new List<MusicVideo>();
            int i = 0;
            do {
                result = await VideoLibrary.GetMusicVideos(field, limits: new JSON.General.Limits(i, i + LIMIT));
                i += LIMIT;
                if (result != null) {
                    musicvideos.AddRange(result.MusicVideos);
                }
            } while (result != null && result.Limits.End != result.Limits.Total);
            await Database.SaveMusicVideos(musicvideos);
        }

        public async Task UpdateMovieSets() {
            MovieSetsResult result;
            List<MovieSet> moviesets = new List<MovieSet>();
            int i = 0;
            do {
                result = await VideoLibrary.GetMovieSets(MovieSetField.WithAll(), limits: new JSON.General.Limits(i, i + LIMIT));
                i += LIMIT;
                if (result != null) {
                    moviesets.AddRange(result.MovieSets);
                }
            } while (result != null && result.Limits.End != result.Limits.Total);
            await Database.SaveMovieSets(moviesets);
        }

        public async Task UpdateMovies() {
            MovieField field = new MovieField();
            field.Mine();
            MoviesResult result;
            List<Movie> movies = new List<Movie>();
            int i = 0;
            do {
                result = await VideoLibrary.GetMovies(field, limits: new JSON.General.Limits(i, i + LIMIT));
                i += LIMIT;
                if (result != null) {
                    movies.AddRange(result.Movies);
                }
            } while (result != null && result.Limits.End != result.Limits.Total);
            await Database.SaveMovies(movies);
        }

        public async Task UpdateEpisodes(Dictionary<int, List<int>> ids) {
            EpisodeField field = new EpisodeField();
            field.Mine();
            EpisodesResult result;
            List<Episode> episodes = new List<Episode>();
            foreach (int tvshowId in ids.Keys) {
                List<int> seasonIds;
                ids.TryGetValue(tvshowId, out seasonIds);
                int i = 0;
                do {
                    result = await VideoLibrary.GetEpisodes(field, tvshowId, limits: new JSON.General.Limits(i, i + LIMIT));
                    i += LIMIT;
                    if (result != null) {
                        episodes.AddRange(result.Episodes);
                    }
                } while (result != null && result.Limits.End != result.Limits.Total);
            }
            await Database.SaveEpisodes(episodes);
        }

        public async Task<Dictionary<int, List<int>>> UpdateTVShowSeasons(List<int> tvShowIds) {
            SeasonField field = new SeasonField();
            field.Mine();
            TVShowSeasonsResult result;
            List<TVShowSeason> seasons = new List<TVShowSeason>();
            var ids = new Dictionary<int, List<int>>();
            foreach (int i in tvShowIds) {
                result = await VideoLibrary.GetSeasons(i, field);
                if (result != null) {
                    ids.Add(i, new List<int>(result.TVShowSeasons.Select(x => x.Season)));
                    seasons.AddRange(result.TVShowSeasons);
                }
            }
            await Database.SaveTVShowSeasons(seasons);
            return ids;
        }

        public async Task<List<int>> UpdateTVShows() {
            var tvshowfield = new TVShowField();
            tvshowfield.Mine();
            TVShowsResult result;
            List<int> tvShowIds = new List<int>();
            List<TVShow> tvShow = new List<TVShow>();
            int i = 0;
            do {
                result = await VideoLibrary.GetTVShows(tvshowfield, limits: new JSON.General.Limits(i, i + LIMIT));
                i += LIMIT;
                if (result != null) {
                    tvShowIds.AddRange(result.TVShows.Select(x => x.TVShowId));
                    tvShow.AddRange(result.TVShows);
                }
            } while (result != null && result.Limits.End != result.Limits.Total);
            await Database.SaveTVShows(tvShow);
            return tvShowIds;
        }
    }
}
