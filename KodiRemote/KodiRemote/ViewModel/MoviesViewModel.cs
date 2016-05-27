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
        private ObservableCollection<Group<MovieTableEntry>> groups;
        public ObservableCollection<Group<MovieTableEntry>> Groups {
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
                Groups = new ObservableCollection<Group<MovieTableEntry>>();
                Groups.Add(new Group<MovieTableEntry>() { Name = "A", Items = new ObservableCollection<MovieTableEntry>() { new MovieTableEntry() { Label = "test" } } });
            }
        }

        public async Task Init() {
            var result = await Kodi.Database.GetMovies();
            var Groups = new ObservableCollection<Group<MovieTableEntry>>();
            Group<MovieTableEntry> currentGroup = null;
            char currentLetter = '0';
            foreach(var movie in result.OrderBy(x => x.Label)) {
                if (currentLetter != movie.Label.FirstOrDefault()) {
                    currentLetter = movie.Label.FirstOrDefault();
                    currentGroup = new Group<MovieTableEntry>() { Name = currentLetter.ToString(), Items = new ObservableCollection<MovieTableEntry>() };
                    Groups.Add(currentGroup);
                }
                currentGroup.Items.Add(movie);
            }
            this.Groups = Groups;
            Debug.WriteLine(result);

            var result2 = await Kodi.Files.PrepareDownload("image://http%3a%2f%2fthetvdb.com%2fbanners%2factors%2f15879.jpg/");
            Debug.WriteLine(result2);
        }
    }
}
