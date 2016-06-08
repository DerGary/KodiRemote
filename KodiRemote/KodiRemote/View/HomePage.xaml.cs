using KodiRemote.Code.Essentials;
using KodiRemote.Code.Utils;
using KodiRemote.View.Base;
using KodiRemote.ViewModel;
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

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace KodiRemote.View {
    public sealed partial class HomePage : PageBase {
        private HomeViewModel viewModel = new HomeViewModel();
        public HomeViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                viewModel = value;
                RaisePropertyChanged();
            }
        }


        public override ViewModelBase ViewModelBase { get { return ViewModel; } }

        public HomePage() {
            this.InitializeComponent();
        }

        private void itemGridView_ItemClick(object sender, ItemClickEventArgs e) {
            this.Frame.Navigate(typeof(RemoteControlPage));
        }
    }
}
