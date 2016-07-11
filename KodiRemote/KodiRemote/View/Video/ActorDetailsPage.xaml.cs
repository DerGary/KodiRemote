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
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.Utils;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.ViewModel.Video;
using KodiRemote.Code.Database.TVShowTables;

namespace KodiRemote.View.Video {
    public sealed partial class ActorDetailsPage : PageBase {
        private ActorDetailsViewModel viewModel;
        public ActorDetailsViewModel ViewModel {
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

        public ActorDetailsPage() {
            this.InitializeComponent();
            Loaded += ActorDetailsPage_Loaded;
        }

        private void ActorDetailsPage_Loaded(object sender, RoutedEventArgs e) {
            if (NavigationMode == NavigationMode.Back) {
                ScrollViewer.ChangeView(App.ScrollViewerHorizontalOffset.Pop(), 0, 1, true);
                PopInAnimation(ScrollViewer, ProgressRing);
            }
        }

        #region Navigation
        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back) {
                ViewModel = (ActorDetailsViewModel)App.ViewModels.Pop();
            } else {
                ViewModel = new ActorDetailsViewModel(e.Parameter as ActorTableEntry);
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

        private void ItemClick(object sender, ItemClickEventArgs e) {
            var vm = e.ClickedItem as ItemViewModel;
            var movie = vm.Item as MovieTableEntry;
            if (movie != null) {
                Frame.Navigate(typeof(MovieDetailsPage), movie);
            }
            var tvshow = vm.Item as TVShowTableEntry;
            if(tvshow != null) {
                Frame.Navigate(typeof(TVShowDetailsPage), tvshow);
            }
        }
    }
}
