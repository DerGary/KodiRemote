using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.Essentials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public class SettingsViewModel : ViewModelBase {
        private ObservableCollection<KodiSettings> kodiList;
        public ObservableCollection<KodiSettings> KodiList {
            get {
                return kodiList;
            }
            set {
                kodiList = value;
                RaisePropertyChanged();
            }
        }

        private KodiSettings selectedKodi;
        public KodiSettings SelectedKodi {
            get {
                return selectedKodi;
            }
            set {
                if (selectedKodi != value) {
                    selectedKodi = value;
                    if (value != null) {
                        Task.Run(async () => await value.TriggerGetInfo());
                    }
                    RaisePropertyChanged();
                }
            }
        }

        public async Task Init() {
            KodiList = new ObservableCollection<KodiSettings>(await SettingsDatabase.Instance.GetAllKodis());
            SelectedKodi = KodiList?.Where(x => x.Active).FirstOrDefault();
            foreach (KodiSettings kodi in KodiList) {
                Task.Run(async () => await kodi.CheckOnlineStatus());
            }
        }

        private RelayCommand removeKodi;
        public RelayCommand RemoveKodi {
            get {
                if (removeKodi == null) {
                    removeKodi = new RelayCommand(async () => {
                        await SettingsDatabase.Instance.Remove(SelectedKodi);
                        KodiList.Remove(SelectedKodi);
                        SelectedKodi = await SettingsDatabase.Instance.GetActiveKodi();
                    });
                }
                return removeKodi;
            }
        }
        private RelayCommand updateKodiDatabase;
        public RelayCommand UpdateKodiDatabase {
            get {
                if (updateKodiDatabase == null) {
                    updateKodiDatabase = new RelayCommand(async () => {
                        await SelectedKodi.UpdateDatabase();
                    });
                }
                return updateKodiDatabase;
            }
        }
    }
}
