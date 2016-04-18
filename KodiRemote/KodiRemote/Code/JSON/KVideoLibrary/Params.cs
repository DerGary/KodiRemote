using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KVideoLibrary.DAO;
using KodiRemote.Code.JSON.KVideoLibrary.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KVideoLibrary.Params {
    #region Base
    [DataContract]
    public abstract class PropertyBase {
        [DataMember(Name = "properties", EmitDefaultValue = false)]
        public List<string> Properties { get; set; }
    }

    [DataContract]
    public class LimitSortPropertyBase : PropertyBase {
        [DataMember(Name = "limits", EmitDefaultValue = false)]
        public Limits Limits { get; set; }
        [DataMember(Name = "sort", EmitDefaultValue = false)]
        public Sort Sort { get; set; }
    }
    [DataContract]
    public class FilterLimitSortPropertyBase : LimitSortPropertyBase {
        [DataMember(Name = "filter")]
        public FilterBase Filter { get; set; }
    }
    [DataContract]
    public abstract class Options { }

    #endregion Base



    [DataContract]
    public class Export {
        [DataMember(Name = "options")]
        public Options Options { get; set; }
    }

    [DataContract]
    public class PathOption : Options {
        [DataMember(Name = "path")]
        public string Path { get; set; }
    }

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
    public class GetMovies : FilterLimitSortPropertyBase {
    }

    [DataContract]
    public class GetMusicVideoDetails : PropertyBase {
        [DataMember(Name = "musicvideoid")]
        public int MusicVideoId { get; set; }
    }

    [DataContract]
    public class GetMusicVideos : FilterLimitSortPropertyBase { }

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
    public class GetTVShows : FilterLimitSortPropertyBase { }

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
        [DataMember(Name = "banner")]
        public string Banner { get; set; }
        [DataMember(Name = "poster")]
        public string Poster { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "thumb")]
        public string Thumb { get; set; }
    }

    [DataContract]
    public class VideoDetails {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }
        [DataMember(Name = "director")]
        public List<string> Director { get; set; }
        [DataMember(Name = "plot")]
        public string Plot { get; set; }
        [DataMember(Name = "lastplayed")]
        public string LastPlayed { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "art")]
        public Artwork Art { get; set; }
    }

    public class TVBase : VideoDetails {
        [DataMember(Name = "rating")]
        public float Rating { get; set; }
        [DataMember(Name = "votes")]
        public string Votes { get; set; }
        [DataMember(Name = "originaltitle")]
        public string OriginalTitle { get; set; }
    }

    public class MovieEpisodeBase : TVBase {
        [DataMember(Name = "writer")]
        public List<string> Writer { get; set; }
    }
    [DataContract]
    public class EpisodeDetails : MovieEpisodeBase {
        [DataMember(Name = "episodeid")]
        public int EpisodeId { get; set; }
        [DataMember(Name = "firstaired")]
        public string FirstAired { get; set; }
        [DataMember(Name = "productioncode")]
        public string ProductionCode { get; set; }
        [DataMember(Name = "season")]
        public int Season { get; set; }
        [DataMember(Name = "episode")]
        public int Episode { get; set; }
    }


    [DataContract]
    public class MovieDetails : MovieEpisodeBase {
        [DataMember(Name = "movieid")]
        public int MovieId { get; set; }
        [DataMember(Name = "studio")]
        public List<string> Studio { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "mpaa")]
        public string MPAA { get; set; }
        [DataMember(Name = "imdbnumber")]
        public string IMDBNumber { get; set; }
        [DataMember(Name = "trailer")]
        public string Trailer { get; set; }
        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }
        [DataMember(Name = "plotoutline")]
        public string PlotOutline { get; set; }
        [DataMember(Name = "country")]
        public List<string> Country { get; set; }
        [DataMember(Name = "top250")]
        public int Top250 { get; set; }
        [DataMember(Name = "sorttitle")]
        public string SortTitle { get; set; }
        [DataMember(Name = "set")]
        public string Set { get; set; }
        [DataMember(Name = "showlink")]
        public List<string> ShowLink { get; set; }
    }

    [DataContract]
    public class MusicVideoDetails : VideoDetails {
        [DataMember(Name = "studio")]
        public List<string> Studio { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
        [DataMember(Name = "album")]
        public string Album { get; set; }
        [DataMember(Name = "artist")]
        public List<string> Artist { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "track")]
        public int Track { get; set; }
    }

    [DataContract]
    public class TVShowDetails : TVBase {
        [DataMember(Name = "studio")]
        public List<string> Studio { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "mpaa")]
        public string MPAA { get; set; }
        [DataMember(Name = "imdbnumber")]
        public string IMDBNumber { get; set; }
        [DataMember(Name = "premiered")]
        public string Premiered { get; set; }
        [DataMember(Name = "sorttitle")]
        public string SortTitle { get; set; }
        [DataMember(Name = "episodeguide")]
        public string EpisodeGuide { get; set; }
    }

    [DataContract]
    public class SetEpisodeDetails : EpisodeDetails { }

    [DataContract]
    public class SetMovieDetails : MovieDetails { }

    [DataContract]
    public class SetMusicVideoDetails : MusicVideoDetails { }

    [DataContract]
    public class SetTVShowDetails : TVShowDetails { }


}
