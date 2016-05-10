using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KodiRemote.Code.Database {
    public class DatabaseConnection {
        private DatabaseContext database;
        private KodiSettings settings;

        public async Task Init(KodiSettings settings) {
            database = new DatabaseContext(settings.Name);
            await database.Database.MigrateAsync();
            ILoggerFactory logger = ((IInfrastructure<IServiceProvider>)database).Instance.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
            logger.AddProvider(new MyLoggerProvider());
            this.settings = settings;
        }

        public async Task SaveTVShow(TVShow tvshow) {
            var tvshowentry = new TVShowTableEntry(tvshow);
            if (await database.TVShows.AnyAsync(x => x.TVShowId == tvshow.TVShowId)) {
                database.TVShows.Update(tvshowentry);
                database.TVShowActors.RemoveRange(database.TVShowActors.Where(x => x.TVShowId == tvshow.TVShowId));
                database.TVShowGenre.RemoveRange(database.TVShowGenre.Where(x => x.TVShowId == tvshow.TVShowId));
                Debug.WriteLine("notnull");
            } else {
                Debug.WriteLine("null");
                database.TVShows.Add(tvshowentry);
            }

            await database.SaveChangesAsync();
            foreach (Actor actor in tvshow.Cast) {
                database.TVShowActors.Add(new TVShowActorsTableEntry(tvshow, actor) { TVShow = tvshowentry });
            }
            foreach (string genre in tvshow.Genre) {
                var genreentry = new TVShowGenreTableEntry(genre);
                if (!await database.TVShowGenres.AnyAsync(x => x.Genre == genreentry.Genre)) {
                    database.TVShowGenres.Add(genreentry);
                }
            }
            await database.SaveChangesAsync();
            foreach (string genre in tvshow.Genre) {
                var genreEntry = database.TVShowGenres.FirstOrDefault(x => x.Genre == genre);
                database.TVShowGenre.Add(new TVShowGenre() { TVShowId = tvshow.TVShowId, GenreId = genreEntry.GenreId, Genre = genreEntry, TVShow = tvshowentry });
            }
        }


        public async Task SaveTVShows(List<TVShow> tvshows) {
            foreach (TVShow tvshow in tvshows) {
                await SaveTVShow(tvshow);
            }
            await database.SaveChangesAsync();
        }

        public void SaveTVShowSeason(TVShowSeason season) {
            var seasonEntry = new TVShowSeasonTableEntry(season);
            database.TVShowSeasons.Add(seasonEntry);
        }

        public async Task SaveTVShowSeasons(List<TVShowSeason> seasons) {
            foreach (TVShowSeason season in seasons) {
                SaveTVShowSeason(season);
            }
            await database.SaveChangesAsync();
        }
    }
}
