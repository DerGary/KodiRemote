using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class TVShowSeasonMapperConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            var episodes = value as IEnumerable<EpisodeTableEntry>;
            if (episodes != null) {
                return episodes.Select(x => new EpisodeViewModel(x));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
