using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    class DivisionConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            double result;
            double.TryParse(parameter as string, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
            return (int)((double)value / result);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
