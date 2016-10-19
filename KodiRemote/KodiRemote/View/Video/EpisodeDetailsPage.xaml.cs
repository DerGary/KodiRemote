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
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.ViewModel.Video;

namespace KodiRemote.View.Video {
    public sealed partial class EpisodeDetailsPage : PageBase {
        private EpisodeDetailsViewModel viewModel;
        public EpisodeDetailsViewModel ViewModel {
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

        public EpisodeDetailsPage() {
            this.InitializeComponent();
            Loaded += EpisodeDetailsPage_Loaded;
        }

        private void EpisodeDetailsPage_Loaded(object sender, RoutedEventArgs e) {
            if (NavigationMode == NavigationMode.Back) {
                ScrollViewer.ChangeView(App.ScrollViewerHorizontalOffset.Pop(), 0, 1, true);
                PopInAnimation(ScrollViewer, ProgressRing);
            }
        }

        #region Navigation
        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            if (e.NavigationMode == NavigationMode.Back) {
                ViewModel = (EpisodeDetailsViewModel)App.ViewModels.Pop();
            } else {
                ViewModel = new EpisodeDetailsViewModel(e.Parameter as EpisodeTableEntry);
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

        private void ActorClicked(Code.Database.GeneralTables.ActorTableEntry item) {
            Frame.Navigate(typeof(ActorDetailsPage), item);
        }
    }
}
