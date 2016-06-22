using KodiRemote.View.Base;
using KodiRemote.View.Settings;
using KodiRemote.View.Video;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KodiRemote.View.UserControls {
    public sealed partial class SplitViewHeader : UserControlBase {
        public Frame ContentFrame {
            get {
                return contentFrame;
            }
        }

        private PageBase page;
        public PageBase Page {
            get {
                return page;
            }
            set {
                page = value;
                RaisePropertyChanged();
            }
        }

        public SplitViewHeader() {
            this.InitializeComponent();
            ContentFrame.Navigated += ContentFrame_Navigated;
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e) {
            var page = ContentFrame.Content as PageBase;
            Page = page;
        }

        private void BurgerMenuClicked(object sender, RoutedEventArgs e) {
            rootSplitView.IsPaneOpen = !rootSplitView.IsPaneOpen;
        }

        private void SettingsTapped(object sender, TappedRoutedEventArgs e) {
            Navigate<SettingsPage>();
        }

        private void RemoteControlTapped(object sender, TappedRoutedEventArgs e) {
            Navigate<RemoteControlPage>();
        }
        private object lastParam;
        private void Navigate<T>(object param = null) {
            if (!(ContentFrame.Content is T) || lastParam != param) {
                ContentFrame.Navigate(typeof(T), param);
                DeleteBackStackWithoutHome();
                lastParam = param;
                App.ScrollViewerHorizontalOffset.Clear();
                App.ViewModels.Clear();
            }
        }

        private void HomeTapped(object sender, TappedRoutedEventArgs e) {
            if (!(ContentFrame.Content is HomePage)) {
                DeleteBackStackWithoutHome();
                ContentFrame.GoBack();
            }
        }
        private void DeleteBackStackWithoutHome() {
            while (ContentFrame.BackStack.Count > 1) {
                ContentFrame.BackStack.RemoveAt(1);
            }
        }

        private void MoviesTapped(object sender, TappedRoutedEventArgs e) {
            Navigate<CollectionPage>(PageType.Movies);
        }
        private void MovieSetsTapped(object sender, TappedRoutedEventArgs e) {
            Navigate<CollectionPage>(PageType.MovieSets);
        }
        private void TVShowsTapped(object sender, TappedRoutedEventArgs e) {
            Navigate<CollectionPage>(PageType.TVShows);
        }
    }
}
