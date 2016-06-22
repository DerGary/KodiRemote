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
using Windows.Storage;

namespace KodiRemote.View.Base {
    public abstract class PageBase : Page, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        protected NavigationMode NavigationMode;

        public abstract ViewModelBase ViewModelBase { get; }

        protected ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;


        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            if (Frame.CanGoBack) {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            } else {
                this.NavigationCacheMode = NavigationCacheMode.Required;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
            SystemNavigationManager.GetForCurrentView().BackRequested += PageBase_BackRequested;
            NavigationMode = e.NavigationMode;
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
        protected void PopInAnimation(FrameworkElement ele, ProgressRing ring) {
            Storyboard AniPopIn = new Storyboard();

            AniPopIn.BeginTime = TimeSpan.FromSeconds(.5);
            AniPopIn.Completed += AniPopInCompleted;

            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));

            DoubleAnimation FadeOut = new DoubleAnimation();
            FadeOut.From = 1.0;
            FadeOut.To = 0.0;
            FadeOut.Duration = new Duration(TimeSpan.FromSeconds(.5));

            PopInThemeAnimation PopIn = new PopInThemeAnimation();
            PopIn.FromVerticalOffset = 200;

            AniPopIn.Children.Add(FadeIn);
            AniPopIn.Children.Add(FadeOut);
            AniPopIn.Children.Add(PopIn);

            Storyboard.SetTarget(FadeIn, ele);
            Storyboard.SetTargetProperty(FadeIn, "Opacity");
            Storyboard.SetTarget(FadeOut, ring);
            Storyboard.SetTargetProperty(FadeOut, "Opacity");

            Storyboard.SetTarget(PopIn, ele);

            AniPopIn.Begin();
        }
        protected void PopOutAnimation(FrameworkElement ele, ProgressRing ring) {
            Storyboard AniPopOut = new Storyboard();

            AniPopOut.Completed += AniPopOutCompleted;

            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));

            PopOutThemeAnimation PopOut = new PopOutThemeAnimation();

            AniPopOut.Children.Add(FadeIn);
            AniPopOut.Children.Add(PopOut);

            Storyboard.SetTarget(FadeIn, ele);
            Storyboard.SetTargetProperty(FadeIn, "Opacity");

            Storyboard.SetTarget(PopOut, ele);

            AniPopOut.Begin();
        }
        
        public delegate void AnimationCompletedEventHandler(object sender, object e);
        public event AnimationCompletedEventHandler PopInCompleted;
        public event AnimationCompletedEventHandler PopOutCompleted;
        
        private void AniPopInCompleted(object sender, object e) {
            PopInCompleted?.Invoke(sender, e);
        }
        private void AniPopOutCompleted(object sender, object e) {
            PopOutCompleted?.Invoke(sender, e);
        }
    }
}
