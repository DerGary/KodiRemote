using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.Essentials;
using KodiRemote.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace KodiRemote.ViewModel {
    public class AddKodiViewModel : ViewModelBase {
        private KodiSettings kodiSettings;
        public KodiSettings KodiSettings {
            get {
                return kodiSettings;
            }
            set {
                kodiSettings = value;
                RaisePropertyChanged();
            }
        }
        private List<ConnectionType> connectionTypes = new List<ConnectionType>() {
                    ConnectionType.Websocket
        };
        public List<ConnectionType> ConnectionTypes {
            get {
                return connectionTypes;
            }
        }

        private RelayCommand addKodi;
        public RelayCommand AddKodi {
            get {
                if (addKodi == null) {
                    addKodi = new RelayCommand(async () => {
                        int port;
                        if (string.IsNullOrEmpty(kodiSettings.Name)
                        || string.IsNullOrEmpty(kodiSettings.Hostname)
                        || !int.TryParse(kodiSettings.Port, out port)
                        || port < 1
                        || port > 65535
                        || (await SettingsDatabase.Instance.GetAllKodis()).FirstOrDefault(x => x.Name == kodiSettings.Name) != null) {
                            await new MessageDialog("Your given Settings are not valid. You have to provide a unique name, a hostname and a Port >=1 & <=65535.", "Fields contain Errors").ShowAsync();
                        } else {
                            await SettingsDatabase.Instance.InsertOrUpdateKodi(KodiSettings);
                            frame.GoBack();
                        }
                    });
                }
                return addKodi;
            }
        }

        private Frame frame;
        public AddKodiViewModel(Frame frame) {
            this.frame = frame;
            KodiSettings = new KodiSettings() { Type = connectionTypes.First() };
        }
    }
}
