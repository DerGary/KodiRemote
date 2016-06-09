using KodiRemote.Code.Common;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace KodiRemote.ViewModel {
    public abstract class ViewModelBase : PropertyChangedBase {
        public Kodi Kodi {
            get {
                return Kodi.ActiveInstance;
            }
        }
        private ItemViewModel backgroundItem;
        public ItemViewModel BackgroundItem {
            get {
                return backgroundItem;
            }
            set {
                backgroundItem = value;
                RaisePropertyChanged();
            }
        }
        private string title;
        public string Title {
            get {
                return title;
            }
            set {
                title = value;
                RaisePropertyChanged();
            }
        }
        private bool progressBarActive;
        public bool ProgressBarActive {
            get {
                return progressBarActive;
            }
            set {
                progressBarActive = value;
                RaisePropertyChanged();
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
