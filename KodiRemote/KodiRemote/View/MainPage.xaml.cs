using KodiRemote.View.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking;
using Windows.Networking.Sockets;
using System.Diagnostics;
using Windows.Storage.Streams;
using Windows.Web;
using System.Threading;
using KodiRemote.Code.JSON;
using KodiRemote.Code.Utils;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.WebSocketServices;
using KodiRemote.Code.JSON.KPlayer.Results;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace KodiRemote.View {
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : PageBase {
        public MainPage() {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e) {
            contentFrame.Navigate(typeof(HomePage));
            start();
        }


        PlayerWebSocketService service;
        private async void start() {
            WebSocketHelper helper = new WebSocketHelper();
            Uri server = new Uri("ws://localhost:9090/jsonrpc");
            await helper.Connect(server);
            service = new PlayerWebSocketService(helper);
            service.ItemReceived += Service_ItemReceived;
            service.PlayersReceived += Service_PlayersReceived;
            service.OnPauseReceived += Service_OnPauseReceived;
            //service.GetActivePlayers();
        }

        private void Service_OnPauseReceived(Code.JSON.KPlayer.Notifications.Data item) {
            Debug.WriteLine(item.Item.type);
        }

        private void Service_PlayersReceived(List<Player> item) {
            Debug.WriteLine(item);
            if (item.Any()) {
                service.GetItem(item.First().PlayerId);
            }
        }

        private void Service_ItemReceived(Item item) {
            Debug.WriteLine(item);
        }

        private void Helper_ConnectionClosed(string message) {
            Debug.WriteLine(message);
        }

        private void Helper_MessageReceived(string message) {
            Debug.WriteLine(message);
        }

    }
}
