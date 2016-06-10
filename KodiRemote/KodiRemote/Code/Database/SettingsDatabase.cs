using KodiRemote.Code.Essentials;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;

namespace KodiRemote.Code.Database {
    public class SettingsDatabase {
        private SettingsDatabase() { }

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
        }

        public static async Task Init() {
            instance = new SettingsDatabase();
            using (var context = new SettingsContext()) {
                await context.Database.MigrateAsync();
            }
        }

        public async Task<List<KodiSettings>> GetAllKodis() {
            using (var context = new SettingsContext()) {
                return await GetAllKodis(context);
            }
        }

        public async Task<KodiSettings> GetActiveKodi() {
            using (var context = new SettingsContext()) {
                return await GetActiveKodi(context);
            }
        }
        private async Task<List<KodiSettings>> GetAllKodis(SettingsContext context) {
            return await context.Kodis.ToListAsync();
        }
        private async Task<KodiSettings> GetActiveKodi(SettingsContext context) {
            return await context.Kodis.FirstOrDefaultAsync(x => x.Active == true);
        }
        SemaphoreSlim semaphore = new SemaphoreSlim(1);

        public async Task InsertOrUpdateKodi(KodiSettings settings) {
            await semaphore.WaitAsync();
            List<KodiSettings> all;

            using (var context = new SettingsContext()) {
                all = await GetAllKodis(context);
            }
            if (settings.Active) {
                KodiSettings currentlyActive = all.FirstOrDefault(x => x.Active);
                
                if (currentlyActive != null && !currentlyActive.Equals(settings)) {
                    currentlyActive.Active = false;

                    using (var context = new SettingsContext()) {
                        context.Kodis.Update(currentlyActive);
                        await context.SaveChangesAsync();
                    }
                }
                await Kodi.Init(settings);
            }
            using (var context = new SettingsContext()) {
                if (all.Contains(settings)) {
                    context.Kodis.Update(settings);
                } else {
                    context.Kodis.Add(settings);
                }
                await context.SaveChangesAsync();
            }
            semaphore.Release();
        }
        public async Task Remove(KodiSettings settings) {
            using (var context = new SettingsContext()) {
                context.Kodis.Remove(settings);
                if (settings.Active) {
                    var nowActive = (await GetAllKodis()).FirstOrDefault();
                    if (nowActive != null) {
                        nowActive.Active = true;
                        context.Kodis.Update(nowActive);
                    }
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
