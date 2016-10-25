using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.View.Base;
using KodiRemote.ViewModel;
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
    public sealed partial class TVShowDetails : UserControlBase {
        private TVShowTableEntry tvShow;
        public TVShowTableEntry TVShow {
            get {
                return tvShow;
            }
            set {
                tvShow = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(UnWatchedEpisodes));
            }
        }
        public int UnWatchedEpisodes => TVShow.Episode - TVShow.WatchedEpisodes;

        public delegate void TVShowSeasonClickedEventHandler(TVShowSeasonTableEntry item);
        public event TVShowSeasonClickedEventHandler TVShowSeasonClicked;

        public delegate void ActorClickedEventHandler(ActorTableEntry item);
        public event ActorClickedEventHandler ActorClicked;

        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(TVShowDetails), new PropertyMetadata(Orientation.Horizontal, OrientationChanged));

        private static void OrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var control = d as TVShowDetails;
            if ((Orientation)e.NewValue == Orientation.Horizontal) {
                control.TVShowSeasonGridView.Style = (Style)App.Current.Resources["HorizontalGridViewStyle"];
                control.ActorGridView.Style = (Style)App.Current.Resources["HorizontalGridViewStyle"];
                control.Info.MaxWidth = 700;
            } else {
                control.TVShowSeasonGridView.Style = (Style)App.Current.Resources["VerticalGridViewStyle"];
                control.ActorGridView.Style = (Style)App.Current.Resources["VerticalGridViewStyle"];
                control.Info.MaxWidth = double.PositiveInfinity;
            }
        }

        public Orientation Orientation {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public TVShowDetails() {
            this.InitializeComponent();
        }

        private void SeasonClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ItemViewModel;
            TVShowSeasonClicked?.Invoke(viewModel.Item as TVShowSeasonTableEntry);
        }

        private void ActorGridViewClicked(object sender, ItemClickEventArgs e) {
            var viewModel = e.ClickedItem as ActorViewModel;
            ActorClicked?.Invoke(viewModel.Item as ActorTableEntry);
        }
    }
}
