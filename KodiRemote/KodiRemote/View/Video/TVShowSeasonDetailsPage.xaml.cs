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
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Video;
using KodiRemote.Code.Database.TVShowTables;

namespace KodiRemote.View.Video {
    public sealed partial class TVShowSeasonDetailsPage : PageBase {
        private TVShowSeasonDetailsViewModel viewModel;
        public TVShowSeasonDetailsViewModel ViewModel {
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

        public TVShowSeasonDetailsPage() {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            ViewModel = await TVShowSeasonDetailsViewModel.Init(e.Parameter as TVShowSeasonTableEntry);
            base.OnNavigatedTo(e);
        }

        private void EpisodeItemClick(object sender, ItemClickEventArgs e) {

        }
    }
}
