using KodiRemote.Code.Common;
using KodiRemote.Code.Database;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.JSON;
using KodiRemote.Code.Utils;
using KodiRemote.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace KodiRemote.ViewModel.Settings {
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
                        int websocketPort;
                        if (string.IsNullOrEmpty(kodiSettings.Name)
                        || string.IsNullOrEmpty(kodiSettings.Hostname)
                        || !int.TryParse(kodiSettings.Port, out port)
                        || !int.TryParse(kodiSettings.WebsocketPort, out websocketPort)
                        || port < 1
                        || port > 65535
                        || websocketPort < 1
                        || websocketPort > 65535
                        || (await SettingsDatabase.Instance.GetAllKodis()).FirstOrDefault(x => x.Name == kodiSettings.Name) != null) {
                            await new MessageDialog("Your given Settings are not valid. You have to provide a unique name, a hostname and a Port >=1 & <=65535.", "Fields contain Errors").ShowAsync();
                            return;
                        }

                        using (var client = new HttpClientWrapper(kodiSettings.Username, kodiSettings.Password)){
                            var result = await client.PostAsync<string>(kodiSettings.HttpUrl, new RPCRequest(Code.JSON.KJSONRPC.Method.Ping, Guid.NewGuid().ToString()));
                            if(result.Result == "pong") {
                                await SaveAndLeavePage();
                            } else {
                                var messagedialog = new MessageDialog("It wasn't possible to connect to the Kodi instance with the provided settings. If Kodi is currently not in the same network you can proceed, otherwise please check Ip, Port, Hostname, Username and Password.", "Couldn't connect to Kodi");
                                messagedialog.Commands.Add(new UICommand("Yes") { Id = 1 });
                                messagedialog.Commands.Add(new UICommand("No") { Id = 2 });
                                var chosenCommand = await messagedialog.ShowAsync();
                                if((int)chosenCommand.Id == 1) {
                                    await SaveAndLeavePage();
                                }
                            }
                        }


                    });
                }
                return addKodi;
            }
        }

        private async Task SaveAndLeavePage() {
            await SettingsDatabase.Instance.InsertOrUpdateKodi(KodiSettings);
            frame.GoBack();
        }

        private Frame frame;
        public AddKodiViewModel(Frame frame) {
            this.frame = frame;
            Title = "Add Kodi";
            KodiSettings = new KodiSettings() { Type = connectionTypes.First() };
        }
    }
}
