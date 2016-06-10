using KodiRemote.Code.Database.MovieTables;
using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace KodiRemote.View.Video {
    public class MovieSetDetailsViewModel : ItemViewModel {
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


        public MovieSetDetailsViewModel(MovieSetTableEntry item) : base(item) {
            Title = item.Label;
            BackgroundItem = this;
        }
        public async Task Init() {
            var Actor = await Kodi.Database.GetMovieSet(Item as MovieSetTableEntry);
            Groups = new ObservableCollection<Group<ItemViewModel>>();
            var movies = new ObservableCollection<ItemViewModel>();

            foreach (var item in Actor.Movies.Select(x => x.Movie).OrderBy(x => x.Year)) {
                movies.Add(new ItemViewModel(item));
            }
            if (movies.Any()) {
                Groups.Add(new Group<ItemViewModel>() { Name = "Movies", Items = movies });
            }
        }
    }
    public sealed partial class MovieSetDetailsPage : PageBase {
        private MovieSetDetailsViewModel viewModel;
        public MovieSetDetailsViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                viewModel = value;
                RaisePropertyChanged();
            }
        }

        public override ViewModelBase ViewModelBase => ViewModel;

        public MovieSetDetailsPage() {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            ViewModel = new MovieSetDetailsViewModel(e.Parameter as MovieSetTableEntry);
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
