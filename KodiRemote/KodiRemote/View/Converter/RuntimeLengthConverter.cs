using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class RuntimeLengthConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if(value == null) {
                return null;
            }
            return TimeSpan.FromSeconds((int)value).ToString("g");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
