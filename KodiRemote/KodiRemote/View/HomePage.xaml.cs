using KodiRemote.Code.Essentials;
using KodiRemote.Code.Utils;
using KodiRemote.View.Base;
using KodiRemote.View.Settings;
using KodiRemote.View.Video;
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
                RaisePropertyChanged(nameof(ViewModelBase));
            }
        }


        public override ViewModelBase ViewModelBase => ViewModel; 

        public HomePage() {
            this.InitializeComponent();
        }

        private void itemGridView_ItemClick(object sender, ItemClickEventArgs e) {
            if(e.ClickedItem == TVShowsGrid) {
                this.Frame.Navigate(typeof(CollectionPage), PageType.TVShows);
            } else if (e.ClickedItem == MoviesGrid) {
                this.Frame.Navigate(typeof(CollectionPage), PageType.Movies);
            } else if (e.ClickedItem == MovieSetsGrid) {
                this.Frame.Navigate(typeof(CollectionPage), PageType.MovieSets);
            } else if (e.ClickedItem == RemoteControlGrid) {
                this.Frame.Navigate(typeof(RemoteControlPage));
            } else if (e.ClickedItem == SettingsGrid) {
                this.Frame.Navigate(typeof(SettingsPage));
            }
        }
    }
}
