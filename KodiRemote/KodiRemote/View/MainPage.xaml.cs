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

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace KodiRemote.View
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : PageBase
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(HomePage));
            start();
        }

        

        private async void start()
        {
            WebSocketHelper helper = new WebSocketHelper();
            Uri server = new Uri("ws://localhost:9090/jsonrpc");
            helper.MessageReceived += Helper_MessageReceived;
            helper.ConnectionClosed += Helper_ConnectionClosed;
            await helper.Connect(server);
        }

        private void Helper_ConnectionClosed(string message)
        {
            Debug.WriteLine(message);
        }

        private void Helper_MessageReceived(string message)
        {
            Debug.WriteLine(message);
        }

    }
}
