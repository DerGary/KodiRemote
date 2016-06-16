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
                selectedGenre = value;
                RaisePropertyChanged();
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
                selectedSort = value;
                RaisePropertyChanged();
            }
        }
        private WatchedOption selectedWatched;
        public WatchedOption SelectedWatched {
            get {
                return selectedWatched;
            }
            set {
                selectedWatched = value;
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
                result = await Kodi.Database.GetMovies();
            } else if (type == PageType.TVShows) {
                Title = "TV Shows";
                Sorts = new List<SortOption>() {
                    SortOption.TitleAscending,
                    SortOption.TitleDescending,
                    SortOption.RatingAscending,
                    SortOption.RatingDescending
                };
                result = await Kodi.Database.GetTVShows();
            } else if (type == PageType.MovieSets) {
                Title = "Movie Sets";
                Sorts = new List<SortOption>() {
                    SortOption.TitleAscending,
                    SortOption.TitleDescending
                };
                result = await Kodi.Database.GetMovieSets();
            }
            
            await GetGenres();
            CreateGroups(result);
            ProgressBarActive = false;
        }

        private async Task GetGenres() {
            if(this.Genres == null) {
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
            SelectedGenre = Genres.First();
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

            var movies = items as IEnumerable<MovieTableEntry>;
            if (movies != null && SelectedSort == SortOption.YearAscending || SelectedSort == SortOption.YearDescending) {
                CreateYearOrderedGroups(movies);
            } else {
                CreateLabelOrderedGroups(items);
            }
        }
        //Rating Ordered Groups
        private void CreateYearOrderedGroups(IEnumerable<MovieTableEntry> movies) {
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

        private void CreateLabelOrderedGroups(IEnumerable<TableEntryWithLabelBase> items) {
            var Groups = new ObservableCollection<Group<ItemViewModel>>();
            Group<ItemViewModel> currentGroup = null;
            char currentLetter = '0';
            foreach (var item in items) {
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
