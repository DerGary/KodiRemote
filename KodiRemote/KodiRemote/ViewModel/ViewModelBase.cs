using KodiRemote.Code.Common;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public abstract class ViewModelBase : PropertyChangedBase {
        private Kodi kodi;
        public Kodi Kodi {
            get {
                return Kodi.ActiveInstance;
            }
        }
        public ViewModelBase() {
            Kodi.KodiChanged += ActiveKodiChanged;
        }
        ~ViewModelBase() {
            Kodi.KodiChanged -= ActiveKodiChanged;
        }

        private void ActiveKodiChanged(object sender, EventArgs e) {
            RaisePropertyChanged(nameof(Kodi));
        }
    }
}
