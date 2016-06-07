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
            Debug.WriteLine(sender);
        }
        public void ImageOpened(object sender, RoutedEventArgs e) {
            var image = sender as Image;
            image.Opacity = 0;
            image.Visibility = Visibility.Visible;
            Storyboard AniFadeIn = new Storyboard();

            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));

            AniFadeIn.Children.Add(FadeIn);
            Storyboard.SetTarget(FadeIn, image);
            Storyboard.SetTargetProperty(FadeIn, "Opacity");

            AniFadeIn.Begin();
        }
    }
}
