using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace KodiRemote.View.Converter {
    public class ImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if(string.IsNullOrEmpty(value as string)) {
                return new BitmapImage(new Uri("ms-appx:///Assets/actor-placeholder.png"));
            }
            return new BitmapImage(new Uri(value as string));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
