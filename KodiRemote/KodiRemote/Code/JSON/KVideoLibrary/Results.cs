using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KFiles.Params;
using KodiRemote.Code.JSON.KJSONRPC.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KVideoLibrary.Results {
    [DataContract]
    public class LibraryCollectionResultBase {
        [DataMember(Name = "limits")]
        public LimitsWithTotal Limits { get; set; }
    }
    [DataContract]
    public class TVShowResult : LibraryCollectionResultBase {
        [DataMember(Name = "tvshows")]
        public List<TVShow> TVShows { get; set; }
    }
    [DataContract]
    public class MovieResult : LibraryCollectionResultBase {
        [DataMember(Name = "movies")]
        public List<Movie> Movies { get; set; }
    }
    [DataContract]
    public class MusicVideoResult : LibraryCollectionResultBase {
        [DataMember(Name = "musicvideos")]
        public List<MusicVideo> MusicVideos { get; set; }
    }
    [DataContract]
    public class EpisodeResult : LibraryCollectionResultBase {
        [DataMember(Name = "episodes")]
        public List<Episode> Episodes { get; set; }
    }
    [DataContract]
    public class GenreResult : LibraryCollectionResultBase {
        [DataMember(Name = "genres")]
        public List<Genre> Genres { get; set; }
    }
    [DataContract]
    public class MovieSetResult : LibraryCollectionResultBase {
        [DataMember(Name = "moviesets")]
        public List<MovieSet> MovieSets { get; set; }
    }
    [DataContract]
    public class TVShowSeasonResult : LibraryCollectionResultBase {
        [DataMember(Name = "tvshowseasons")]
        public List<TVShowSeason> TVShowSeasons { get; set; }
    }
    [DataContract]
    public abstract class Video {
        [DataMember(Name = "cast")]
        public Actor[] Cast { get; set; }
        [DataMember(Name = "rating")]
        public float Rating { get; set; }
        [DataMember(Name = "votes")]
        public string Votes { get; set; }
        [DataMember(Name = "writer")]
        public List<string> Writer { get; set; }
        [DataMember(Name = "originaltitle")]
        public string OriginalTitle { get; set; }
        [DataMember(Name = "plot")]
        public string Plot { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }
        [DataMember(Name = "director")]
        public List<string> Director { get; set; }
        [DataMember(Name = "streamdetails")]
        public StreamDetails StreamDetails { get; set; }
        [DataMember(Name = "lastplayed")]
        public string LastPlayed { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "file")]
        public string File { get; set; }
        [DataMember(Name = "resume")]
        public ResumeTime Resume { get; set; }
        [DataMember(Name = "dateadded")]
        public string DateAdded { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
    }
    [DataContract]
    public class StreamDetails {
        [DataMember(Name = "audio")]
        public AudioStream[] Audio { get; set; }
        [DataMember(Name = "subtitle")]
        public SubtitleStream[] Subtitle { get; set; }
        [DataMember(Name = "Video")]
        public VideoStream[] video { get; set; }
    }

    [DataContract]
    public class Episode : Video {
        [DataMember(Name = "art")]
        public EpisodeArt Art { get; set; }
        [DataMember(Name = "productioncode")]
        public string ProductionCode { get; set; }
        [DataMember(Name = "episode")]
        public int EpisodeNumber { get; set; }
        [DataMember(Name = "showtitle")]
        public string ShowTitle { get; set; }
        [DataMember(Name = "episodeid")]
        public int EpisodeId { get; set; }
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
        [DataMember(Name = "season")]
        public int Season { get; set; }
        [DataMember(Name = "firstaired")]
        public string FirstAired { get; set; }
        [DataMember(Name = "uniqueid")]
        public UniqueID UniqueId { get; set; }
    }
    [DataContract]
    public class EpisodeArt {
        [DataMember(Name = "tvshow.banner")]
        public string Banner { get; set; }
        [DataMember(Name = "tvshow.fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "tvshow.poster")]
        public string Poster { get; set; }
        [DataMember(Name = "thumb")]
        public string Thumb { get; set; }
    }
    [DataContract]
    public class Genre {
        [DataMember(Name = "genreid")]
        public int GenreId { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
    }
    [DataContract]
    public class Movie : Video {
        [DataMember(Name = "movieid")]
        public int MovieId { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "trailer")]
        public string Trailer { get; set; }
        [DataMember(Name = "tagline")]
        public string Tagline { get; set; }
        [DataMember(Name = "plotoutline")]
        public string PlotOutline { get; set; }
        [DataMember(Name = "studio")]
        public List<string> Studio { get; set; }
        [DataMember(Name = "mpaa")]
        public string MPAA { get; set; }
        [DataMember(Name = "country")]
        public List<string> Country { get; set; }
        [DataMember(Name = "imdbnumber")]
        public string IMDBNumber { get; set; }
        [DataMember(Name = "top250")]
        public int Top250 { get; set; }
        [DataMember(Name = "sorttitle")]
        public string SortTitle { get; set; }
        [DataMember(Name = "setid")]
        public int SetId { get; set; }
        [DataMember(Name = "set")]
        public string Set { get; set; }
        [DataMember(Name = "art")]
        public MovieArt Art { get; set; }
    }
    [DataContract]
    public class MovieArt {
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "poster")]
        public string Poster { get; set; }
    }

    [DataContract]
    public class MovieSet {
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "setid")]
        public int SetId { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "art")]
        public MovieArt Art { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
    }
    [DataContract]
    public class MovieSetDetails : MovieSet {
        [DataMember(Name = "movies")]
        public Movie[] Movies { get; set; } //hier kommt kein vollwertiges Video sondern nur id und string
        [DataMember(Name = "limits")]
        public LimitsWithTotal Limits { get; set; }
    }
    [DataContract]
    public class MusicVideo {
        [DataMember(Name = "album")]
        public string Album { get; set; }
        [DataMember(Name = "art")]
        public MusicVideoArt Art { get; set; }
        [DataMember(Name = "artist")]
        public List<string> Artist { get; set; }
        [DataMember(Name = "dateadded")]
        public string DateAdded { get; set; }
        [DataMember(Name = "director")]
        public List<string> Director { get; set; }
        [DataMember(Name = "file")]
        public string File { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "lastplayed")]
        public string LastPlayed { get; set; }
        [DataMember(Name = "musicvideoid")]
        public int MusicVideoId { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "plot")]
        public string Plot { get; set; }
        [DataMember(Name = "resume")]
        public ResumeTime Resume { get; set; }
        [DataMember(Name = "runtime")]
        public int Runtime { get; set; }
        [DataMember(Name = "streamdetails")]
        public StreamDetails StreamDetails { get; set; }
        [DataMember(Name = "studio")]
        public List<string> Studio { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "track")]
        public int Track { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }

    }
    [DataContract]
    public class MusicVideoArt {
        [DataMember(Name = "poster")]
        public string Poster { get; set; }
    }
    [DataContract]
    public class TVShowSeason {
        [DataMember(Name = "art")]
        public TvShowSeasonArt Art { get; set; }
        [DataMember(Name = "episode")]
        public int Episode { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "season")]
        public int Season { get; set; }
        [DataMember(Name = "showtitle")]
        public string ShowTitle { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
        [DataMember(Name = "watchedepisodes")]
        public int WatchedEpisodes { get; set; }
    }
    [DataContract]
    public class TvShowSeasonArt {
        [DataMember(Name = "tvshow.banner")]
        public string TVShowBanner { get; set; }
        [DataMember(Name = "tvshow.fanart")]
        public string TVShowFanart { get; set; }
        [DataMember(Name = "tvshow.poster")]
        public string TVShowPoster { get; set; }
        [DataMember(Name = "banner")]
        public string Banner { get; set; }
        [DataMember(Name = "poster")]
        public string Poster { get; set; }
    }
    [DataContract]
    public class TVShow {
        [DataMember(Name = "art")]
        public TvShowArt Art { get; set; }
        [DataMember(Name = "episode")]
        public int Episode { get; set; }
        [DataMember(Name = "episodeguide")]
        public string EpisodeGuide { get; set; }
        [DataMember(Name = "genre")]
        public List<string> Genre { get; set; }
        [DataMember(Name = "imdbnumber")]
        public string IMDBNumber { get; set; }
        [DataMember(Name = "cast")]
        public Actor[] Cast { get; set; }
        [DataMember(Name = "lastplayed")]
        public string LastPlayed { get; set; }
        [DataMember(Name = "file")]
        public string File { get; set; }
        [DataMember(Name = "dateadded")]
        public string DateAdded { get; set; }
        [DataMember(Name = "label")]
        public string Label { get; set; }
        [DataMember(Name = "mpaa")]
        public string MPAA { get; set; }
        [DataMember(Name = "originaltitle")]
        public string OriginalTitle { get; set; }
        [DataMember(Name = "playcount")]
        public int PlayCount { get; set; }
        [DataMember(Name = "plot")]
        public string Plot { get; set; }
        [DataMember(Name = "premiered")]
        public string Premiered { get; set; }
        [DataMember(Name = "rating")]
        public float Rating { get; set; }
        [DataMember(Name = "season")]
        public int Season { get; set; }
        [DataMember(Name = "sorttile")]
        public string SortTile { get; set; }
        [DataMember(Name = "studio")]
        public List<string> Studio { get; set; }
        [DataMember(Name = "thumbnail")]
        public string Thumbnail { get; set; }
        [DataMember(Name = "tvshowid")]
        public int TVShowId { get; set; }
        [DataMember(Name = "votes")]
        public string Votes { get; set; }
        [DataMember(Name = "watchedepisodes")]
        public int WatchedEpisodes { get; set; }
        [DataMember(Name = "year")]
        public int Year { get; set; }
    }
    [DataContract]
    public class TvShowArt {
        [DataMember(Name = "fanart")]
        public string Fanart { get; set; }
        [DataMember(Name = "poster")]
        public string Poster { get; set; }
        [DataMember(Name = "banner")]
        public string Banner { get; set; }
    }
}