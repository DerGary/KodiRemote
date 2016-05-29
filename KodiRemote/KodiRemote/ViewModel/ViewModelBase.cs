using KodiRemote.Code.Common;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KodiRemote.ViewModel {
    public abstract class ViewModelBase : PropertyChangedBase {
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

        public void ImageFailed(object sender, ExceptionRoutedEventArgs e) {
            var image = (sender as Image);
            var viewModel = image.DataContext as ItemViewModel;
            viewModel.DownloadImage((string)image.Tag, Kodi);
        }
    }
}
