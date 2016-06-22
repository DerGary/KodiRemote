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
            var time = TimeSpan.FromSeconds((int)value);
            if(time.TotalSeconds < 60) {
                return $"{time.Seconds} s";
            } else if (time.TotalSeconds < 3600) {
                return $"{time.Minutes} m {time.Seconds} s";
            } else {
                return $"{time.Hours} h {time.Minutes} m {time.Seconds} s";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
