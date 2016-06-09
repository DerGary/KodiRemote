using KodiRemote.Code.Common;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KodiRemote.View.UserControls {
    public sealed partial class ImageControl : UserControl {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(nameof(ImageSource), typeof(BitmapImage), typeof(ImageControl), null);

        public BitmapImage ImageSource {
            get { return (BitmapImage)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageFailedCommandProperty = DependencyProperty.Register(nameof(ImageFailedCommand), typeof(RelayCommand<object>), typeof(ImageControl), null);

        public RelayCommand<object> ImageFailedCommand {
            get { return (RelayCommand<object>)GetValue(ImageFailedCommandProperty); }
            set { SetValue(ImageFailedCommandProperty, value); }
        }

        public static readonly DependencyProperty PropNameProperty = DependencyProperty.Register(nameof(PropName), typeof(string), typeof(ImageControl), null);

        public string PropName {
            get { return (string)GetValue(PropNameProperty); }
            set { SetValue(PropNameProperty, value); }
        }
        public static readonly DependencyProperty StretchProperty = DependencyProperty.Register(nameof(Stretch), typeof(Stretch), typeof(ImageControl), new PropertyMetadata(Stretch.Uniform));

        public Stretch Stretch {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        public ImageControl() {
            this.InitializeComponent();
        }

        private void ImageDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args) {
            var image = (sender as Image);
            image.Opacity = 0;
            image.Visibility = Visibility.Collapsed;
        }

        private void ImageOpened(object sender, RoutedEventArgs e) {
            var image = sender as Image;
            image.Opacity = 0;
            image.Visibility = Visibility.Visible;
            Storyboard AniFadeIn = new Storyboard();

            DoubleAnimation FadeIn = new DoubleAnimation();
            FadeIn.From = 0.0;
            FadeIn.To = 1.0;
            FadeIn.Duration = new Duration(TimeSpan.FromSeconds(.5));

            AniFadeIn.Children.Add(FadeIn);
            Storyboard.SetTarget(FadeIn, image);
            Storyboard.SetTargetProperty(FadeIn, "Opacity");

            AniFadeIn.Begin();
        }
    }
}
