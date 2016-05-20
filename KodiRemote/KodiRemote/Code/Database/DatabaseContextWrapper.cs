using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.MusicVideoTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Utils;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database {
    public class DatabaseContextWrapper {
        private string name;

        public DatabaseWrapper<ActorTableEntry> Actors { get; set; }
        public DatabaseWrapper<AudioStreamTableEntry> AudioStreams { get; set; }
        public DatabaseWrapper<DirectorTableEntry> Directors { get; set; }
        public DatabaseWrapper<SubtitleStreamTableEntry> SubtitleStreams { get; set; }
        public DatabaseWrapper<VideoStreamTableEntry> VideoStreams { get; set; }
               
        public DatabaseWrapper<TVShowTableEntry> TVShows { get; set; }
        public DatabaseWrapper<TVShowGenreTableEntry> TVShowGenres { get; set; }
        public DatabaseWrapper<TVShowSeasonTableEntry> TVShowSeasons { get; set; }
        public DatabaseWrapper<TVShowGenreMapper> TVShowGenreMapper { get; set; }
        public DatabaseWrapper<TVShowActorMapper> TVShowActorMapper { get; set; }
               
        public DatabaseWrapper<EpisodeTableEntry> Episodes { get; set; }
        public DatabaseWrapper<EpisodeActorMapper> EpisodeActorMapper { get; set; }
        public DatabaseWrapper<EpisodeAudioStreamMapper> EpisodeAudioStreamMapper { get; set; }
        public DatabaseWrapper<EpisodeDirectorMapper> EpisodeDirectorMapper { get; set; }
        public DatabaseWrapper<EpisodeSubtitleStreamMapper> EpisodeSubtitleStreamMapper { get; set; }
        public DatabaseWrapper<EpisodeVideoStreamMapper> EpisodeVideoStreamMapper { get; set; }

        public DatabaseWrapper<MovieSetTableEntry> MovieSets { get; set; }
        public DatabaseWrapper<MovieSetMapper> MovieSetMapper { get; set; }
        public DatabaseWrapper<MovieTableEntry> Movies { get; set; }
        public DatabaseWrapper<MovieActorMapper> MovieActorMapper { get; set; }
        public DatabaseWrapper<MovieAudioStreamMapper> MovieAudioStreamMapper { get; set; }
        public DatabaseWrapper<MovieDirectorMapper> MovieDirectorMapper { get; set; }
        public DatabaseWrapper<MovieSubtitleStreamMapper> MovieSubtitleStreamMapper { get; set; }
        public DatabaseWrapper<MovieVideoStreamMapper> MovieVideoStreamMapper { get; set; }
        public DatabaseWrapper<MovieGenreMapper> MovieGenreMapper { get; set; }
        public DatabaseWrapper<MovieGenreTableEntry> MovieGenres { get; set; }
        
        public DatabaseWrapper<MusicVideoTableEntry> MusicVideos { get; set; }
        public DatabaseWrapper<MusicVideoArtistMapper> MusicVideoArtistMapper { get; set; }
        public DatabaseWrapper<MusicVideoArtistTableEntry> MusicVideoArtists { get; set; }
        public DatabaseWrapper<MusicVideoAudioStreamMapper> MusicVideoAudioStreamMapper { get; set; }
        public DatabaseWrapper<MusicVideoDirectorMapper> MusicVideoDirectorMapper { get; set; }
        public DatabaseWrapper<MusicVideoSubtitleStreamMapper> MusicVideoSubtitleStreamMapper { get; set; }
        public DatabaseWrapper<MusicVideoVideoStreamMapper> MusicVideoVideoStreamMapper { get; set; }
        public DatabaseWrapper<MusicVideoGenreMapper> MusicVideoGenreMapper { get; set; }
        public DatabaseWrapper<MusicVideoGenreTableEntry> MusicVideoGenres { get; set; }

        public DatabaseContext CreateContext() {
            return new DatabaseContext(name);
        }

        public async Task Init(string name) {
            this.name = name;
            using (var context = CreateContext()) {
                ILoggerFactory logger = ((IInfrastructure<IServiceProvider>)context).Instance.GetService(typeof(ILoggerFactory)) as ILoggerFactory;
                logger.AddProvider(new DatabaseLoggerProvider());
                await context.Database.MigrateAsync();
            }

            Actors = new DatabaseWrapper<ActorTableEntry>(this);
            AudioStreams = new DatabaseWrapper<AudioStreamTableEntry>(this);
            Directors = new DatabaseWrapper<DirectorTableEntry>(this);
            SubtitleStreams = new DatabaseWrapper<SubtitleStreamTableEntry>(this);
            VideoStreams = new DatabaseWrapper<VideoStreamTableEntry>(this);

            TVShows = new DatabaseWrapper<TVShowTableEntry>(this);
            TVShowGenres = new DatabaseWrapper<TVShowGenreTableEntry>(this);
            TVShowSeasons = new DatabaseWrapper<TVShowSeasonTableEntry>(this);
            TVShowGenreMapper = new DatabaseWrapper<TVShowGenreMapper>(this);
            TVShowActorMapper = new DatabaseWrapper<TVShowActorMapper>(this);

            Episodes = new DatabaseWrapper<EpisodeTableEntry>(this);
            EpisodeActorMapper = new DatabaseWrapper<EpisodeActorMapper>(this);
            EpisodeAudioStreamMapper = new DatabaseWrapper<EpisodeAudioStreamMapper>(this);
            EpisodeDirectorMapper = new DatabaseWrapper<EpisodeDirectorMapper>(this);
            EpisodeSubtitleStreamMapper = new DatabaseWrapper<EpisodeSubtitleStreamMapper>(this);
            EpisodeVideoStreamMapper = new DatabaseWrapper<EpisodeVideoStreamMapper>(this);

            Movies = new DatabaseWrapper<MovieTableEntry>(this);
            MovieSets = new DatabaseWrapper<MovieSetTableEntry>(this);
            MovieSetMapper = new DatabaseWrapper<MovieSetMapper>(this);
            MovieActorMapper = new DatabaseWrapper<MovieActorMapper>(this);
            MovieAudioStreamMapper = new DatabaseWrapper<MovieAudioStreamMapper>(this);
            MovieDirectorMapper = new DatabaseWrapper<MovieDirectorMapper>(this);
            MovieSubtitleStreamMapper = new DatabaseWrapper<MovieSubtitleStreamMapper>(this);
            MovieVideoStreamMapper = new DatabaseWrapper<MovieVideoStreamMapper>(this);
            MovieGenreMapper = new DatabaseWrapper<MovieGenreMapper>(this);
            MovieGenres = new DatabaseWrapper<MovieGenreTableEntry>(this);

            MusicVideoArtistMapper = new DatabaseWrapper<MusicVideoArtistMapper>(this);
            MusicVideoArtists = new DatabaseWrapper<MusicVideoArtistTableEntry>(this);
            MusicVideoAudioStreamMapper = new DatabaseWrapper<MusicVideoAudioStreamMapper>(this);
            MusicVideoDirectorMapper = new DatabaseWrapper<MusicVideoDirectorMapper>(this);
            MusicVideoGenreMapper = new DatabaseWrapper<MusicVideoGenreMapper>(this);
            MusicVideoGenres = new DatabaseWrapper<MusicVideoGenreTableEntry>(this);
            MusicVideos = new DatabaseWrapper<MusicVideoTableEntry>(this);
            MusicVideoSubtitleStreamMapper = new DatabaseWrapper<MusicVideoSubtitleStreamMapper>(this);
            MusicVideoVideoStreamMapper = new DatabaseWrapper<MusicVideoVideoStreamMapper>(this);
        }

        public async Task SaveChangesAsync() {
            await Actors.SaveChangesAsync();
            await AudioStreams.SaveChangesAsync();
            await Directors.SaveChangesAsync();
            await SubtitleStreams.SaveChangesAsync();
            await VideoStreams.SaveChangesAsync();

            await TVShows.SaveChangesAsync();
            await TVShowGenres.SaveChangesAsync();
            await TVShowSeasons.SaveChangesAsync();
            await TVShowGenreMapper.SaveChangesAsync();
            await TVShowActorMapper.SaveChangesAsync();

            await Episodes.SaveChangesAsync();
            await EpisodeActorMapper.SaveChangesAsync();
            await EpisodeAudioStreamMapper.SaveChangesAsync();
            await EpisodeDirectorMapper.SaveChangesAsync();
            await EpisodeSubtitleStreamMapper.SaveChangesAsync();
            await EpisodeVideoStreamMapper.SaveChangesAsync();

            await MovieSets.SaveChangesAsync();
            await Movies.SaveChangesAsync();
            await MovieGenres.SaveChangesAsync();
            await MovieSetMapper.SaveChangesAsync();
            await MovieGenreMapper.SaveChangesAsync();
            await MovieActorMapper.SaveChangesAsync();
            await MovieAudioStreamMapper.SaveChangesAsync();
            await MovieDirectorMapper.SaveChangesAsync();
            await MovieSubtitleStreamMapper.SaveChangesAsync();
            await MovieVideoStreamMapper.SaveChangesAsync();

            await MusicVideos.SaveChangesAsync();
            await MusicVideoArtists.SaveChangesAsync();
            await MusicVideoGenres.SaveChangesAsync();
            await MusicVideoArtistMapper.SaveChangesAsync();
            await MusicVideoAudioStreamMapper.SaveChangesAsync();
            await MusicVideoDirectorMapper.SaveChangesAsync();
            await MusicVideoGenreMapper.SaveChangesAsync();
            await MusicVideoSubtitleStreamMapper.SaveChangesAsync();
            await MusicVideoVideoStreamMapper.SaveChangesAsync();
        }
    }
}
