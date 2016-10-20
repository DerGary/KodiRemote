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
using KodiRemote.Code.Common;

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
            Loaded += TVShowSeasonDetailsPage_Loaded;
        }

        private void TVShowSeasonDetailsPage_Loaded(object sender, RoutedEventArgs e) {
            if (NavigationMode == NavigationMode.Back) {
                EpisodeListView.SetVerticalScrollOffset(App.ScrollViewerVerticalOffset.Pop());
                PopInAnimation(ScrollViewer, ProgressRing);
            }
        }

        #region Navigation
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back) {
                ViewModel = (TVShowSeasonDetailsViewModel)App.ViewModels.Pop();
            } else {
                ViewModel = new TVShowSeasonDetailsViewModel(e.Parameter as TVShowSeasonTableEntry);
                PopInAnimation(ScrollViewer, ProgressRing);
            }
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            if (e.NavigationMode != NavigationMode.Back) {
                App.ScrollViewerVerticalOffset.Push(EpisodeListView.GetVerticalScrollOffset());
                App.ViewModels.Push(ViewModel);
            }
            base.OnNavigatingFrom(e);
        }
        #endregion Navigation

        private void EpisodeClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            Frame.Navigate(typeof(EpisodeDetailsPage), viewModel.Item);
        }
    }
}
