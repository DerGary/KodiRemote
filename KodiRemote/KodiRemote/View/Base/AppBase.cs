using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace KodiRemote.View.Base {
    public abstract class AppBase : Application {
        protected Frame _rootFrame;


        protected void PrepareRootFrame() {
#if DEBUG
            //if (System.Diagnostics.Debugger.IsAttached) {
            //    this.DebugSettings.EnableFrameRateCounter = true;
            //}
#endif
            _rootFrame = Window.Current.Content as Frame;

            // Create new rootframe if frame doesn't already exist
            if (_rootFrame == null) {
                _rootFrame = new Frame();

                _rootFrame.NavigationFailed += OnNavigationFailed;

                // Place Frame in current Window
                Window.Current.Content = _rootFrame;
            }
            UnhandledException += AppBase_UnhandledException;
        }

        private async void AppBase_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            await new MessageDialog(e.Exception.ToString(), "Unhandled Exception").ShowAsync();
            e.Handled = true;
        }

        protected void ActivateWindow() {
            Window.Current.Activate();
        }

        /// <summary>
        /// Wird aufgerufen, wenn die Navigation auf eine bestimmte Seite fehlschlägt
        /// </summary>
        /// <param name="sender">Der Rahmen, bei dem die Navigation fehlgeschlagen ist</param>
        /// <param name="e">Details über den Navigationsfehler</param>
        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e) {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
    }
}
