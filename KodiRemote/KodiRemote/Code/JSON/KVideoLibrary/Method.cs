using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KVideoLibrary {
    public sealed class Method : StringEnum {
        public static readonly Method Clean = new Method(901, "Clean");
        public static readonly Method Export = new Method(902, "Export");
        public static readonly Method GetEpisodeDetails = new Method(903, "GetEpisodeDetails");
        public static readonly Method GetEpisodes = new Method(904, "GetEpisodes");
        public static readonly Method GetGenres = new Method(905, "GetGenres");
        public static readonly Method GetMovieDetails = new Method(906, "GetMovieDetails");
        public static readonly Method GetMovieSetDetails = new Method(907, "GetMovieSetDetails");
        public static readonly Method GetMovieSets = new Method(908, "GetMovieSets");
        public static readonly Method GetMovies = new Method(909, "GetMovies");
        public static readonly Method GetMusicVideoDetails = new Method(910, "GetMusicVideoDetails");
        public static readonly Method GetMusicVideos = new Method(911, "GetMusicVideos");
        public static readonly Method GetRecentlyAddedEpisodes = new Method(912, "GetRecentlyAddedEpisodes");
        public static readonly Method GetRecentlyAddedMovies = new Method(913, "GetRecentlyAddedMovies");
        public static readonly Method GetRecentlyAddedMusicVideos = new Method(914, "GetRecentlyAddedMusicVideos");
        public static readonly Method GetSeasons = new Method(915, "GetSeasons");
        public static readonly Method GetTVShowDetails = new Method(916, "GetTVShowDetails");
        public static readonly Method GetTVShows = new Method(917, "GetTVShows");
        public static readonly Method RemoveEpisode = new Method(918, "RemoveEpisode");
        public static readonly Method RemoveMovie = new Method(919, "RemoveMovie");
        public static readonly Method RemoveMusicVideo = new Method(920, "RemoveMusicVideo");
        public static readonly Method RemoveTVShow = new Method(921, "RemoveTVShow");
        public static readonly Method Scan = new Method(922, "Scan");
        public static readonly Method SetEpisodeDetails = new Method(923, "SetEpisodeDetails");
        public static readonly Method SetMovieDetails = new Method(924, "SetMovieDetails");
        public static readonly Method SetMusicVideoDetails = new Method(925, "SetMusicVideoDetails");
        public static readonly Method SetTVShowDetails = new Method(926, "SetTVShowDetails");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "VideoLibrary." + name;
        }
    }
}
