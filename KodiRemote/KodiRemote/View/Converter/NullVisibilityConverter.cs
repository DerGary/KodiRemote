using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class NullVisibilityConverter : IValueConverter {
        public Visibility OnNull { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language) {
            if(value == null) {
                return OnNull;
            }
            if(value is IEnumerable<object> && !(value as IEnumerable<object>).Any()) {
                return OnNull;
            }
            return OnNull == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
