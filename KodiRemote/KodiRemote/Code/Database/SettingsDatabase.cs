using KodiRemote.Code.Essentials;
using SQLite.Net.Attributes;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Database {
    public class SettingsDatabase {
        private SettingsDatabase() { }

        private SQLiteAsyncConnection connection;

        private static SettingsDatabase instance;
        public static SettingsDatabase Instance {
            get {
                if (instance == null) {
                    throw new InvalidOperationException("You have to call init first");
                }
                return instance;
            }
        }

        public static async Task Init() {
            var lo = new SQLite.Net.SQLiteConnectionWithLock(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), new SQLite.Net.SQLiteConnectionString("Settings.s3db", false));
            instance.connection = new SQLiteAsyncConnection(() => lo);
            //instance.connection = new SQLiteAsyncConnection("Settings.s3db");
            await instance.connection.CreateTableAsync<KodiSettings>();
        }

        public async Task<List<KodiSettings>> GetAllKodis() {
            var query = connection.Table<KodiSettings>();
            return await query.ToListAsync();
        }

        public async Task<KodiSettings> GetActiveKodi() {
            var query = connection.Table<KodiSettings>();
            return await query.Where(x => x.Active == true).FirstOrDefaultAsync();
        }

        public async Task InsertOrUpdateKodi(KodiSettings settings) {
            if (settings.Active) {
                KodiSettings currentlyActive = await GetActiveKodi();
                if (currentlyActive != null) {
                    currentlyActive.Active = false;
                    await connection.UpdateAsync(currentlyActive);
                }
            }
            await connection.InsertOrReplaceAsync(settings);
        }
        public async Task Remove(KodiSettings settings) {
            await connection.DeleteAsync(settings);
            if (settings.Active) {
                var nowActive = (await GetAllKodis()).FirstOrDefault();
                if (nowActive != null) {
                    nowActive.Active = true;
                    await connection.UpdateAsync(nowActive);
                }
            }
        }
    }
}
