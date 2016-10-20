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
using KodiRemote.Code.Database.GeneralTables;

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
            Loaded += TVShowDetailsPage_Loaded;
        }

        private void TVShowDetailsPage_Loaded(object sender, RoutedEventArgs e) {
            if (NavigationMode == NavigationMode.Back) {
                ScrollViewer.ChangeView(App.ScrollViewerHorizontalOffset.Pop(), 0, 1, true);
                PopInAnimation(ScrollViewer, ProgressRing);
            }
        }

        #region Navigation
        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back) {
                ViewModel = (TVShowDetailsViewModel)App.ViewModels.Pop();
            } else {
                ViewModel = new TVShowDetailsViewModel(e.Parameter as TVShowTableEntry);
                await ViewModel.Init();
                PopInAnimation(ScrollViewer, ProgressRing);
            }
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            if (e.NavigationMode != NavigationMode.Back) {
                App.ScrollViewerHorizontalOffset.Push(ScrollViewer.HorizontalOffset);
                App.ViewModels.Push(ViewModel);
            }
            base.OnNavigatingFrom(e);
        }
        #endregion Navigation


        private void ActorClicked(ActorTableEntry item) {
            Frame.Navigate(typeof(ActorDetailsPage), item);
        }

        private void TVShowSeasonClicked(TVShowSeasonTableEntry item) {
            Frame.Navigate(typeof(TVShowSeasonDetailsPage), item);
        }
    }
}
