using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class TVShowMapperConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            var tvshowGenreMapper = value as IEnumerable<TVShowGenreMapper>;
            if (tvshowGenreMapper != null) {
                return string.Join(", ", tvshowGenreMapper.Select(x => x.Genre?.Genre));
            }
            var tvshowActorMapper = value as IEnumerable<TVShowActorMapper>;
            if (tvshowActorMapper != null) {
                return tvshowActorMapper.Select(x => new ActorViewModel(x));
            }
            var tvshowSeasons = value as IEnumerable<TVShowSeasonTableEntry>;
            if (tvshowSeasons != null) {
                return tvshowSeasons.Select(x => new ItemViewModel(x));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
