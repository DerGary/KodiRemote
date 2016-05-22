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
        public abstract JSON.General.Notifications.Item CurrentlyPlayingItem { get; protected set; }
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
            var tvShowIds = await UpdateTVShows();
            var tvShowAndSeasonIds = await UpdateTVShowSeasons(tvShowIds);
            await UpdateEpisodes(tvShowAndSeasonIds);
            List<MovieSet> moviesets = await Update<MovieSet>(UpdateMovieSets);
            await Database.SaveMovieSets(moviesets);
            List<Movie> movies = await Update<Movie>(UpdateMovies);
            await Database.SaveMovies(movies);
            List<MusicVideo> musicvideos = await Update<MusicVideo>(UpdateMusicVideos);
            await Database.SaveMusicVideos(musicvideos);
            List<Artist> artists = await Update<Artist>(UpdateArtists);
            artists.AddRange(await Update<Artist>(UpdateArtists2));
            await Database.SaveArtists(artists);
            List<Song> songs = await Update<Song>(UpdateSongs);
            await Database.SaveSongs(songs);
            List<Album> albums = await Update<Album>(UpdateAlbums);
            await Database.SaveAlbums(albums);
            List<Addon> addons = await Update<Addon>(UpdateAddons);
            await Database.SaveAddons(addons);
            Debug.WriteLine("time taken: " + DateTime.Now.Subtract(first).TotalSeconds);
        }

        public async Task<List<T>> Update<T>(Func<List<T>,Limits,Task<CollectionResultBase>> function) {
            CollectionResultBase result;
            List<T> list = new List<T>();
            int i = 0;
            do {
                result = await function.Invoke(list, new Limits(i, i + LIMIT));
                i += LIMIT;
            } while (result != null && result.Limits.End != result.Limits.Total);
            return list;
        }
        
        public async Task<CollectionResultBase> UpdateAddons(List<Addon> list, Limits limits) {
            AddonsResult result = await Addons.GetAddons(ContentEnum.Null, EnabledEnum.All ,AddonField.WithAll(), limits: limits);
            if(result != null) {
                list.AddRange(result.Addons);
            }
            return result;
        }

        public async Task<CollectionResultBase> UpdateSongs(List<Song> list, Limits limits) {
            SongsResult result = await AudioLibrary.GetSongs(SongField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Songs);
            }
            return result;
        }

        public async Task<CollectionResultBase> UpdateArtists(List<Artist> list, Limits limits) {
            ArtistsResult result = await AudioLibrary.GetArtists(ArtistField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Artists);
            }
            return result;
        }
        public async Task<CollectionResultBase> UpdateArtists2(List<Artist> list, Limits limits) {
            ArtistsResult result = await AudioLibrary.GetArtists(ArtistField.WithMine(), albumartistsonly: true, limits: limits);
            if (result != null) {
                list.AddRange(result.Artists);
            }
            return result;
        }
        public async Task<CollectionResultBase> UpdateAlbums(List<Album> list, Limits limits) {
            AlbumsResult result = await AudioLibrary.GetAlbums(AlbumField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Albums);
            }
            return result;
        }

        public async Task<CollectionResultBase> UpdateMusicVideos(List<MusicVideo> list, Limits limits) {
            MusicVideosResult result = await VideoLibrary.GetMusicVideos(MusicVideoField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.MusicVideos);
            }
            return result;
        }

        public async Task<CollectionResultBase> UpdateMovieSets(List<MovieSet> list, Limits limits) {
            MovieSetsResult result = await VideoLibrary.GetMovieSets(MovieSetField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.MovieSets);
            }
            return result;
        }
        public async Task<CollectionResultBase> UpdateMovies(List<Movie> list, Limits limits) {
            MoviesResult result = await VideoLibrary.GetMovies(MovieField.WithMine(), limits: limits);
            if (result != null) {
                list.AddRange(result.Movies);
            }
            return result;
        }

        public async Task UpdateEpisodes(Dictionary<int, List<int>> ids) {
            EpisodesResult result;
            List<Episode> episodes = new List<Episode>();
            foreach (int tvshowId in ids.Keys) {
                List<int> seasonIds;
                ids.TryGetValue(tvshowId, out seasonIds);
                int i = 0;
                do {
                    result = await VideoLibrary.GetEpisodes(EpisodeField.WithMine(), tvshowId, limits: new Limits(i, i + LIMIT));
                    i += LIMIT;
                    if (result != null) {
                        episodes.AddRange(result.Episodes);
                    }
                } while (result != null && result.Limits.End != result.Limits.Total);
            }
            await Database.SaveEpisodes(episodes);
        }

        public async Task<Dictionary<int, List<int>>> UpdateTVShowSeasons(List<int> tvShowIds) {
            TVShowSeasonsResult result;
            List<TVShowSeason> seasons = new List<TVShowSeason>();
            var ids = new Dictionary<int, List<int>>();
            foreach (int i in tvShowIds) {
                result = await VideoLibrary.GetSeasons(i, SeasonField.WithMine());
                if (result != null) {
                    ids.Add(i, new List<int>(result.TVShowSeasons.Select(x => x.Season)));
                    seasons.AddRange(result.TVShowSeasons);
                }
            }
            await Database.SaveTVShowSeasons(seasons);
            return ids;
        }

        public async Task<List<int>> UpdateTVShows() {
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
    }
}
