using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class BooleanResourceConverter : IValueConverter {
        public string OnTrue { get; set; }
        public string OnFalse { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value is bool) {
                if ((bool)value) {
                    return OnTrue;
                }
            }
            return OnFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
