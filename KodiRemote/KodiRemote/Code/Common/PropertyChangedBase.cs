using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System;

//not created during this bachelor thesis
namespace KodiRemote.Code.Common {
    /// <summary>
    /// This Class provides access to the method RaisePropertyChanged which notifys View Elements of changes of properties.
    /// It is essential for ViewModels but can be used in every class that wants to notify elements of changes.
    /// A TaskFactory is initialized when this class is called for the first time.
    /// It has to be ensured that the first call of this class has to be in the main Thread so the TaskFactory can be created sucessfully, otherwise an exception will be trown.
    /// The TaskFactory is used to call the Property Changed event in the main Thread because otherwise this call will fail and throw an exception.
    /// </summary>
    [DataContract()]
    public class PropertyChangedBase : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        public PropertyChangedBase() {
        }

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
