using KodiRemote.Code.Common;
using KodiRemote.Code.Database.EpisodeTables;
using KodiRemote.Code.Database.GeneralTables;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Database.Utils;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public class ItemViewModel : ViewModelBase {
        private string poster;
        private string fanart;
        private string thumbnail;
        private string extraImage;
        private string label;
        private bool watched;
        public string Poster => StringMethods.ParseImageUrlToAppData(poster);
        public string Fanart => StringMethods.ParseImageUrlToAppData(fanart);
        public string PosterThumbnail => StringMethods.ParseThumbnailUrlToAppData(poster);
        public string Thumbnail => StringMethods.ParseImageUrlToAppData(thumbnail);
        public string ExtraImage => StringMethods.ParseImageUrlToAppData(extraImage);
        public string Label => label;
        public bool Watched => watched; 

        private bool posterProgressRingActive;
        public bool PosterProgressRingActive {
            get {
                return posterProgressRingActive;
            }
            set {
                posterProgressRingActive = value;
                RaisePropertyChanged();
            }
        }
        private bool fanartProgressRingActive;
        public bool FanartProgressRingActive {
            get {
                return fanartProgressRingActive;
            }
            set {
                fanartProgressRingActive = value;
                RaisePropertyChanged();
            }
        }
        private bool thumbnailProgressRingActive;
        public bool ThumbnailProgressRingActive {
            get {
                return thumbnailProgressRingActive;
            }
            set {
                thumbnailProgressRingActive = value;
                RaisePropertyChanged();
            }
        }
        private bool extraImageProgressRingActive;
        public bool ExtraImageProgressRingActive {
            get {
                return extraImageProgressRingActive;
            }
            set {
                extraImageProgressRingActive = value;
                RaisePropertyChanged();
            }
        }


        public ItemViewModel(TableEntryBase item) {
            var movie = item as MovieTableEntry;
            if(movie != null) {
                poster = movie.Poster;
                extraImage = movie.Poster;
                thumbnail = movie.Poster;
                fanart = movie.Fanart;
                label = movie.Label;
                watched = movie.PlayCount > 0;
            }
            var tvshow = item as TVShowTableEntry;
            if(tvshow != null) {
                poster = tvshow.Poster;
                extraImage = tvshow.Banner;
                thumbnail = tvshow.Poster;
                fanart = tvshow.Fanart;
                label = tvshow.Label;
                watched = tvshow.WatchedEpisodes == tvshow.Episode;
            }
            var tvshowSeason = item as TVShowSeasonTableEntry;
            if (tvshowSeason != null) {
                poster = tvshowSeason.Poster;
                extraImage = tvshowSeason.Banner;
                thumbnail = tvshowSeason.Poster;
                fanart = tvshowSeason.TVShow?.Fanart;
                label = tvshowSeason.Label;
                watched = tvshowSeason.WatchedEpisodes == tvshowSeason.Episode;
            }
            var movieset = item as MovieSetTableEntry;
            if (movieset != null) {
                poster = movieset.Poster;
                fanart = movieset.Fanart;
                thumbnail = movieset.Thumbnail;
                extraImage = movieset.Poster;
                label = movieset.Label;
                watched = movieset.PlayCount > 0;
            }
            var actor = item as ActorTableEntry;
            if(actor != null) {
                poster = actor.Thumbnail;
                thumbnail = actor.Thumbnail;
                extraImage = actor.Thumbnail;
                label = actor.Name;
            }
            var episode = item as EpisodeTableEntry;
            if(episode != null) {
                thumbnail = episode.Thumbnail;
                label = episode.Title;
                watched = episode.PlayCount > 0;
            }
            this.Item = item;
        }

        public void SetProgressRing(string tag, bool active) {
            switch (tag) {
                case "Poster":
                case "PosterThumbnail":
                    PosterProgressRingActive = active;
                    break;
                case "Thumbnail":
                    ThumbnailProgressRingActive = active;
                    break;
                case "Fanart":
                    FanartProgressRingActive = active;
                    break;
                case "ExtraImage":
                    ExtraImageProgressRingActive = active;
                    break;
            }
        }

        private RelayCommand<object> imageFailedCommand;
        public RelayCommand<object> ImageFailedCommand {
            get {
                if (imageFailedCommand == null) {
                    imageFailedCommand = new RelayCommand<object>((object imageTag) => {
                        DownloadImage((string)imageTag);
                    });
                }
                return imageFailedCommand;
            }
        }

        public TableEntryBase Item { get; private set; }
        public void DownloadImage(string tag) {
            if (tag == null) {
                throw new ArgumentException("tag");
            }

            string url = null;

            switch (tag) {
                case "Poster":
                case "PosterThumbnail":
                    url = poster;
                    break;
                case "Thumbnail":
                    url = thumbnail;
                    break;
                case "Fanart":
                    url = fanart;
                    break;
                case "ExtraImage":
                    url = extraImage;
                    break;
            }
            SetProgressRing(tag, true);
            ImageDownloader.QueueDownloadImage(
                url,
                Kodi,
                () => {
                    RaisePropertyChanged(tag);
                    SetProgressRing(tag, false);
                }
            );
        }
    }
}
