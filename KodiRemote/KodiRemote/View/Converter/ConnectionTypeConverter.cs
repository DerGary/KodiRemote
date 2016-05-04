using KodiRemote.Code.Essentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class ConnectionTypeConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            return "WebSocket";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return ConnectionType.Websocket;
        }
    }
}
