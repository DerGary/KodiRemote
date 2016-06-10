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

namespace KodiRemote.View.Video {
    public class ActorDetailsViewModel : ItemViewModel {
        private ObservableCollection<Group<ItemViewModel>> groups;
        public ObservableCollection<Group<ItemViewModel>> Groups {
            get {
                return groups;
            }
            set {
                groups = value;
                RaisePropertyChanged();
            }
        }


        public ActorDetailsViewModel(ActorTableEntry item) : base(item) {
            Title = item.Name;
            BackgroundItem = null;
        }
        public async Task Init() {
            var Actor = await Kodi.Database.GetActor(Item as ActorTableEntry);
            Groups = new ObservableCollection<Group<ItemViewModel>>();
            var tvshows = new ObservableCollection<ItemViewModel>();
            var movies = new ObservableCollection<ItemViewModel>();
            //var episodes = new ObservableCollection<ItemViewModel>();
            foreach (var item in Actor.TVShows) {
                tvshows.Add(new ItemViewModel(item.TVShow));
            }
            foreach (var item in Actor.Movies) {
                movies.Add(new ItemViewModel(item.Movie));
            }
            //foreach (var item in Actor.Episodes) {
            //    episodes.Add(new ItemViewModel(item.Episode));
            //}
            if (tvshows.Any()) {
                Groups.Add(new Group<ItemViewModel>() { Name = "TVShows", Items =  tvshows});
            }
            if (movies.Any()) {
                Groups.Add(new Group<ItemViewModel>() { Name = "Movies", Items = movies});
            }
            //if (episodes.Any()) {
            //    Groups.Add(new Group<ItemViewModel>() { Name = "Episodes", Items = episodes });
            //}
        }
    }
    public sealed partial class ActorDetailsPage : PageBase {
        private ActorDetailsViewModel viewModel;
        public ActorDetailsViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                viewModel = value;
                RaisePropertyChanged();
            }
        }

        public override ViewModelBase ViewModelBase {
            get {
                return ViewModel;
            }
        }

        public ActorDetailsPage() {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            ViewModel = new ActorDetailsViewModel(e.Parameter as ActorTableEntry);
            await ViewModel.Init();
        }

        private void ItemClick(object sender, ItemClickEventArgs e) {
            var vm = e.ClickedItem as ItemViewModel;
            var movie = vm.Item as MovieTableEntry;
            if (movie != null) {
                Frame.Navigate(typeof(MovieDetailsPage), movie);
            }
        }
    }
}
