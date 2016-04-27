using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml.Controls;
using System;
using Windows.UI.Core;

namespace KodiRemote.View.Base {
    public class UserControlBase : UserControl, INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the Property Changed Event with the given property name.
        /// The Property Name can be ommitted when called in the property that changed and is added automatically
        /// </summary>
        /// <param name="propName">In a Property this is automatically set to the Property Name. Otherwise you have to set it yourself</param>
        protected async void RaisePropertyChanged([CallerMemberName] string propName = null) {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            });
        }
    }
}
