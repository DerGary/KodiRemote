using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace KodiRemote.View.Trigger {
    public class OrientationTrigger : StateTriggerBase {
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(OrientationTrigger), new PropertyMetadata(null, OrientationChanged));

        public Orientation Orientation {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly DependencyProperty ActiveOnProperty = DependencyProperty.Register(nameof(ActiveOn), typeof(Orientation), typeof(OrientationTrigger), new PropertyMetadata(null, ActiveOnChanged));

        public Orientation ActiveOn {
            get { return (Orientation)GetValue(ActiveOnProperty); }
            set { SetValue(ActiveOnProperty, value); }
        }

        public OrientationTrigger() {
            CheckActive();
        }

        private void CheckActive() {
            if (Orientation == ActiveOn) {
                SetActive(true);
            } else {
                SetActive(false);
            }
        }

        private static void OrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var trigger = d as OrientationTrigger;
            trigger.CheckActive();
        }
        private static void ActiveOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var trigger = d as OrientationTrigger;
            trigger.CheckActive();
        }
    }
}
