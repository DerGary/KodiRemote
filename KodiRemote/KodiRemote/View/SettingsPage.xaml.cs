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

namespace KodiRemote.View {
    public sealed partial class SettingsPage : PageBase {
        public SettingsViewModel ViewModel { get; set; } = new SettingsViewModel();

        public SettingsPage() {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            await ViewModel.Init();
            var infopage = new KodiInfoPage();
            infopage.ViewModel = ViewModel;
            RightContent.Content = infopage;
        }

        private void KodiList_ItemClick(object sender, ItemClickEventArgs e) {
            Frame.Navigate(typeof(KodiInfoPage), ViewModel);
        }

        private void AddKodiTapped(object sender, TappedRoutedEventArgs e) {
            Frame.Navigate(typeof(AddKodiPage));
        }
    }
}
