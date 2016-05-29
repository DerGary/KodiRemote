using KodiRemote.Code.Common;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.ViewModel {
    public class ItemViewModel : ViewModelBase {
        public string Poster => StringMethods.ParseImageUrlToAppData(item.Poster);
        public string Fanart => StringMethods.ParseImageUrlToAppData(item.Fanart);
        public string PosterThumbnail => StringMethods.ParseThumbnailUrlToAppData(item.Poster);
        public string Thumbnail => StringMethods.ParseImageUrlToAppData(item.Thumbnail);
        public string ExtraImage {
            get {
                if (item.GetType() == typeof(MovieTableEntry)) {
                    return StringMethods.ParseImageUrlToAppData(item.Poster);
                } else if (item.GetType() == typeof(TVShowTableEntry)) {
                    return StringMethods.ParseImageUrlToAppData(item.Banner);
                }
                return null;
            }
        }
        public bool Watched {
            get {
                if (item.GetType() == typeof(MovieTableEntry)) {
                    return item.PlayCount > 0;
                } else if (item.GetType() == typeof(TVShowTableEntry)) {
                    return item.Episode == item.WatchedEpisodes;

                }
                return false;
            }
        }
        public string Label => item.Label;

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


        public ItemViewModel(object item) {
            this.item = item;
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


        private dynamic item;
        public void DownloadImage(string tag, Kodi kodi) {
            if (tag == null) {
                throw new ArgumentException("tag");
            }

            string url = null;

            switch (tag) {
                case "Poster":
                case "PosterThumbnail":
                    url = item.Poster;
                    break;
                case "Thumbnail":
                    url = item.Thumbnail;
                    break;
                case "Fanart":
                    url = item.Fanart;
                    break;
                case "ExtraImage":
                    if (item.GetType() == typeof(MovieTableEntry)) {
                        url = item.Poster;
                    } else if (item.GetType() == typeof(TVShowTableEntry)) {
                        url = item.Banner;
                    }
                    break;
            }
            SetProgressRing(tag, true);
            ImageDownloader.QueueDownloadImage(
                url,
                kodi,
                () => {
                    RaisePropertyChanged(tag);
                    SetProgressRing(tag, false);
                }
            );
        }
    }
}
