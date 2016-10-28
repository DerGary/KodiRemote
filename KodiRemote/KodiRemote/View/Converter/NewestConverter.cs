using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.ViewModel.Video;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    class NewestConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            NewestOption newest = (NewestOption)value;
            switch (newest) {
                case NewestOption.All:
                    return "All";
                case NewestOption.Newest10:
                    return "Newest 10";
                case NewestOption.Newest25:
                    return "Newest 25";
                case NewestOption.Newest50:
                    return "Newest 50";
                case NewestOption.Newest100:
                    return "Newest 100";
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
