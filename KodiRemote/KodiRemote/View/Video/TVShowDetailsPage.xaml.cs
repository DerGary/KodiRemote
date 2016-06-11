using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Essentials;
using KodiRemote.View.Base;
using KodiRemote.ViewModel.Video;

namespace KodiRemote.View.Video {
    public sealed partial class TVShowDetailsPage : PageBase {
        private TVShowDetailsViewModel viewmodel;
        public TVShowDetailsViewModel ViewModel {
            get {
                return viewmodel;
            }
            set {
                viewmodel = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ViewModelBase));
            }
        }

        public override ViewModelBase ViewModelBase => ViewModel;

        public TVShowDetailsPage() {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            ViewModel = await TVShowDetailsViewModel.Init(e.Parameter as TVShowTableEntry);
            base.OnNavigatedTo(e);
        }

        private void SeasonClick(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            Frame.Navigate(typeof(TVShowSeasonDetailsPage), viewModel.Item);
        }

        private void ActorClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ActorViewModel;
            Frame.Navigate(typeof(ActorDetailsPage), viewModel.Item);
        }
    }
}
