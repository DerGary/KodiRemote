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
        public DbSet<TVShowTableEntry> TVShows { get; set; }
        public DbSet<TVShowActorsTableEntry> TVShowActors { get; set; }
        public DbSet<TVShowGenreTableEntry> TVShowGenres { get; set; }
        public DbSet<TVShowSeasonTableEntry> TVShowSeasons { get; set; }
        public DbSet<TVShowGenre> TVShowGenre { get; set; }

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
            modelBuilder.Entity<TVShowGenre>()
                .HasKey(t => new { t.TVShowId, t.GenreId });

            modelBuilder.Entity<TVShowGenre>()
                .HasOne(pt => pt.TVShow)
                .WithMany(p => p.Genres)
                .HasForeignKey(pt => pt.TVShowId);

            modelBuilder.Entity<TVShowGenre>()
                .HasOne(pt => pt.Genre)
                .WithMany(t => t.TVShows)
                .HasForeignKey(pt => pt.GenreId);

            modelBuilder.Entity<TVShowSeasonTableEntry>()
                .HasKey(p => new { p.TVShowId, p.Season });

            modelBuilder.Entity<TVShowSeasonTableEntry>()
                .Property(x => x.TVShowId)
                .ValueGeneratedNever();

            modelBuilder.Entity<TVShowGenreTableEntry>()
                .HasAlternateKey(x => x.Genre)
                .HasName("AK_string_Genre");
        }
    }
    public class MyLoggerProvider : ILoggerProvider {
        MyLogger logger;
        public ILogger CreateLogger(string categoryName) {
            logger = new MyLogger();
            return logger;
        }

        public void Dispose() {
            logger = null;
        }
    }
    public class MyLogger : ILogger {
        public IDisposable BeginScopeImpl(object state) {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel) {
            return true;
        }

        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter) {
            Debug.WriteLine(formatter(state, exception), "DB");
        }
    }
}
