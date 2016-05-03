using KodiRemote.Code.Database;
using KodiRemote.Code.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public class SettingsViewModel : ViewModelBase {
        private List<KodiSettings> kodiList;
        public List<KodiSettings> KodiList {
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
                selectedKodi = value;
                if (value != null) {
                    //value.GetInfo().Start();
                    Task.Run(async () => await value.GetInfo());
                }
                RaisePropertyChanged();
            }
        }


        public async Task Init() {
            KodiList = await SettingsDatabase.Instance.GetAllKodis();
            SelectedKodi = KodiList?.Where(x => x.Active).FirstOrDefault();
        }
    }
}
