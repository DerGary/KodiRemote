using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace KodiRemote.View.Base {
    public class PageBase : Page {
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            if (Frame.CanGoBack) {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            } else {
                this.NavigationCacheMode = NavigationCacheMode.Required;
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
    }
}
