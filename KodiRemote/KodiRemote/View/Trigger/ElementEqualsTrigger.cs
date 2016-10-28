using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace KodiRemote.View.Trigger {
    public class ElementEqualsTrigger : StateTriggerBase {
        public static readonly DependencyProperty ElementProperty = DependencyProperty.Register(nameof(Element), typeof(FrameworkElement), typeof(ElementSizeTrigger), new PropertyMetadata(null, ElementChanged));

        public FrameworkElement Element {
            get { return (FrameworkElement)GetValue(ElementProperty); }
            set { SetValue(ElementProperty, value); }
        }

        public static readonly DependencyProperty IsProperty = DependencyProperty.Register(nameof(Is), typeof(object), typeof(ElementEqualsTrigger), new PropertyMetadata(null, IsChanged));

        public object Is {
            get { return (object)GetValue(IsProperty); }
            set { SetValue(IsProperty, value); }
        }

        public ElementEqualsTrigger() {
            CheckActive();
        }

        private void CheckActive() {
            if (Element == Is) {
                SetActive(true);
            } else {
                SetActive(false);
            }
        }

        private static void ElementChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var trigger = d as ElementEqualsTrigger;
            trigger.CheckActive();
        }
        private static void IsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var trigger = d as ElementEqualsTrigger;
            trigger.CheckActive();
        }
    }
}
