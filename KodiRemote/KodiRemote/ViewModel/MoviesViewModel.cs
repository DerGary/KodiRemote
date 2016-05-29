using KodiRemote.Code.Common;
using KodiRemote.Code.Database.MovieTables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace KodiRemote.ViewModel {
    public class Group<T> :PropertyChangedBase {
        private string name;
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<T> items;
        public ObservableCollection<T> Items {
            get {
                return items;
            }
            set {
                items = value;
                RaisePropertyChanged();
            }
        }
    }

    

    public class MoviesViewModel : ViewModelBase {
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

        public MoviesViewModel() {
            if (DesignMode.DesignModeEnabled) {
                Groups = new ObservableCollection<Group<ItemViewModel>>();
                Groups.Add(new Group<ItemViewModel>() { Name = "A", Items = new ObservableCollection<ItemViewModel>() { new ItemViewModel(new MovieTableEntry() { Label = "test" } )} });
            }
        }

        public async Task Init() {
            var result = await Kodi.Database.GetMovies();
            var Groups = new ObservableCollection<Group<ItemViewModel>>();
            Group<ItemViewModel> currentGroup = null;
            char currentLetter = '0';
            foreach(var movie in result.OrderBy(x => x.Label)) {
                if (currentLetter != movie.Label.FirstOrDefault()) {
                    currentLetter = movie.Label.FirstOrDefault();
                    currentGroup = new Group<ItemViewModel>() { Name = currentLetter.ToString(), Items = new ObservableCollection<ItemViewModel>() };
                    Groups.Add(currentGroup);
                }
                currentGroup.Items.Add(new ItemViewModel(movie));
            }
            this.Groups = Groups;
            Debug.WriteLine(result);
        }
    }
}
