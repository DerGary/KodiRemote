using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace KodiRemote.Code.Common {
    public static class XAMLTools {
        public static childItem FindVisualChild<childItem>(this DependencyObject obj) where childItem : DependencyObject {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++) {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        public static double GetHorizontalScrollOffset(this ListViewBase obj) {
            var scrollviewer = obj.FindVisualChild<ScrollViewer>();
            return scrollviewer.HorizontalOffset;
        }
        public static void SetHorizontalScrollOffset(this ListViewBase obj, double horizontalOffset) {
            var scrollviewer = obj.FindVisualChild<ScrollViewer>();
            scrollviewer.ChangeView(horizontalOffset, 0, 1);
        }
        public static double GetVerticalScrollOffset(this ListViewBase obj) {
            var scrollviewer = obj.FindVisualChild<ScrollViewer>();
            return scrollviewer.VerticalOffset;
        }
        public static void SetVerticalScrollOffset(this ListViewBase obj, double VerticalOffset) {
            var scrollviewer = obj.FindVisualChild<ScrollViewer>();
            scrollviewer.ChangeView(0, VerticalOffset, 1);
        }
    }
}
