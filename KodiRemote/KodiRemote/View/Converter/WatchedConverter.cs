using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.ViewModel.Video;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class WatchedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            WatchedOption watched = (WatchedOption)value;
            switch (watched) {
                case WatchedOption.All:
                    return "All";
                case WatchedOption.UnWatched:
                    return "Only Unwatched";
                case WatchedOption.Watched:
                    return "Only Watched";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            string watched = value as string;
            if (watched == "All") {
                return WatchedOption.All;
            } else if (watched == "Only Unwatched") {
                return WatchedOption.UnWatched;
            } else if (watched == "Only Watched") {
                return WatchedOption.Watched;
            }
            return null;
        }
    }
}
