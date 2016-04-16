using KodiRemote.Code.Common;
using KodiRemote.Code.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public abstract class ViewModelBase : PropertyChangedBase {
        private static Kodi kodi;
        public static Kodi Kodi {
            get {
                return kodi;
            }
            set {
                kodi = value;
                KodiChanged?.Invoke(kodi, null);
            }
        }
        public static event KodiChangedEventHandler KodiChanged;
    }
}
