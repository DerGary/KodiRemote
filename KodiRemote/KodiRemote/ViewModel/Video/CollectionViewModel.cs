using KodiRemote.Code.Common;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.Utils;
using KodiRemote.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace KodiRemote.ViewModel.Video {
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
            IEnumerable<TableEntryWithLabelBase> result = null;
            ProgressBarActive = true;

            if (type == PageType.Movies) {
                Title = "Movies";
                result = await Kodi.Database.GetMovies();
            } else if (type == PageType.TVShows) {
                Title = "TV Shows";
                result = await Kodi.Database.GetTVShows();
            } else if (type == PageType.MovieSets) {
                Title = "Movie Sets";
                result = await Kodi.Database.GetMovieSets();
            }

            CreateGroups(result);
            ProgressBarActive = false;

        }

        private void CreateGroups(IEnumerable<TableEntryWithLabelBase> items) {
            if(items == null) {
                return;
            }
            var Groups = new ObservableCollection<Group<ItemViewModel>>();

            Group<ItemViewModel> currentGroup = null;
            char currentLetter = '0';
            var list = items.OrderBy(x => x.Label).ToList();
            foreach (var item in list) {
                char firstLetter = (item.Label as string).FirstOrDefault();
                if (currentLetter != firstLetter) {
                    currentLetter = firstLetter;
                    currentGroup = new Group<ItemViewModel>() { Name = currentLetter.ToString(), Items = new ObservableCollection<ItemViewModel>() };
                    Groups.Add(currentGroup);
                }
                currentGroup.Items.Add(new ItemViewModel(item));
            }

            this.Groups = Groups;
        }
    }

}
