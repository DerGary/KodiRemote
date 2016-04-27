using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System;
using Windows.UI.Xaml;

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

    }
}
