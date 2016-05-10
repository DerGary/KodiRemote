using KodiRemote.Code.Essentials;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KodiRemote.Code.Database {
    public class SettingsDatabase {
        private SettingsDatabase() { }

        private SettingsContext database;

        private static SettingsDatabase instance;
        public static SettingsDatabase Instance {
            get {
                if (instance == null) {
                    throw new InvalidOperationException("You have to call init first");
                }
                return instance;
            }
        }
        ~SettingsDatabase() {
            database.Dispose();
        }

        public static async Task Init() {
            instance = new SettingsDatabase();
            instance.database = new SettingsContext();
            await instance.database.Database.MigrateAsync();
        }

        public async Task<List<KodiSettings>> GetAllKodis() {
            return await database.Kodis.ToListAsync();
        }

        public async Task<KodiSettings> GetActiveKodi() {
            return await database.Kodis.FirstOrDefaultAsync(x => x.Active == true);
        }

        public async Task InsertOrUpdateKodi(KodiSettings settings) {
            if (settings.Active) {
                KodiSettings currentlyActive = await GetActiveKodi();
                if (currentlyActive != null && currentlyActive != settings) {
                    currentlyActive.Active = false;
                    database.Kodis.Update(currentlyActive);
                }
            }
            if (database.Kodis.Contains(settings)) {
                database.Kodis.Update(settings);
            } else {
                database.Kodis.Add(settings);
            }
            await database.SaveChangesAsync();
        }
        public async Task Remove(KodiSettings settings) {
            database.Kodis.Remove(settings);
            if (settings.Active) {
                var nowActive = (await GetAllKodis()).FirstOrDefault();
                if (nowActive != null) {
                    nowActive.Active = true;
                    database.Kodis.Update(nowActive);
                }
            }
            await database.SaveChangesAsync();
        }
    }
}
