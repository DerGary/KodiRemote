using KodiRemote.Code.Essentials;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KodiRemote.Code.Database {
    public class SettingsContext : DbContext {
        public DbSet<KodiSettings> Kodis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string databaseFilePath = "Settings.s3db";
            try {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            } catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }
    }
}
