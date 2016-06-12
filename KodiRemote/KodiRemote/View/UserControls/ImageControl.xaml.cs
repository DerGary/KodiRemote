using KodiRemote.Code.Common;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace KodiRemote.View.UserControls {
    public sealed partial class ImageControl : UserControlBase {
        private string imageSource;
        public string ImageSource {
            get {
                return imageSource;
            }
            set {
                imageSource = value;
                if (string.IsNullOrEmpty(value)) {
                    source = null;
                } else {
                    source = new BitmapImage(new Uri(value)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                }
                //source = new BitmapImage(new Uri(value));
                FadeOutImage();
                RaisePropertyChanged();
            }
        }


        private BitmapImage source;
        public BitmapImage Source {
            get {
                return source;
            }
            set {
                source = value;
                RaisePropertyChanged();
            }
        }

        private bool watched;
        public bool Watched {
            get {
                return watched;
            }
            set {
                watched = value;
                RaisePropertyChanged();
            }
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

        private void FadeOutImage() {
            if(Image.Opacity == 0) {
                RaisePropertyChanged(nameof(Source));
            } else {
                FadeOutAnimation.Begin();
            }
        }

        private void AniFadeOut_Completed(object sender, object e) {
            RaisePropertyChanged(nameof(Source));
        }

        private void ImageOpened(object sender, RoutedEventArgs e) {
            FadeInAnimation.Begin();
        }

        private void FadeInCompleted(object sender, object e) {

        }

        private void FadeOutCompleted(object sender, object e) {
            RaisePropertyChanged(nameof(Source));
        }
    }
}
