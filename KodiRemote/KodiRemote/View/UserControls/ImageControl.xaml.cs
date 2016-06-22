using KodiRemote.Code.Common;
using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        //used to not fade out image when image is already shown
        private bool imageShown = false;


        private string imageSource;
        public string ImageSource {
            get {
                return imageSource;
            }
            set {
                //when the image is not changed and the image is not yet shown because it had to be downloaded then 
                //redo this code otherwise it would fadeout and fadein an image that is already shown.
                if(imageSource != value || !imageShown) {
                    imageSource = value;
                    if (string.IsNullOrEmpty(value)) {
                        source = null;
                    } else {
                        source = new BitmapImage(new Uri(value)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
                    }
                    FadeOutImage();
                    RaisePropertyChanged();
                }
            }
        }

        private bool useFadeOutAnimation;
        public bool UseFadeOutAnimation {
            get {
                return useFadeOutAnimation;
            }
            set {
                useFadeOutAnimation = value;
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
            if (UseFadeOutAnimation) {
                if(imageShown == false) {
                    //dont fade out when the image is not yet shown
                    Image.Opacity = 0;
                }
                if (Image.Opacity == 0) {
                    RaisePropertyChanged(nameof(Source));
                } else {
                    FadeOutAnimation.Begin();
                }
            }else {
                RaisePropertyChanged(nameof(Source));
            }
        }

        private void ImageOpened(object sender, RoutedEventArgs e) {
            FadeInAnimation.Begin();
        }

        private void FadeInCompleted(object sender, object e) {
            imageShown = true;
        }

        private void FadeOutCompleted(object sender, object e) {
            imageShown = false;
            RaisePropertyChanged(nameof(Source));
        }

        private void ImageDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args) {
            //when the image is reused by virtualization then the imageShown is false and the UseFadeOutAnimation is false
            //when the image is reused because of caching of the page then UseFadeOutAnimation is false ans imageShown is true, 
            //and because of the caching the other methods like imagefadeout are not triggered but datacontextchanged will and if i wouldn't
            //ask imageshown the image would not be visible
            if (!UseFadeOutAnimation && !imageShown) {
                Image.Opacity = 0;
            }
        }
    }
}
