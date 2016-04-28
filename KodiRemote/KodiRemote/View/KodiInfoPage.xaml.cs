using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace KodiRemote.View {
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class KodiInfoPage : PageBase {
        private SettingsViewModel viewModel;
        public SettingsViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                viewModel = value;
                RaisePropertyChanged();
            }
        }
        public KodiInfoPage() {
            this.InitializeComponent();
        }

        private void WindowSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e) {
            if (e.Size.Width >= 670) {
                if (Frame.CanGoBack) {
                    Frame.GoBack();
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            ViewModel = e.Parameter as SettingsViewModel;
            RaisePropertyChanged(nameof(ViewModel));
            Window.Current.SizeChanged += WindowSizeChanged;
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            base.OnNavigatingFrom(e);
            Window.Current.SizeChanged -= WindowSizeChanged;
        }
    }
}
