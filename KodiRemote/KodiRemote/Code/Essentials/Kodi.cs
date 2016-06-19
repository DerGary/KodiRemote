using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Notifications;
using KodiRemote.Code.JSON.General.Results;
using KodiRemote.Code.JSON.KAddons.Results;
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
using Windows.UI.Popups;
using Windows.UI.Xaml;

namespace KodiRemote.Code.Essentials {

    public abstract partial class Kodi : PropertyChangedBase, IDisposable {
        public KodiSettings Settings { get; protected set; }

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

        private JSON.General.Notifications.Item currentlyPlayingItem;
        public JSON.General.Notifications.Item CurrentlyPlayingItem {
            get {
                return currentlyPlayingItem;
            }
            protected set {
                currentlyPlayingItem = value;
                RaisePropertyChanged();
            }
        }

        private bool paused;
        public bool Paused {
            get {
                return paused;
            }
            protected set {
                paused = value;
                RaisePropertyChanged();
            }
        }

        private bool muted;
        public bool Muted {
            get {
                return muted;
            }
            protected set {
                muted = value;
                RaisePropertyChanged();
            }
        }
        private double volume;
        public double Volume {
            get {
                return volume;
            }
            protected set {
                volume = value;
                RaisePropertyChanged();
            }
        }


        private bool connected = false;
        public bool Connected {
            get {
                return connected;
            }
            protected set {
                connected = value;
                RaisePropertyChanged();
            }
        }

        public DatabaseOperations Database { get; protected set; }
        
        public ObservableCollection<Song> CurrentAudioPlaylist { get; protected set; } = new ObservableCollection<Song>();
        public ObservableCollection<object> CurrentVideoPlaylist { get; protected set; } = new ObservableCollection<object>();
        public ObservableCollection<object> CurrentPicturePlaylist { get; protected set; } = new ObservableCollection<object>();

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
            this.Settings = settings;
            this.Database = new DatabaseOperations(settings.Name);
        }

        public static event KodiChangedEventHandler KodiChanged;
        public static async Task Init(KodiSettings settings) {
            if (settings.Type == ConnectionType.Websocket) {
                ActiveInstance = new KodiWebSocket(settings);
            }
            await ActiveInstance.Connect();
            await ActiveInstance.InitProperties();
            await ActiveInstance.DatabaseInit();
        }

        private bool databaseInited;
        public async Task DatabaseInit() {
            if(databaseInited) {
                return;
            }
            databaseInited = true;
            await Database.Init();
        }
        

        public abstract Task InitProperties();
        public abstract Task Connect();
        public abstract void Dispose();

        public async Task StartDatabaseUpdate() {
            if (DatabaseWorking) {
                await new MessageDialog("There is currently an update of the Database in Progress. You can't start another one until it finished.", "Update Database in Progress").ShowAsync();
            } else {
                new Task(async () => await UpdateDatabase()).Start();
                //Task.Run(async () => await UpdateDatabase()).Start();
            }
        }



        #region GatherUpdateData
        const int LIMIT = 20;

        private bool databaseWorking;
        public bool DatabaseWorking {
            get {
                return databaseWorking;
            }
            private set {
                databaseWorking = value;
                RaisePropertyChanged();
            }
        }

        private async Task UpdateDatabase() {
            DatabaseWorking = true;
            Debug.WriteLine("Start Database Update");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var tvShowIds = await UpdateTVShows();
            var tvShowAndSeasonIds = await UpdateTVShowSeasons(tvShowIds);
            await UpdateEpisodes(tvShowAndSeasonIds);
            Debug.WriteLine("Update TVShows done");

            List<MovieSet> moviesets = await Update<MovieSet>(UpdateMovieSets);
            await Database.SaveMovieSets(moviesets);
            Debug.WriteLine("Update MovieSets done");

            List<Movie> movies = await Update<Movie>(UpdateMovies);
            await Database.SaveMovies(movies);
            Debug.WriteLine("Update MovieSets done");

            List<MusicVideo> musicvideos = await Update<MusicVideo>(UpdateMusicVideos);
            await Database.SaveMusicVideos(musicvideos);
            Debug.WriteLine("Update MusicVideos done");

            List<Artist> artists = await Update<Artist>(UpdateArtists);
            artists.AddRange(await Update<Artist>(UpdateArtists2));
            await Database.SaveArtists(artists);
            Debug.WriteLine("Update Artists done");

            List<Song> songs = await Update<Song>(UpdateSongs);
            await Database.SaveSongs(songs);
            Debug.WriteLine("Update Songs done");

            List<Album> albums = await Update<Album>(UpdateAlbums);
            await Database.SaveAlbums(albums);
            Debug.WriteLine("Update Albums done");

            List<Addon> addons = await Update<Addon>(UpdateAddons);
            await Database.SaveAddons(addons);
            Debug.WriteLine("Update Addons done");

            sw.Stop();
            Debug.WriteLine("time taken (s): " + sw.Elapsed.TotalSeconds);
            DatabaseWorking = false;
        }

