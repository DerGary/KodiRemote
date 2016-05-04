using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class BoolVisibilityConverter : IValueConverter {
        public Visibility OnTrue { get; set; } = Visibility.Visible;
        public Visibility OnFalse { get; set; } = Visibility.Collapsed;
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value is bool) {
                if ((bool)value) {
                    return OnTrue;
                }
            }
            return OnFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            if (value is Visibility) {
                if ((Visibility)value == OnTrue) {
                    return true;
                }
            }
            return false;
        }
    }
}
