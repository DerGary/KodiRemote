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
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KodiRemote.View.UserControls
{
    public sealed partial class SplitViewHeader : UserControlBase
    {
        public static readonly DependencyProperty PresenterContentProperty = DependencyProperty.Register("PresenterContent", typeof(UIElement), typeof(SplitViewHeader), null);
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(SplitViewHeader), null);
       
        public UIElement PresenterContent
        {
            get { return (UIElement)GetValue(PresenterContentProperty); }
            set { SetValue(PresenterContentProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public SplitViewHeader()
        {
            this.InitializeComponent();
        }



        private void BurgerMenuClicked(object sender, RoutedEventArgs e)
        {
            rootSplitView.IsPaneOpen = !rootSplitView.IsPaneOpen;
        }
    }
}
