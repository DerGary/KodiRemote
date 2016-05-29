using KodiRemote.Code.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public class Group<T> : PropertyChangedBase {
        private string name;
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
                RaisePropertyChanged();
            }
        }
        private ObservableCollection<T> items;
        public ObservableCollection<T> Items {
            get {
                return items;
            }
            set {
                items = value;
                RaisePropertyChanged();
            }
        }
    }
}
