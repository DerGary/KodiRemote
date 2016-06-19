using KodiRemote.Code.Common;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
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
    public enum SortOption{
        TitleAscending,
        TitleDescending,
        YearAscending,
        YearDescending,
        RatingAscending,
        RatingDescending,
        RuntimeAscending,
        RuntimeDescending
    }
    public enum WatchedOption {
        All,
        UnWatched,
        Watched
    }
    public enum NewestOption {
        All,
        Newest10 = 10,
        Newest25 = 25,
        Newest50 = 50,
        Newest100 = 100
    }
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

        private List<GenreTableEntry> genres;
        public List<GenreTableEntry> Genres {
            get {
                return genres;
            }
            set {
                genres = value;
                RaisePropertyChanged();
            }
        }
        private GenreTableEntry selectedGenre;
        public GenreTableEntry SelectedGenre {
            get {
                return selectedGenre;
            }
            set {
                if(selectedGenre == value) {
                    return;
                }
                selectedGenre = value;
                RaisePropertyChanged();
                Reinit();
            }
        }

        private List<SortOption> sorts;
        public List<SortOption> Sorts {
            get {
                return sorts;
            }
            set {
                sorts = value;
                RaisePropertyChanged();
            }
        }
        private SortOption selectedSort = SortOption.TitleAscending;
        public SortOption SelectedSort {
            get {
                return selectedSort;
            }
            set {
                if(selectedSort == value) {
                    return;
                }
                selectedSort = value;
                RaisePropertyChanged();
                Reinit();
            }
        }

        private List<WatchedOption> watches = new List<WatchedOption> { WatchedOption.All, WatchedOption.UnWatched, WatchedOption.Watched };
        public List<WatchedOption> Watches
        {
            get
            {
                return watches;
            }
            set
            {
                watches = value;
                RaisePropertyChanged();
            }
        }
        private WatchedOption selectedWatched = WatchedOption.All;
        public WatchedOption SelectedWatched {
            get {
                return selectedWatched;
            }
            set {
                if(selectedWatched == value) {
                    return;
                }
                selectedWatched = value;
                RaisePropertyChanged();
                Reinit();
            }
        }

        private List<NewestOption> newest = new List<NewestOption> { NewestOption.All, NewestOption.Newest10, NewestOption.Newest25, NewestOption.Newest50, NewestOption.Newest100 };
        public List<NewestOption> Newest {
            get {
                return newest;
            }
            set {
                newest = value;
                RaisePropertyChanged();
            }
        }
        private NewestOption selectedNewest = NewestOption.All;
        public NewestOption SelectedNewest {
            get {
                return selectedNewest;
            }
            set {
                if(selectedNewest == value) {
                    return;
                }
                selectedNewest = value;
                RaisePropertyChanged();
                Reinit();
            }
        }


        public CollectionViewModel() {
            if (DesignMode.DesignModeEnabled) {
                Groups = new ObservableCollection<Group<ItemViewModel>>();
                Groups.Add(new Group<ItemViewModel>() { Name = "A", Items = new ObservableCollection<ItemViewModel>() { new ItemViewModel(new MovieTableEntry() { Label = "test" } )} });
            }
        }
        public PageType PageType { get; private set; }
        private void Reinit() {
            Groups = null;
            ProgressBarActive = true;
            Task.Run(async () => {
                await GetItemsAndSortAndCreateGroups();

                ProgressBarActive = false;
            });
        }

        public async Task Init(PageType type) {
            PageType = type;
            ProgressBarActive = true;

            await GetGenres();

            if (type == PageType.Movies) {
                Title = "Movies";
                Sorts = new List<SortOption>() {
                    SortOption.TitleAscending,
                    SortOption.TitleDescending,
                    SortOption.YearAscending,
                    SortOption.YearDescending,
                    SortOption.RatingAscending,
                    SortOption.RatingDescending,
                    SortOption.RuntimeAscending,
                    SortOption.RuntimeDescending
                };
            } else if (type == PageType.TVShows) {
                Title = "TV Shows";
                Sorts = new List<SortOption>() {
                    SortOption.TitleAscending,
                    SortOption.TitleDescending,
                    SortOption.RatingAscending,
                    SortOption.RatingDescending
                };
            } else if (type == PageType.MovieSets) {
                Title = "Movie Sets";
                Sorts = new List<SortOption>() {
                    SortOption.TitleAscending,
                    SortOption.TitleDescending
                };
            }

            await GetItemsAndSortAndCreateGroups();
            ProgressBarActive = false;
        }

        private async Task GetItemsAndSortAndCreateGroups() {
            IEnumerable<TableEntryWithLabelBase> result = null;

            if(PageType == PageType.Movies) {
                var response = await Kodi.Database.GetMovies();
                result = SortMovies(response);
            } else if(PageType == PageType.TVShows) {
                var response = await Kodi.Database.GetTVShows();
                result = SortTVShows(response);
            } else if(PageType == PageType.MovieSets) {
                var response = await Kodi.Database.GetMovieSets();
                result = SortMovieSets(response);
            }

            CreateGroups(result);
        }

        private async Task GetGenres() {
            if(this.Genres != null) {
                return;
            }

            IEnumerable<GenreTableEntry> genres = null;
            if(PageType == PageType.Movies || PageType == PageType.MovieSets) {
                genres = await Kodi.Database.GetMovieGenres();
            }else if(PageType == PageType.TVShows) {
                genres = await Kodi.Database.GetTVShowGenres();
            }
            
            var Genres = new List<GenreTableEntry>();
            Genres.Add(new GenreTableEntry() { GenreId = -1, Genre = "All" });
            Genres.AddRange(genres);
            this.Genres = Genres;
            selectedGenre = Genres.First();
        }
        public DateTime parseDateTime(string dateString) {
            DateTime dt = new DateTime();
            if(!string.IsNullOrEmpty(dateString))
                dt = DateTime.ParseExact(dateString, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat);
            return dt;
        }

        private IEnumerable<MovieTableEntry> SortMovies(IEnumerable<MovieTableEntry> items) {
            if (SelectedGenre.GenreId != -1) {
                items = items.Where(x => x.Genres.Exists(y => y.GenreId == SelectedGenre.GenreId));
            }
            if (SelectedWatched == WatchedOption.UnWatched) {
                items = items.Where(x => x.PlayCount == 0);
            } else if (SelectedWatched == WatchedOption.Watched) {
                items = items.Where(x => x.PlayCount > 0);
            }

            if(SelectedNewest != NewestOption.All) {
                items = items.OrderByDescending(x => parseDateTime(x.DateAdded)).Take((int)SelectedNewest);
            }

            if (SelectedSort == SortOption.TitleAscending) {
                items = items.OrderBy(x => x.Label);
            } else if (SelectedSort == SortOption.TitleDescending) {
                items = items.OrderByDescending(x => x.Label);
            } else if (SelectedSort == SortOption.YearAscending) {
                items = items.OrderBy(x => x.Year);
            } else if (SelectedSort == SortOption.YearDescending) {
                items = items.OrderByDescending(x => x.Year);
            } else if (SelectedSort == SortOption.RatingAscending) {
                items = items.OrderBy(x => x.Rating);
            } else if (SelectedSort == SortOption.RatingDescending) {
                items = items.OrderByDescending(x => x.Rating);
            } else if (SelectedSort == SortOption.RuntimeAscending) {
                items = items.OrderBy(x => x.Runtime);
            } else if (SelectedSort == SortOption.RuntimeDescending) {
                items = items.OrderByDescending(x => x.Runtime);
            }

            return items;
        }

        private IEnumerable<MovieSetTableEntry> SortMovieSets(IEnumerable<MovieSetTableEntry> items) {
            if (SelectedWatched == WatchedOption.UnWatched) {
                items = items.Where(x => x.PlayCount == 0);
            } else if (SelectedWatched == WatchedOption.Watched) {
                items = items.Where(x => x.PlayCount > 0);
            }

            if (SelectedSort == SortOption.TitleAscending) {
                items = items.OrderBy(x => x.Label);
            } else if (SelectedSort == SortOption.TitleDescending) {
                items = items.OrderByDescending(x => x.Label);
            } 

            return items;
        }

        private IEnumerable<TVShowTableEntry> SortTVShows(IEnumerable<TVShowTableEntry> items) {
            if (SelectedGenre.GenreId != -1) {
                items = items.Where(x => x.Genres.Exists(y => y.GenreId == SelectedGenre.GenreId));
            }

            if(SelectedNewest != NewestOption.All) {
                items = items.OrderByDescending(x => parseDateTime(x.DateAdded)).Take((int)SelectedNewest);
            }

            if (SelectedWatched == WatchedOption.UnWatched) {
                items = items.Where(x => x.WatchedEpisodes != x.Episode);
            } else if (SelectedWatched == WatchedOption.Watched) {
                items = items.Where(x => x.WatchedEpisodes == x.Episode);
            }

            if (SelectedSort == SortOption.TitleAscending) {
                items = items.OrderBy(x => x.Label);
            } else if (SelectedSort == SortOption.TitleDescending) {
                items = items.OrderByDescending(x => x.Label);
            } else if (SelectedSort == SortOption.RatingAscending) {
                items = items.OrderBy(x => x.Rating);
            } else if (SelectedSort == SortOption.RatingDescending) {
                items = items.OrderByDescending(x => x.Rating);
            }

            return items;
        }

        private void CreateGroups(IEnumerable<TableEntryWithLabelBase> items) {
            if(items == null) {
                return;
            }

            if (SelectedSort == SortOption.YearAscending || SelectedSort == SortOption.YearDescending) {
                CreateYearGroups(items as IEnumerable<MovieTableEntry>);
            } else if (SelectedSort == SortOption.RatingAscending || SelectedSort == SortOption.RatingDescending) {
                CreateRatingGroups(items as IEnumerable<MovieTVShowTableEntryBase>);
            } else if (SelectedSort == SortOption.RuntimeAscending || SelectedSort == SortOption.RuntimeDescending) {
                CreateRuntimeGroups(items as IEnumerable<MovieTableEntry>);
            } else {
                CreateLabelGroups(items);
            }
        }

        private void CreateRatingGroups(IEnumerable<MovieTVShowTableEntryBase> items){
            var Groups = new ObservableCollection<Group<ItemViewModel>>();
            Group<ItemViewModel> currentGroup = null;
            int currentRating = 20;
            foreach(var item in items) {
                if(currentRating != (int)item.Rating) {
                    currentRating = (int)item.Rating;
                    currentGroup = new Group<ItemViewModel>() { Name = currentRating.ToString(), Items = new ObservableCollection<ItemViewModel>() };
                    Groups.Add(currentGroup);
                }
                currentGroup.Items.Add(new ItemViewModel(item));
            }

            this.Groups = Groups;
        }
        
        private void CreateYearGroups(IEnumerable<MovieTableEntry> movies) {
            var Groups = new ObservableCollection<Group<ItemViewModel>>();
            Group<ItemViewModel> currentGroup = null;
            int currentYear = 0;
            foreach (var item in movies) {
                if (currentYear != item.Year) {
                    currentYear = item.Year;
                    currentGroup = new Group<ItemViewModel>() { Name = currentYear.ToString(), Items = new ObservableCollection<ItemViewModel>() };
                    Groups.Add(currentGroup);
                }
                currentGroup.Items.Add(new ItemViewModel(item));
            }

            this.Groups = Groups;
        }
        private void CreateRuntimeGroups(IEnumerable<MovieTableEntry> movies) {
            var Groups = new ObservableCollection<Group<ItemViewModel>>();
            Group<ItemViewModel> currentGroup = null;
            int currenRuntime = 0;
            foreach(var item in movies) {
                int runtime = item.Runtime / 600;
                if(currenRuntime != runtime) {
                    currenRuntime = runtime;
                    currentGroup = new Group<ItemViewModel>() { Name = currenRuntime.ToString() + "0 min", Items = new ObservableCollection<ItemViewModel>() };
                    Groups.Add(currentGroup);
                }
                currentGroup.Items.Add(new ItemViewModel(item));
            }

            this.Groups = Groups;
        }

        private void CreateLabelGroups(IEnumerable<TableEntryWithLabelBase> items) {
            var Groups = new ObservableCollection<Group<ItemViewModel>>();
            Group<ItemViewModel> currentGroup = null;
            char currentLetter = '0';
            foreach (var item in items) {
                char firstLetter = item.Label.FirstOrDefault();
                if(firstLetter >= '0' && firstLetter <= '9') {
                    firstLetter = '#';
                }
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
