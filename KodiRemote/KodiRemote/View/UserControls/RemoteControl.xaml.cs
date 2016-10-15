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
                viewModel = value;
                RaisePropertyChanged();
            }
        }

        public RemoteControl() {
            this.InitializeComponent();
            timer.Tick += timer_Tick;
        }

        private void KeyboardButtonTapped(object sender, TappedRoutedEventArgs e) {
            ViewModel.ShowInputDialog();
        }

        #region MethodsForSwipeInputsOnCanvas
        bool singleTap;
        double x;
        double y;
        DispatcherTimer timer = new DispatcherTimer();
        private void Canvas_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e) {
            timer.Stop();
        }

        private async void Canvas_Tapped(object sender, TappedRoutedEventArgs e) {
            singleTap = true;
            await Task.Delay(200);
            if (singleTap) {
                ViewModel.GoCommand.Execute(null);
                Debug.WriteLine("Single Tapped");
            }
        }

        private void Canvas_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e) {
            singleTap = false;
            ViewModel.BackCommand.Execute(null);
            Debug.WriteLine("Double Tapped");
        }

        private void Canvas_Holding(object sender, HoldingRoutedEventArgs e) {
            Debug.WriteLine("Holding");
        }

        private void Canvas_RightTapped(object sender, RightTappedRoutedEventArgs e) {
            ViewModel.OptionsCommand.Execute(null);
            Debug.WriteLine("Right Tapped");
        }


        private void Canvas_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e) {
            timer.Interval = TimeSpan.FromSeconds(1);
            x = e.Cumulative.Translation.X;
            y = e.Cumulative.Translation.Y;

            ExecuteCommand();
            timer.Start();
        }

        void ExecuteCommand() {
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

            ExecuteCommand();
        }

        private void Canvas_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e) {
            x = e.Cumulative.Translation.X;
            y = e.Cumulative.Translation.Y;
        }
        #endregion

        #region MethodsForTouchEllipse
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
        #endregion
    }
}
