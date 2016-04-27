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
    public sealed partial class MainPage : Page {


        public MainPage() {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e) {
            SplitView.ContentFrame.Navigate(typeof(HomePage));
        }
    }
}
