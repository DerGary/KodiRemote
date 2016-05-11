using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using KodiRemote.Code.Utils;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
            logger.AddProvider(new DatabaseLoggerProvider());
            this.settings = settings;
        }

        public async Task SaveTVShow(TVShow tvshow) {
            var tvshowentry = new TVShowTableEntry(tvshow);
            if (await database.TVShows.AnyAsync(x => x.TVShowId == tvshow.TVShowId)) {
                database.TVShows.Update(tvshowentry);
                database.TVShowActorMapper.RemoveRange(database.TVShowActorMapper.Where(x => x.TVShowId == tvshow.TVShowId));
                database.TVShowGenreMapper.RemoveRange(database.TVShowGenreMapper.Where(x => x.TVShowId == tvshow.TVShowId));
            } else {
                database.TVShows.Add(tvshowentry);
            }

            await database.SaveChangesAsync();
            foreach (Actor actor in tvshow.Cast) {
                var savedActor = await database.Actors.FirstOrDefaultAsync(x => x.Name == actor.Name && x.Thumbnail == actor.Thumbnail);
                if (savedActor == null) {
                    savedActor = new ActorTableEntry(actor);
                    database.Actors.Add(savedActor);
                    await database.SaveChangesAsync();
                }
                database.TVShowActorMapper.Add(new TVShowActorMapper() { ActorId = savedActor.ActorId, TVShowId = tvshow.TVShowId, Role = actor.Role });
            }
            foreach (string genre in tvshow.Genre) {
                var savedGenre = await database.TVShowGenres.FirstOrDefaultAsync(x => x.Genre == genre);
                if(savedGenre == null) {
                    savedGenre = new TVShowGenreTableEntry(genre);
                    database.TVShowGenres.Add(savedGenre);
                    await database.SaveChangesAsync();
                }
                database.TVShowGenreMapper.Add(new TVShowGenreMapper() { TVShowId = tvshow.TVShowId, GenreId = savedGenre.GenreId });
            }
        }


        public async Task SaveTVShows(List<TVShow> tvshows) {
            foreach (TVShow tvshow in tvshows) {
                await SaveTVShow(tvshow);
            }
            await database.SaveChangesAsync();
        }

        public async Task SaveTVShowSeason(TVShowSeason season) {
            var seasonEntry = new TVShowSeasonTableEntry(season);
            if (await database.TVShowSeasons.AnyAsync(x => x.TVShowId == season.TVShowId && x.Season == season.Season)) {
                database.TVShowSeasons.Update(seasonEntry);
            } else {
                database.TVShowSeasons.Add(seasonEntry);
            }
        }

        public async Task SaveTVShowSeasons(List<TVShowSeason> seasons) {
            foreach (TVShowSeason season in seasons) {
                await SaveTVShowSeason(season);
            }
            await database.SaveChangesAsync();
        }



        public async Task SaveEpisode(Episode episode) {
            var episodeEntry = new EpisodeTableEntry(episode);
            if (await database.Episodes.AnyAsync(x => x.EpisodeId == episode.EpisodeId)) {
                database.Episodes.Update(episodeEntry);
                database.EpisodeActorMapper.RemoveRange(database.EpisodeActorMapper.Where(x => x.EpisodeId == episode.EpisodeId));
                database.EpisodeDirectorMapper.RemoveRange(database.EpisodeDirectorMapper.Where(x => x.EpisodeId == episode.EpisodeId));
                database.EpisodeAudioStreamMapper.RemoveRange(database.EpisodeAudioStreamMapper.Where(x => x.EpisodeId == episode.EpisodeId));
                database.EpisodeSubtitleStreamMapper.RemoveRange(database.EpisodeSubtitleStreamMapper.Where(x => x.EpisodeId == episode.EpisodeId));
                database.EpisodeVideoStreamMapper.RemoveRange(database.EpisodeVideoStreamMapper.Where(x => x.EpisodeId == episode.EpisodeId));
            } else {
                database.Episodes.Add(episodeEntry);
            }

            await database.SaveChangesAsync();

            foreach (Actor actor in episode.Cast) {
                var saved = await AddIfNotExist(
                    set: database.Actors,
                    filterPredicate: x => x.Name == actor.Name && x.Thumbnail == actor.Thumbnail,
                    toSave: new ActorTableEntry(actor));

                database.EpisodeActorMapper.Add(new EpisodeActorMapper() { ActorId = saved.ActorId, EpisodeId = episode.EpisodeId, Role = actor.Role });
            }

            foreach (string director in episode.Director) {
                var saved = await AddIfNotExist(
                    set: database.Directors, 
                    filterPredicate: x => x.Name == director, 
                    toSave: new DirectorTableEntry(director));

                database.EpisodeDirectorMapper.Add(new EpisodeDirectorMapper() { DirectorId = saved.DirectorId, EpisodeId = episode.EpisodeId });
            }

            foreach (var stream in episode.StreamDetails.Audio) {
                var saved = await AddIfNotExist(
                    set: database.AudioStreams,
                    filterPredicate: x => x.Channels == stream.Channels && x.Codec == stream.Codec && x.Language == stream.Language,
                    toSave: new AudioStreamTableEntry(stream));

                database.EpisodeAudioStreamMapper.Add(new EpisodeAudioStreamMapper() { EpisodeId = episode.EpisodeId, AudioStreamId = saved.AudioStreamId });
            }

            foreach (var stream in episode.StreamDetails.Subtitle) {
                var saved = await AddIfNotExist(
                    set: database.SubtitleStreams,
                    filterPredicate: x => x.Language == stream.Language,
                    toSave: new SubtitleStreamTableEntry(stream));

                database.EpisodeSubtitleStreamMapper.Add(new EpisodeSubtitleStreamMapper() { EpisodeId = episode.EpisodeId, SubtitleStreamId = saved.SubtitleStreamId});
            }
            foreach (var stream in episode.StreamDetails.Video) {
                var saved = await AddIfNotExist(
                    set: database.VideoStreams,
                    filterPredicate: x => x.Aspect == stream.Aspect && x.Codec == stream.Codec && x.Height == stream.Height && x.Width == stream.Width,
                    toSave: new VideoStreamTableEntry(stream));

                database.EpisodeVideoStreamMapper.Add(new EpisodeVideoStreamMapper() { EpisodeId = episode.EpisodeId, VideoStreamId= saved.VideoStreamId});
            }
        }
        public async Task<T> AddIfNotExist<T>(DbSet<T> set, Expression<Func<T,bool>> filterPredicate, T toSave) where T : class {
            var saved = await set.FirstOrDefaultAsync(filterPredicate);
            if (saved == null) {
                saved = toSave;
                set.Add(saved);
                await database.SaveChangesAsync();
            }
            return saved;
        }
    }
}
