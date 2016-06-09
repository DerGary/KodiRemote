using KodiRemote.Code.Database.MovieTables;
using KodiRemote.ViewModel;
using KodiRemote.ViewModel.Video;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace KodiRemote.View.Converter {
    public class MovieMapperConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            var movieGenreMapper = value as IEnumerable<MovieGenreMapper>;
            if(movieGenreMapper != null) {
                return string.Join(", ", movieGenreMapper.Select(x => x.Genre.Genre));
            }
            var movieMovieSetMapper = value as IEnumerable<MovieMovieSetMapper>;
            if(movieMovieSetMapper != null) {
                return movieMovieSetMapper.Select(x => new ItemViewModel(x.Movie));
            }
            var movieActorMapper = value as IEnumerable<MovieActorMapper>;
            if (movieActorMapper != null) {
                return movieActorMapper.Select(x => new ActorViewModel(x));
            }
            var movieDirectorMapper = value as IEnumerable<MovieDirectorMapper>;
            if (movieDirectorMapper != null) {
                return string.Join(", ", movieDirectorMapper.Select(x => x.Director.Name));
            }
            var movieAudioStreamMapper = value as IEnumerable<MovieAudioStreamMapper>;
            if (movieAudioStreamMapper != null) {
                return movieAudioStreamMapper.Select(x => x.AudioStream);
            }
            var movieVideoStreamMapper = value as IEnumerable<MovieVideoStreamMapper>;
            if (movieVideoStreamMapper != null) {
                return movieVideoStreamMapper.Select(x => x.VideoStream);
            }
            var movieSubtitleStreamMapper = value as IEnumerable<MovieSubtitleStreamMapper>;
            if (movieSubtitleStreamMapper != null) {
                return movieSubtitleStreamMapper.Select(x => x.SubtitleStream);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
    public class MovieMovieSetMapperConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            var movieMovieSetMapper = value as IEnumerable<MovieMovieSetMapper>;
            if (movieMovieSetMapper != null) {
                return movieMovieSetMapper?.FirstOrDefault()?.MovieSet;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
