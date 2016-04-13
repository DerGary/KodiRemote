﻿using System;
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

// Die Elementvorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace KodiRemote.View
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class RemoteControlPage : Page
    {
        public RemoteControlPage()
        {
            this.InitializeComponent();
        }

        private void Rectangle_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            timer.Stop();
        }
        bool singleTap;
        private async void Rectangle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.singleTap = true;
            await Task.Delay(200);
            if (this.singleTap)
            {
                //defaultViewModel.GoCommand.Execute(null);
                Debug.WriteLine("Single Tapped");
            }
        }

        private void Rectangle_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.singleTap = false;
            //defaultViewModel.BackCommand.Execute(null);
            Debug.WriteLine("Double Tapped");
        }

        private void Rectangle_Holding(object sender, HoldingRoutedEventArgs e)
        {
            Debug.WriteLine("Holding");
        }

        private void Rectangle_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            //defaultViewModel.OptionsCommand.Execute(null);
            Debug.WriteLine("Right Tapped");
        }
        double x;
        double y;
        DispatcherTimer timer = new DispatcherTimer();

        private void Rectangle_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            x = e.Cumulative.Translation.X;
            y = e.Cumulative.Translation.Y;

            StartCommand();
            timer.Start();
        }

        void StartCommand()
        {
            if (Math.Abs(x) > Math.Abs(y))
            {
                if (x >= 0)
                {
                    Debug.WriteLine("Right");
                }
                else
                {
                    Debug.WriteLine("Left");
                }
            }
            else
            {
                if (y >= 0)
                {
                    Debug.WriteLine("Down");
                }
                else
                {
                    Debug.WriteLine("Up");
                }
            }
        }

        void timer_Tick(object sender, object e)
        {
            if (timer.Interval.Seconds == 1)
                timer.Interval = TimeSpan.FromMilliseconds(500);

            StartCommand();
        }

        private void Rectangle_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            x = e.Cumulative.Translation.X;
            y = e.Cumulative.Translation.Y;
        }
    }
}
