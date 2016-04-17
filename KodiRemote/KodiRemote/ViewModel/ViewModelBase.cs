using KodiRemote.Code.Common;
using KodiRemote.Code.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public abstract class ViewModelBase : PropertyChangedBase {
        private ActiveKodi kodi;
        public ActiveKodi Kodi {
            get {
                return ActiveKodi.Instance;
            }
        }
        public ViewModelBase() {
            ActiveKodi.KodiChanged += ActiveKodiChanged;
        }

        private void ActiveKodiChanged(object sender, EventArgs e) {
            RaisePropertyChanged(nameof(Kodi));
        }
    }
}
