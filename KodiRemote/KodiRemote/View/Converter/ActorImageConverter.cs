using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace KodiRemote.View.Converter {
    public class ActorImageConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if(string.IsNullOrEmpty(value as string)) {
                return "ms-appx:///Assets/actor-placeholder.png";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
