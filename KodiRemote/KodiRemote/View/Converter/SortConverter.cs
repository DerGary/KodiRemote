using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.ViewModel.Video;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class SortConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            SortOption sort = (SortOption)value;
            switch (sort) {
                case SortOption.TitleAscending:
                    return "Title ascending";
                case SortOption.TitleDescending:
                    return "Title descending";
                case SortOption.YearAscending:
                    return "Year ascending";
                case SortOption.YearDescending:
                    return "Year descending";
                case SortOption.RatingAscending:
                    return "Rating ascending";
                case SortOption.RatingDescending:
                    return "Rating descending";
                case SortOption.RuntimeAscending:
                    return "Runtime ascending";
                case SortOption.RuntimeDescending:
                    return "Runtime descending";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
