using KodiRemote.Code.Database.AddonTables;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using SQLite.Net.Attributes;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database {
    public class DatabaseConnection {
        private SQLiteAsyncConnection connection;

        public async Task Init(KodiSettings settings) {
            var lo = new SQLite.Net.SQLiteConnectionWithLock(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), new SQLite.Net.SQLiteConnectionString(settings.Name + ".s3db", false));
            //connection = new SQLiteAsyncConnection(settings.Name + ".s3db");            
            connection = new SQLiteAsyncConnection(() => lo);
            await connection.CreateTablesAsync(
                typeof(TVShowTableEntry),
                typeof(TVShowSeasonTableEntry),
                typeof(TVShowGenreTableEntry),
                typeof(TVShowActorsTableEntry),

                typeof(MusicVideoArtistTableEntry),
                typeof(MusicVideoAudioStreamTableEntry),
                typeof(MusicVideoDirectorTableEntry),
                typeof(MusicVideoGenreTableEntry),
                typeof(MusicVideoSubtitleStreamTableEntry),
                typeof(MusicVideoTableEntry),
                typeof(MusicVideoVideoStreamTableEntry),
                typeof(MVArtistTableEntry),

                typeof(SongTableEntry),
                typeof(SongGenreTableEntry),
                typeof(SongArtistTableEntry),

                typeof(AudioPlaylistTableEntry),
                typeof(AudioPlaylistSongTableEntry),

                typeof(ArtistTableEntry),

                typeof(AlbumTableEntry),
                typeof(AlbumGenreTableEntry),
                typeof(AlbumArtistTableEntry),

                typeof(MovieActorTableEntry),
                typeof(MovieAudioStreamTableEntry),
                typeof(MovieDirectorTableEntry),
                typeof(MovieGenreTableEntry),
                typeof(MovieSetMovieTableEntry),
                typeof(MovieSetTableEntry),
                typeof(MovieSubtitleStreamTableEntry),
                typeof(MovieTableEntry),

                typeof(ActorsTableEntry),
                typeof(AudioStreamTableEntry),
                typeof(DirectorsTableEntry),
                typeof(GenreTableEntry),
                typeof(SubtitleStreamTableEntry),
                typeof(VideoStreamTableEntry),

                typeof(EpisodeActorTableEntry),
                typeof(EpisodeAudioStreamTableEntry),
                typeof(EpisodeDirectorTableEntry),
                typeof(EpisodeSubtitleStreamTableEntry),
                typeof(EpisodeTableEntry),
                typeof(EpisodeVideoStreamTableEntry),

                typeof(AddonTableEntry)
            );
        }

        public async Task<List<T>> Get<T>() where T : class {
            return await connection.Table<T>().ToListAsync();
        }

        public async Task<T> Get<T>(T entry) where T : class {
            var entries = await Get<T>();
            return entries.FirstOrDefault(x => x.Equals(entry));
        }

        public async Task InsertIfNotExist<T>(T value) where T : class {
            var entry = await Get<T>(value);
            if (entry == null) {
                await connection.InsertOrReplaceAsync(value);
            }
        }


        public async Task SaveTVShow(TVShow tvshow) {
            foreach (Actor actor in tvshow.Cast) {
                var actorEntry = new ActorsTableEntry(actor);
                await InsertIfNotExist(actorEntry);
                //todo: I need the id of the Actor
                var tvshowActorEntry = new TVShowActorsTableEntry(tvshow, actorEntry, actor);
                await InsertIfNotExist(tvshowActorEntry);
            }
            foreach (string genre in tvshow.Genre) {
                var genreEntry = new GenreTableEntry(genre, GenreType.TVShow);
                await InsertIfNotExist(genreEntry);
                //todo: I need the id of the Actor
                var tvshowGenreEntry = new TVShowGenreTableEntry(tvshow, genreEntry);
                await InsertIfNotExist(tvshowGenreEntry);
            }
            await connection.InsertOrReplaceAsync(new TVShowTableEntry(tvshow));
        }

        public async Task DeleteTVShow(TVShow tvshow) {
            var actors = await Get<TVShowActorsTableEntry>();
            foreach (var actor in actors.Where(x => x.TVShowId == tvshow.TVShowId)) {
                await connection.DeleteAsync(actor);
            }
            var genres = await Get<TVShowGenreTableEntry>();
            foreach (var genre in genres.Where(x => x.TVShowId == tvshow.TVShowId)) {
                await connection.DeleteAsync(genre);
            }
        }

        public async Task SaveTVShows(List<TVShow> tvshows) {

            foreach (TVShow tvshow in tvshows) {
                await DeleteTVShow(tvshow);
                await SaveTVShow(tvshow);
            }
        }
    }
}
