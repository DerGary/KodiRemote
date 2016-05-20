using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KodiRemote.Code.Database {
    public class DatabaseContext : DbContext {
        public DbSet<ActorTableEntry> Actors { get; set; }
        public DbSet<AudioStreamTableEntry> AudioStreams { get; set; }
        public DbSet<DirectorTableEntry> Directors { get; set; }
        public DbSet<SubtitleStreamTableEntry> SubtitleStreams { get; set; }
        public DbSet<VideoStreamTableEntry> VideoStreams { get; set; }
        
        public DbSet<TVShowTableEntry> TVShows { get; set; }
        public DbSet<TVShowGenreTableEntry> TVShowGenres { get; set; }
        public DbSet<TVShowSeasonTableEntry> TVShowSeasons { get; set; }
        public DbSet<TVShowGenreMapper> TVShowGenreMapper { get; set; }
        public DbSet<TVShowActorMapper> TVShowActorMapper { get; set; }

        public DbSet<EpisodeTableEntry> Episodes { get; set; }
        public DbSet<EpisodeActorMapper> EpisodeActorMapper { get; set; }
        public DbSet<EpisodeAudioStreamMapper> EpisodeAudioStreamMapper { get; set; }
        public DbSet<EpisodeDirectorMapper> EpisodeDirectorMapper { get; set; }
        public DbSet<EpisodeSubtitleStreamMapper> EpisodeSubtitleStreamMapper { get; set; }
        public DbSet<EpisodeVideoStreamMapper> EpisodeVideoStreamMapper { get; set; }

        public DbSet<MovieActorMapper> MovieActorMapper { get; set; }
        public DbSet<MovieAudioStreamMapper> MovieAudioStreamMapper { get; set; }
        public DbSet<MovieDirectorMapper> MovieDirectorMapper { get; set; }
        public DbSet<MovieGenreMapper> MovieGenreMapper { get; set; }
        public DbSet<MovieGenreTableEntry> MovieGenres { get; set; }
        public DbSet<MovieSetTableEntry> MovieSets { get; set; }
        public DbSet<MovieSetMapper> MovieSetMapper { get; set; }
        public DbSet<MovieSubtitleStreamMapper> MovieSubtitleStreamMapper { get; set; }
        public DbSet<MovieTableEntry> Movies { get; set; }
        public DbSet<MovieVideoStreamMapper> MovieVideoStreamMapper { get; set; }


        private string name;
        public DatabaseContext(string name) : base() {
            this.name = name;
        }
        public DatabaseContext() : base() { }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.EnableSensitiveDataLogging();
            string databaseFilePath = name+".s3db";
            try {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            } catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            CreateTVShowModel(modelBuilder);
            CreateEpisodeModel(modelBuilder);
            CreateMovieModel(modelBuilder);
        }

        public void CreateTVShowModel(ModelBuilder modelBuilder) {
            //TVShowGenreMapper
            modelBuilder.Entity<TVShowGenreMapper>()
                .HasKey(t => new { t.TVShowId, t.GenreId });

            modelBuilder.Entity<TVShowGenreMapper>()
                .HasOne(pt => pt.TVShow)
                .WithMany(p => p.Genres)
                .HasForeignKey(pt => pt.TVShowId);

            modelBuilder.Entity<TVShowGenreMapper>()
                .HasOne(pt => pt.Genre)
                .WithMany(t => t.TVShows)
                .HasForeignKey(pt => pt.GenreId);

            //TVShowGenre
            modelBuilder.Entity<TVShowGenreTableEntry>()
                .HasAlternateKey(x => x.Genre)
                .HasName("AK_string_Genre");

            //TVShowActorMapper
            modelBuilder.Entity<TVShowActorMapper>()
                .HasKey(t => new { t.TVShowId, t.ActorId });

            modelBuilder.Entity<TVShowActorMapper>()
                .HasOne(pt => pt.TVShow)
                .WithMany(p => p.Actors)
                .HasForeignKey(pt => pt.TVShowId);

            modelBuilder.Entity<TVShowActorMapper>()
                .HasOne(pt => pt.Actor)
                .WithMany(t => t.TVShows)
                .HasForeignKey(pt => pt.ActorId);


            //TVShowSeason
            modelBuilder.Entity<TVShowSeasonTableEntry>()
                .HasKey(p => new { p.TVShowId, p.Season });

            modelBuilder.Entity<TVShowSeasonTableEntry>()
                .Property(x => x.TVShowId)
                .ValueGeneratedNever();


        }

        public void CreateEpisodeModel(ModelBuilder modelBuilder) {
            //EpisodeActorMapper
            modelBuilder.Entity<EpisodeActorMapper>()
                .HasKey(t => new { t.EpisodeId, t.ActorId });

            modelBuilder.Entity<EpisodeActorMapper>()
                .HasOne(pt => pt.Episode)
                .WithMany(p => p.Actors)
                .HasForeignKey(pt => pt.EpisodeId);

            modelBuilder.Entity<EpisodeActorMapper>()
                .HasOne(pt => pt.Actor)
                .WithMany(t => t.Episodes)
                .HasForeignKey(pt => pt.ActorId);


            //EpisodeAudioStreamMapper
            modelBuilder.Entity<EpisodeAudioStreamMapper>()
                .HasKey(t => new { t.EpisodeId, t.AudioStreamId });

            modelBuilder.Entity<EpisodeAudioStreamMapper>()
                .HasOne(pt => pt.Episode)
                .WithMany(p => p.AudioStreams)
                .HasForeignKey(pt => pt.EpisodeId);

            modelBuilder.Entity<EpisodeAudioStreamMapper>()
                .HasOne(pt => pt.AudioStream)
                .WithMany(t => t.Episodes)
                .HasForeignKey(pt => pt.AudioStreamId);


            //EpisodeDirectorMapper
            modelBuilder.Entity<EpisodeDirectorMapper>()
                .HasKey(t => new { t.EpisodeId, t.DirectorId });

            modelBuilder.Entity<EpisodeDirectorMapper>()
                .HasOne(pt => pt.Episode)
                .WithMany(p => p.Directors)
                .HasForeignKey(pt => pt.EpisodeId);

            modelBuilder.Entity<EpisodeDirectorMapper>()
                .HasOne(pt => pt.Director)
                .WithMany(t => t.Episodes)
                .HasForeignKey(pt => pt.DirectorId);


            //EpisodeSubtitleStreamMapper
            modelBuilder.Entity<EpisodeSubtitleStreamMapper>()
                .HasKey(t => new { t.EpisodeId, t.SubtitleStreamId });

            modelBuilder.Entity<EpisodeSubtitleStreamMapper>()
                .HasOne(pt => pt.Episode)
                .WithMany(p => p.SubtitleStreams)
                .HasForeignKey(pt => pt.EpisodeId);

            modelBuilder.Entity<EpisodeSubtitleStreamMapper>()
                .HasOne(pt => pt.SubtitleStream)
                .WithMany(t => t.Episodes)
                .HasForeignKey(pt => pt.SubtitleStreamId);


            //EpisodeSubtitleStreamMapper
            modelBuilder.Entity<EpisodeVideoStreamMapper>()
                .HasKey(t => new { t.EpisodeId, t.VideoStreamId });

            modelBuilder.Entity<EpisodeVideoStreamMapper>()
                .HasOne(pt => pt.Episode)
                .WithMany(p => p.VideoStreams)
                .HasForeignKey(pt => pt.EpisodeId);

            modelBuilder.Entity<EpisodeVideoStreamMapper>()
                .HasOne(pt => pt.VideoStream)
                .WithMany(t => t.Episodes)
                .HasForeignKey(pt => pt.VideoStreamId);


            //Map Episode to Season
            modelBuilder.Entity<EpisodeTableEntry>()
               .HasOne(e => e.TVShowSeason)
               .WithMany(c => c.Episodes)
               .HasForeignKey(e => new { e.TVShowId, e.Season });
        }

        public void CreateMovieModel(ModelBuilder modelBuilder) {
            //MovieGenreMapper
            modelBuilder.Entity<MovieGenreMapper>()
                .HasKey(t => new { t.MovieId, t.GenreId });

            modelBuilder.Entity<MovieGenreMapper>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.Genres)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieGenreMapper>()
                .HasOne(pt => pt.Genre)
                .WithMany(t => t.Movies)
                .HasForeignKey(pt => pt.GenreId);

            //MovieGenre
            modelBuilder.Entity<MovieGenreTableEntry>()
                .HasAlternateKey(x => x.Genre)
                .HasName("AK_string_Genre");

            //MovieActorMapper
            modelBuilder.Entity<MovieActorMapper>()
                .HasKey(t => new { t.MovieId, t.ActorId });

            modelBuilder.Entity<MovieActorMapper>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.Actors)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieActorMapper>()
                .HasOne(pt => pt.Actor)
                .WithMany(t => t.Movies)
                .HasForeignKey(pt => pt.ActorId);


            //MovieAudioStreamMapper
            modelBuilder.Entity<MovieAudioStreamMapper>()
                .HasKey(t => new { t.MovieId, t.AudioStreamId });

            modelBuilder.Entity<MovieAudioStreamMapper>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.AudioStreams)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieAudioStreamMapper>()
                .HasOne(pt => pt.AudioStream)
                .WithMany(t => t.Movies)
                .HasForeignKey(pt => pt.AudioStreamId);


            //MovieDirectorMapper
            modelBuilder.Entity<MovieDirectorMapper>()
                .HasKey(t => new { t.MovieId, t.DirectorId });

            modelBuilder.Entity<MovieDirectorMapper>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.Directors)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieDirectorMapper>()
                .HasOne(pt => pt.Director)
                .WithMany(t => t.Movies)
                .HasForeignKey(pt => pt.DirectorId);


            //MovieSubtitleStreamMapper
            modelBuilder.Entity<MovieSubtitleStreamMapper>()
                .HasKey(t => new { t.MovieId, t.SubtitleStreamId });

            modelBuilder.Entity<MovieSubtitleStreamMapper>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.SubtitleStreams)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieSubtitleStreamMapper>()
                .HasOne(pt => pt.SubtitleStream)
                .WithMany(t => t.Movies)
                .HasForeignKey(pt => pt.SubtitleStreamId);


            //MovieSubtitleStreamMapper
            modelBuilder.Entity<MovieVideoStreamMapper>()
                .HasKey(t => new { t.MovieId, t.VideoStreamId });

            modelBuilder.Entity<MovieVideoStreamMapper>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.VideoStreams)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieVideoStreamMapper>()
                .HasOne(pt => pt.VideoStream)
                .WithMany(t => t.Movies)
                .HasForeignKey(pt => pt.VideoStreamId);

            //MovieSetMapper
            modelBuilder.Entity<MovieSetMapper>()
                .HasKey(t => new { t.MovieId, t.MovieSetId });

            modelBuilder.Entity<MovieSetMapper>()
                .HasOne(pt => pt.Movie)
                .WithMany(p => p.MovieSets)
                .HasForeignKey(pt => pt.MovieId);

            modelBuilder.Entity<MovieSetMapper>()
                .HasOne(pt => pt.MovieSet)
                .WithMany(t => t.Movies)
                .HasForeignKey(pt => pt.MovieSetId);

        }
    }

}