        private async Task<List<T>> Update<T>(Func<List<T>, Limits, Task<CollectionResultBase>> function) {
            CollectionResultBase result;
            List<T> list = new List<T>();
            int i = 0;
            do {
                result = await function.Invoke(list, new Limits(i, i + LIMIT));
                i += LIMIT;
            } while (result != null && result.Limits.End != result.Limits.Total);
            return list;
        }

        private async Task<CollectionResultBase> UpdateAddons(List<Addon> list, Limits limits) {
            AddonsResult result = await Addons.GetAddons(ContentEnum.Null, EnabledEnum.All , AddonField.WithAll(), limits: limits);
            if (result != null) {
                list.AddRange(result.Addons);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateSongs(List<Song> list, Limits limits) {
            SongsResult result = await AudioLibrary.GetSongs(SongField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Songs);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateArtists(List<Artist> list, Limits limits) {
            ArtistsResult result = await AudioLibrary.GetArtists(ArtistField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Artists);
            }
            return result;
        }
        private async Task<CollectionResultBase> UpdateArtists2(List<Artist> list, Limits limits) {
            ArtistsResult result = await AudioLibrary.GetArtists(ArtistField.WithMine(), albumartistsonly: true, limits: limits);
            if (result != null) {
                list.AddRange(result.Artists);
            }
            return result;
        }
        private async Task<CollectionResultBase> UpdateAlbums(List<Album> list, Limits limits) {
            AlbumsResult result = await AudioLibrary.GetAlbums(AlbumField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Albums);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateMusicVideos(List<MusicVideo> list, Limits limits) {
            MusicVideosResult result = await VideoLibrary.GetMusicVideos(MusicVideoField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.MusicVideos);
            }
            return result;
        }

        private async Task<CollectionResultBase> UpdateMovieSets(List<MovieSet> list, Limits limits) {
            MovieSetsResult result = await VideoLibrary.GetMovieSets(MovieSetField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.MovieSets);
            }
            return result;
        }
        private async Task<CollectionResultBase> UpdateMovies(List<Movie> list, Limits limits) {
            MoviesResult result = await VideoLibrary.GetMovies(MovieField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Movies);
            }
            return result;
        }

        private async Task UpdateEpisodes(Dictionary<int, List<int>> ids) {
            EpisodesResult result;
            List<Episode> episodes = new List<Episode>();
            foreach (int tvshowId in ids.Keys) {
                List<int> seasonIds;
                ids.TryGetValue(tvshowId, out seasonIds);
                foreach(int seasonId in seasonIds) {
                    int i = 0;
                    do {
                        result = await VideoLibrary.GetEpisodes(EpisodeField.WithMine(), tvshowId, seasonId, limits: new Limits(i, i + LIMIT));
                        i += LIMIT;
                        if (result != null) {
                            episodes.AddRange(result.Episodes);
                        }
                    } while (result != null && result.Limits.End != result.Limits.Total);
                }
            }
            await Database.SaveEpisodes(episodes);
        }

        private async Task<Dictionary<int, List<int>>> UpdateTVShowSeasons(List<int> tvShowIds) {
            TVShowSeasonsResult result;
            List<TVShowSeason> seasons = new List<TVShowSeason>();
            var ids = new Dictionary<int, List<int>>();
            foreach (int tvshowId in tvShowIds) {
                result = await VideoLibrary.GetSeasons(tvshowId, SeasonField.WithMine());
                if (result?.TVShowSeasons != null) {
                    ids.Add(tvshowId, new List<int>(result.TVShowSeasons.Select(x => x.Season)));
                    seasons.AddRange(result.TVShowSeasons);
                }
            }
            await Database.SaveTVShowSeasons(seasons);
            return ids;
        }

        private async Task<List<int>> UpdateTVShows() {
            TVShowsResult result;
            List<int> tvShowIds = new List<int>();
            List<TVShow> tvShow = new List<TVShow>();
            int i = 0;
            do {
                result = await VideoLibrary.GetTVShows(TVShowField.WithMine(), limits: new Limits(i, i + LIMIT));
                i += LIMIT;
                if (result != null) {
                    tvShowIds.AddRange(result.TVShows.Select(x => x.TVShowId));
                    tvShow.AddRange(result.TVShows);
                }
            } while (result != null && result.Limits.End != result.Limits.Total);
            await Database.SaveTVShows(tvShow);
            return tvShowIds;
        }
        #endregion GatherUpdateData
    }
}
