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
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            ViewModel = await EpisodeDetailsViewModel.Init(e.Parameter as EpisodeTableEntry);
            base.OnNavigatedTo(e);
        }
        
        private void ActorClicked(object sender, ItemClickEventArgs e) {
            var vm = e.ClickedItem as ActorViewModel;
            Frame.Navigate(typeof(ActorDetailsPage), vm.Item);
        }
    }
}
