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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KodiRemote.View.UserControls {
    public sealed partial class CurrentlyPlayingWithHeader : UserControlBase {
        private ItemViewModel viewModel;
        public ItemViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                var oldValue = viewModel;
                viewModel = value;

                RaisePropertyChanged();
                if (viewModel == null) {
                    HideAnimation.Begin();
                } else if (oldValue == null) {
                    ShowAnimation.Begin();
                }
            }
        }

        public CurrentlyPlayingWithHeader() {
            this.InitializeComponent();
        }
    }
}
