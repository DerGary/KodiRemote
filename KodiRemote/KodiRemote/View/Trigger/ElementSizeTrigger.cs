using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace KodiRemote.View.Trigger {
    public class ElementSizeTrigger : StateTriggerBase {
        public static readonly DependencyProperty ElementProperty = DependencyProperty.Register(nameof(Element), typeof(FrameworkElement), typeof(ElementSizeTrigger), new PropertyMetadata(null, ElementChanged));

        public FrameworkElement Element {
            get { return (FrameworkElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public static readonly DependencyProperty MinHeightProperty = DependencyProperty.Register(nameof(MinHeight), typeof(double), typeof(ElementSizeTrigger), new PropertyMetadata(double.NegativeInfinity));

        public double MinHeight {
            get { return (double)GetValue(MinHeightProperty); }
            set { SetValue(MinHeightProperty, value); }
        }

        public static readonly DependencyProperty MinWidthProperty = DependencyProperty.Register(nameof(MinWidth), typeof(double), typeof(ElementSizeTrigger), new PropertyMetadata(double.NegativeInfinity));

        public double MinWidth {
            get { return (double)GetValue(MinWidthProperty); }
            set { SetValue(MinWidthProperty, value); }
        }


        public ElementSizeTrigger() {
            Window.Current.SizeChanged += WindowSizeChanged;
        }

        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e) {
            if (!double.IsNegativeInfinity(MinWidth)) {
                if (MinWidth <= Element.ActualWidth) {
                    this.SetActive(true);
                } else {
                    this.SetActive(false);
                }
            }
            if (!double.IsNegativeInfinity(MinHeight)) {
                if (MinHeight <= Element.ActualHeight) {
                    this.SetActive(true);
                } else {
                    this.SetActive(false);
                }
            }
        }

        private static void ElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var trigger = d as ElementSizeTrigger;
            trigger.WindowSizeChanged(null, null);
        }
    }
}
