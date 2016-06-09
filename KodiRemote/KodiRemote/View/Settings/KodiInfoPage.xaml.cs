using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Settings;
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

namespace KodiRemote.View.Settings {
    public sealed partial class KodiInfoPage : PageBase {
        private SettingsViewModel viewModel;
        public SettingsViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                viewModel = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(ViewModelBase));
            }
        }

        public override ViewModelBase ViewModelBase { get { return ViewModel; } }

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
            Window.Current.SizeChanged += WindowSizeChanged;
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e) {
            base.OnNavigatingFrom(e);
            Window.Current.SizeChanged -= WindowSizeChanged;
        }
    }
}
