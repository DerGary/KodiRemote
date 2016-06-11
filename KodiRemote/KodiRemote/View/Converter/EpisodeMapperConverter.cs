using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.ViewModel.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class EpisodeMapperConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            var episodeActorMapper = value as IEnumerable<EpisodeActorMapper>;
            if (episodeActorMapper != null) {
                return episodeActorMapper.Select(x => new ActorViewModel(x));
            }
            var episodeDirectorMapper = value as IEnumerable<EpisodeDirectorMapper>;
            if (episodeDirectorMapper != null) {
                return string.Join(", ", episodeDirectorMapper.Select(x => x.Director.Name));
            }
            var episodeAudioStreamMapper = value as IEnumerable<EpisodeAudioStreamMapper>;
            if (episodeAudioStreamMapper != null) {
                return episodeAudioStreamMapper.Select(x => x.AudioStream);
            }
            var episodeVideoStreamMapper = value as IEnumerable<EpisodeVideoStreamMapper>;
            if (episodeVideoStreamMapper != null) {
                return episodeVideoStreamMapper.Select(x => x.VideoStream);
            }
            var episodeSubtitleStreamMapper = value as IEnumerable<EpisodeSubtitleStreamMapper>;
            if (episodeSubtitleStreamMapper != null) {
                return episodeSubtitleStreamMapper.Select(x => x.SubtitleStream);
            }
            //var season = value as TVShowSeasonTableEntry;
            //if(season != null) {
            //    return new ItemViewModel()
            //}

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
