using KodiRemote.Code.Common;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace KodiRemote.ViewModel {
    public class CollectionViewModel : ViewModelBase {
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

        public CollectionViewModel() {
            if (DesignMode.DesignModeEnabled) {
                Groups = new ObservableCollection<Group<ItemViewModel>>();
                Groups.Add(new Group<ItemViewModel>() { Name = "A", Items = new ObservableCollection<ItemViewModel>() { new ItemViewModel(new MovieTableEntry() { Label = "test" } )} });
            }
        }
        public PageType PageType { get; private set; }

        public async Task Init(PageType type) {
            PageType = type;
            IEnumerable<dynamic> result = null;

            if (type == PageType.Movies) {
                result = await Kodi.Database.GetMovies();
                Title = "Movies";
            } else if(type == PageType.TVShows) {
                result = await Kodi.Database.GetTVShows();
                Title = "TV Shows";
            } else if(type == PageType.MovieSets) {
                result = await Kodi.Database.GetMovieSets();
                Title = "Movie Sets";
            }

            CreateGroups(result);
        }

        private void CreateGroups(IEnumerable<dynamic> items) {
            if(items == null) {
                return;
            }
            var Groups = new ObservableCollection<Group<ItemViewModel>>();

            Group<ItemViewModel> currentGroup = null;
            char currentLetter = '0';
            foreach (var item in items.OrderBy(x => x.Label)) {
                string label = item.Label;
                if (currentLetter != label.FirstOrDefault()) {
                    currentLetter = label.FirstOrDefault();
                    currentGroup = new Group<ItemViewModel>() { Name = currentLetter.ToString(), Items = new ObservableCollection<ItemViewModel>() };
                    Groups.Add(currentGroup);
                }
                currentGroup.Items.Add(new ItemViewModel(item));
            }

            this.Groups = Groups;
        }
    }

}
