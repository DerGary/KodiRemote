using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using KodiRemote.ViewModel;
using KodiRemote.Code.Essentials;

namespace KodiRemote.View.Base {
    public class PageBase : Page, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(PageBase), null);

        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            if (Frame.CanGoBack) {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            } else {
                this.NavigationCacheMode = NavigationCacheMode.Required;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
            SystemNavigationManager.GetForCurrentView().BackRequested += PageBase_BackRequested;
        }

        private void PageBase_BackRequested(object sender, BackRequestedEventArgs e) {
            if (Frame.CanGoBack) {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            base.OnNavigatingFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= PageBase_BackRequested;
        }

        /// <summary>
        /// Raises the Property Changed Event with the given property name.
        /// The Property Name can be ommitted when called in the property that changed and is added automatically
        /// </summary>
        /// <param name="propName">In a Property this is automatically set to the Property Name. Otherwise you have to set it yourself</param>
        protected async void RaisePropertyChanged([CallerMemberName] string propName = null) {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            });
        }

        protected void ImageDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args) {
            var image = (sender as Image);
            image.Opacity = 0;
            image.Visibility = Visibility.Collapsed;
        }
        protected void ImageOpened(object sender, RoutedEventArgs e) {
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
        protected void ImageFailed(object sender, ExceptionRoutedEventArgs e) {
            //var image = (sender as Image);
            //var viewModel = image.DataContext as ItemViewModel;
            //viewModel.DownloadImage((string)image.Tag, Kodi.ActiveInstance);
        }
    }
}
