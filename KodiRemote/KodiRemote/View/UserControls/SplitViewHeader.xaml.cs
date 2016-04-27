using KodiRemote.View.Base;
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
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(SplitViewHeader), null);

        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public SplitViewHeader() {
            this.InitializeComponent();
            ContentFrame.Navigated += ContentFrame_Navigated;
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e) {
            var page = ContentFrame.Content as PageBase;
            Title = page.Title;
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

        private void Navigate<T>() {
            if (!(ContentFrame.Content is T)) {
                ContentFrame.Navigate(typeof(T));
                DeleteBackStackWithoutHome();
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
    }
}
