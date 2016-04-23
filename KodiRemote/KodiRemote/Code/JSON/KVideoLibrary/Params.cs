using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.General.Params;
using KodiRemote.Code.JSON.KVideoLibrary.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KVideoLibrary.Params {


    [DataContract]
    public class ExportOption : Options {
        [DataMember(Name = "images", EmitDefaultValue = false)]
        public bool Images { get; set; }
        [DataMember(Name = "overwrite", EmitDefaultValue = false)]
        public bool Overwrite { get; set; }
        [DataMember(Name = "actorthumbs", EmitDefaultValue = false)]
        public bool ActorThumbs { get; set; }
    }

    [DataContract]
    public class GetEpisodeDetails : PropertyBase {
        [DataMember(Name = "episodeid")]
        public int EpisodeId { get; set; }
    }

    [DataContract]
    public class GetEpisodes : LimitSortPropertyBase {
        [DataMember(Name = "tvshowid", EmitDefaultValue = false)]
        public int? TVShowId { get; set; }
        [DataMember(Name = "season", EmitDefaultValue = false)]
        public int? Season { get; set; }
    }

    [DataContract]
    public class GetGenres : LimitSortPropertyBase {
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
    [DataContract]
    public class GetMovieDetails : PropertyBase {
        [DataMember(Name = "movieid")]
        public int MovieId { get; set; }
    }
    [DataContract]
    public class GetMovieSetDetails : PropertyBase {
        [DataMember(Name = "movies")]
        public LimitSortPropertyBase Movies { get; set; }
        [DataMember(Name = "setid")]
        public int SetId { get; set; }
    }

    [DataContract]
    public class GetMovieSets : LimitSortPropertyBase { }

    [DataContract]
    public class GetMovies : FilterLimitSortPropertyBase<MovieFilter> {
    }

    [DataContract]
    public class GetMusicVideoDetails : PropertyBase {
        [DataMember(Name = "musicvideoid")]
        public int MusicVideoId { get; set; }
    }

    [DataContract]
    public class GetMusicVideos : FilterLimitSortPropertyBase<MusicVideoFilter> { }

    [DataContract]
    public class GetRecentlyAddedEpisodes : LimitSortPropertyBase { }

    [DataContract]
    public class GetRecentlyAddedMovies : LimitSortPropertyBase { }

    [DataContract]
    public class GetRecentlyAddedMusicVideos : LimitSortPropertyBase { }

    [DataContract]
    public class GetSeasons : LimitSortPropertyBase {
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
    }

    [DataContract]
    public class GetTVShowDetails : PropertyBase {
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
    }

    [DataContract]
    public class GetTVShows : FilterLimitSortPropertyBase<TVShowFilter> { }

    [DataContract]
    public class RemoveEpisode {
        [DataMember(Name = "episodeid")]
        public int EpisodeId { get; set; }
    }

    [DataContract]
    public class RemoveMovie {
        [DataMember(Name = "movieid")]
        public int MovieId { get; set; }
    }

    [DataContract]
    public class RemoveMusicVideo {
        [DataMember(Name = "musicvideoid")]
        public int MusicVideoId { get; set; }
    }

    [DataContract]
    public class RemoveTVShow {
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
    }

    [DataContract]
    public class Scan {
        [DataMember(Name = "directory", EmitDefaultValue = false)]
        public string Directory { get; set; }
    }

    [DataContract]
    public class Artwork {
        [DataMember(Name = "banner", EmitDefaultValue = false)]
        public string Banner { get; set; }
        [DataMember(Name = "poster", EmitDefaultValue = false)]
        public string Poster { get; set; }
        [DataMember(Name = "fanart", EmitDefaultValue = false)]
        public string Fanart { get; set; }
        [DataMember(Name = "thumb", EmitDefaultValue = false)]
        public string Thumb { get; set; }
    }

    [DataContract]
    public class Video {
        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string Title { get; set; }
        [DataMember(Name = "playcount", EmitDefaultValue = false)]
        public int? PlayCount { get; set; }
        [DataMember(Name = "runtime", EmitDefaultValue = false)]
        public int? Runtime { get; set; }
        [DataMember(Name = "director", EmitDefaultValue = false)]
        public List<string> Director { get; set; }
        [DataMember(Name = "plot", EmitDefaultValue = false)]
        public string Plot { get; set; }
        [DataMember(Name = "lastplayed", EmitDefaultValue = false)]
        public string LastPlayed { get; set; }
        [DataMember(Name = "thumbnail", EmitDefaultValue = false)]
        public string Thumbnail { get; set; }
        [DataMember(Name = "fanart", EmitDefaultValue = false)]
        public string Fanart { get; set; }
        [DataMember(Name = "art", EmitDefaultValue = false)]
        public Artwork Art { get; set; }
    }

    [DataContract]
    public class TVBase : Video {
        [DataMember(Name = "rating", EmitDefaultValue = false)]
        public float Rating { get; set; }
        [DataMember(Name = "votes", EmitDefaultValue = false)]
        public string Votes { get; set; }
        [DataMember(Name = "originaltitle", EmitDefaultValue = false)]
        public string OriginalTitle { get; set; }
    }
    [DataContract]
    public class MovieEpisodeBase : TVBase {
        [DataMember(Name = "writer", EmitDefaultValue = false)]
        public List<string> Writer { get; set; }
    }


    [DataContract]
    public class SetEpisodeDetails : MovieEpisodeBase {
        [DataMember(Name = "episodeid")]
        public int EpisodeId { get; set; }
        [DataMember(Name = "firstaired", EmitDefaultValue = false)]
        public string FirstAired { get; set; }
        [DataMember(Name = "productioncode", EmitDefaultValue = false)]
        public string ProductionCode { get; set; }
        [DataMember(Name = "season", EmitDefaultValue = false)]
        public int? Season { get; set; }
        [DataMember(Name = "episode", EmitDefaultValue = false)]
        public int? EpisodeNumber { get; set; }
    }

    [DataContract]
    public class SetMovieDetails : MovieEpisodeBase {
        [DataMember(Name = "movieid")]
        public int MovieId { get; set; }
        [DataMember(Name = "studio", EmitDefaultValue = false)]
        public List<string> Studio { get; set; }
        [DataMember(Name = "year", EmitDefaultValue = false)]
        public int? Year { get; set; }
        [DataMember(Name = "genre", EmitDefaultValue = false)]
        public List<string> Genre { get; set; }
        [DataMember(Name = "mpaa", EmitDefaultValue = false)]
        public string MPAA { get; set; }
        [DataMember(Name = "imdbnumber", EmitDefaultValue = false)]
        public string IMDBNumber { get; set; }
        [DataMember(Name = "trailer", EmitDefaultValue = false)]
        public string Trailer { get; set; }
        [DataMember(Name = "tagline", EmitDefaultValue = false)]
        public string Tagline { get; set; }
        [DataMember(Name = "plotoutline", EmitDefaultValue = false)]
        public string PlotOutline { get; set; }
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public List<string> Country { get; set; }
        [DataMember(Name = "top250", EmitDefaultValue = false)]
        public int? Top250 { get; set; }
        [DataMember(Name = "sorttitle", EmitDefaultValue = false)]
        public string SortTitle { get; set; }
        [DataMember(Name = "set", EmitDefaultValue = false)]
        public string Set { get; set; }
        [DataMember(Name = "showlink", EmitDefaultValue = false)]
        public List<string> ShowLink { get; set; }
    }

    [DataContract]
    public class SetMusicVideoDetails : Video {
        [DataMember(Name = "musicvideoid")]
        public int MusicVideoId { get; set; }
        [DataMember(Name = "studio", EmitDefaultValue = false)]
        public List<string> Studio { get; set; }
        [DataMember(Name = "year", EmitDefaultValue = false)]
        public int? Year { get; set; }
        [DataMember(Name = "album", EmitDefaultValue = false)]
        public string Album { get; set; }
        [DataMember(Name = "artist", EmitDefaultValue = false)]
        public List<string> Artist { get; set; }
        [DataMember(Name = "genre", EmitDefaultValue = false)]
        public List<string> Genre { get; set; }
        [DataMember(Name = "track", EmitDefaultValue = false)]
        public int? Track { get; set; }
    }

    [DataContract]
    public class SetTVShowDetails : TVBase {
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
        [DataMember(Name = "studio", EmitDefaultValue = false)]
        public List<string> Studio { get; set; }
        [DataMember(Name = "genre", EmitDefaultValue = false)]
        public List<string> Genre { get; set; }
        [DataMember(Name = "mpaa", EmitDefaultValue = false)]
        public string MPAA { get; set; }
        [DataMember(Name = "imdbnumber", EmitDefaultValue = false)]
        public string IMDBNumber { get; set; }
        [DataMember(Name = "premiered", EmitDefaultValue = false)]
        public string Premiered { get; set; }
        [DataMember(Name = "sorttitle", EmitDefaultValue = false)]
        public string SortTitle { get; set; }
        [DataMember(Name = "episodeguide", EmitDefaultValue = false)]
        public string EpisodeGuide { get; set; }
    }
}
