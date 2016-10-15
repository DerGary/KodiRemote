using KodiRemote.Code.JSON.KVideoLibrary.Filter;
using KodiRemote.ViewModel;
using System;
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
using KodiRemote.Code.JSON.KVideoLibrary.Results;
using KodiRemote.View.Base;

namespace KodiRemote.View {
    public sealed partial class RemoteControlPage : PageBase {
        public RemoteControlViewModel ViewModel { get; set; } = new RemoteControlViewModel();

        public override ViewModelBase ViewModelBase => ViewModel;

        public RemoteControlPage() {
            this.InitializeComponent();
            Loaded += RemoteControlPage_Loaded;
            ViewModel.InputRequested += ViewModel_InputRequested;
        }

        private async void ViewModel_InputRequested(object sender, InputRequestedEventArgs e) {
            await ShowInputDialog();
        }

        private async Task ShowInputDialog() {
            var result = await InputTextDialog.ShowAsync();
            if (result == ContentDialogResult.Primary) {
                await ViewModel.SendText();
            }
        }
        private async void InputTextDialogKeyUp(object sender, KeyRoutedEventArgs e) {
            if (e.Key == Windows.System.VirtualKey.Enter) {
                InputTextDialog.Hide();
                await ViewModel.SendText();
            } else if (e.Key == Windows.System.VirtualKey.Escape) {
                InputTextDialog.Hide();
            }
        }

        private async void RemoteControlPage_Loaded(object sender, RoutedEventArgs e) {
            var movie = await ViewModel.Kodi.Database.GetMovie(new Code.Database.MovieTables.MovieTableEntry() { MovieId = 6 });
            MovieDetails.Movie = movie;
            MovieDetailsCurrentlyPlaying.ViewModel = new ItemViewModel(movie);
            CurrentlyPlaying2.ViewModel = new ItemViewModel(movie);
        }
    }
}
