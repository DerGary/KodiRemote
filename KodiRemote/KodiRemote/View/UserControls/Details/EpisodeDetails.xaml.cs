using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.View.Base;
using KodiRemote.ViewModel.Video;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace KodiRemote.View.UserControls {
    public sealed partial class EpisodeDetails : UserControlBase {
        private EpisodeTableEntry episode;
        public EpisodeTableEntry Episode {
            get {
                return episode;
            }
            set {
                episode = value;
                RaisePropertyChanged();
            }
        }

        public delegate void ActorClickedEventHandler(ActorTableEntry item);
        public event ActorClickedEventHandler ActorClicked;

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(EpisodeDetails), null);

        public Orientation Orientation {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public EpisodeDetails() {
            this.InitializeComponent();
        }

        private void ActorGridViewClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ActorViewModel;
            ActorClicked?.Invoke(viewModel.Item as ActorTableEntry);
        }
    }
}
