using KodiRemote.View.Base;
using KodiRemote.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KodiRemote.Code.JSON.Enums;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KodiRemote.View.UserControls {
    public sealed partial class RemoteControl : UserControlBase {

        private RemoteControlViewModel viewModel;
        public RemoteControlViewModel ViewModel {
            get {
                return viewModel;
            }
            set {
                if (viewModel != null) {
                    viewModel.InputRequested -= ViewModelInputRequested;
                }
                viewModel = value;
                viewModel.InputRequested += ViewModelInputRequested;
                RaisePropertyChanged();
            }
        }

        public RemoteControl() {
            Loaded += RemoteControl_Loaded;
            this.InitializeComponent();
            timer.Tick += timer_Tick;
        }

        private void RemoteControl_Loaded(object sender, RoutedEventArgs e) {
            this.Focus(FocusState.Keyboard);
        }

        private void Rectangle_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e) {
            timer.Stop();
        }
        bool singleTap;
        private async void Rectangle_Tapped(object sender, TappedRoutedEventArgs e) {
            singleTap = true;
            await Task.Delay(200);
            if (singleTap) {
                ViewModel.GoCommand.Execute(null);
                Debug.WriteLine("Single Tapped");
            }
        }

        private void Rectangle_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e) {
            singleTap = false;
            ViewModel.BackCommand.Execute(null);
            Debug.WriteLine("Double Tapped");
        }

        private void Rectangle_Holding(object sender, HoldingRoutedEventArgs e) {
            Debug.WriteLine("Holding");
        }

        private void Rectangle_RightTapped(object sender, RightTappedRoutedEventArgs e) {
            ViewModel.OptionsCommand.Execute(null);
            Debug.WriteLine("Right Tapped");
        }
        double x;
        double y;
        DispatcherTimer timer = new DispatcherTimer();

        private void Rectangle_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e) {
            timer.Interval = TimeSpan.FromSeconds(1);
            x = e.Cumulative.Translation.X;
            y = e.Cumulative.Translation.Y;

            StartCommand();
            timer.Start();
        }

        void StartCommand() {
            if (Math.Abs(x) > Math.Abs(y)) {
                if (x >= 0) {
                    ViewModel.RightCommand.Execute(null);
                    Debug.WriteLine("Right");
                } else {
                    ViewModel.LeftCommand.Execute(null);
                    Debug.WriteLine("Left");
                }
            } else {
                if (y >= 0) {
                    ViewModel.DownCommand.Execute(null);
                    Debug.WriteLine("Down");
                } else {
                    ViewModel.UpCommand.Execute(null);
                    Debug.WriteLine("Up");
                }
            }
        }

        void timer_Tick(object sender, object e) {
            if (timer.Interval.Seconds == 1)
                timer.Interval = TimeSpan.FromMilliseconds(250);

            StartCommand();
        }

        private void Rectangle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e) {
            x = e.Cumulative.Translation.X;
            y = e.Cumulative.Translation.Y;
        }

        private async void ViewModelInputRequested(object sender, InputRequestedEventArgs e) {
            await ShowInputDialog();
        }

        private async Task ShowInputDialog() {
            var result = await InputTextContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary) {
                await ViewModel.SendText();
            }
        }

        private async void KeyboardButtonTapped(object sender, TappedRoutedEventArgs e) {
            await ShowInputDialog();
        }

        private async void InputTextDialogKeyUp(object sender, KeyRoutedEventArgs e) {
            if (e.Key == Windows.System.VirtualKey.Enter) {
                InputTextContentDialog.Hide();
                await ViewModel.SendText();
            } else if (e.Key == Windows.System.VirtualKey.Escape) {
                InputTextContentDialog.Hide();
            }
        }
        private void CanvasPointerMoved(object sender, PointerRoutedEventArgs e) {
            var point = e.GetCurrentPoint(ManipulationCanvas);
            Canvas.SetLeft(TouchEllipse, point.RawPosition.X - 25);
            Canvas.SetTop(TouchEllipse, point.RawPosition.Y - 25);
        }

        private void CanvasPointerExited(object sender, PointerRoutedEventArgs e) {
            TouchEllipse.Visibility = Visibility.Collapsed;
        }


        private void CanvasPointerReleased(object sender, PointerRoutedEventArgs e) {
            TouchEllipse.Visibility = Visibility.Collapsed;

        }

        private void CanvasPointerPressed(object sender, PointerRoutedEventArgs e) {
            var point = e.GetCurrentPoint(ManipulationCanvas);
            Canvas.SetLeft(TouchEllipse, point.RawPosition.X - 25);
            Canvas.SetTop(TouchEllipse, point.RawPosition.Y - 25);
            TouchEllipse.Visibility = Visibility.Visible;
        }
    }
}
