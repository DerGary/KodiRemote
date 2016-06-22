using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class FilterVisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value is PageType) {
                var val = (PageType)value;
                var param = parameter as string;
                if (val == PageType.MovieSets) {
                    if (param == "genres" || param == "newest") {
                        return Visibility.Collapsed;
                    }
                }
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
