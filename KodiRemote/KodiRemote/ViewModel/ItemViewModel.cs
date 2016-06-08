using KodiRemote.Code.Common;
using KodiRemote.Code.Database.MovieTables;
using KodiRemote.Code.Database.TVShowTables;
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
        public string Poster => StringMethods.ParseImageUrlToAppData(Item.Poster);
        public string Fanart => StringMethods.ParseImageUrlToAppData(Item.Fanart);
        public string PosterThumbnail => StringMethods.ParseThumbnailUrlToAppData(Item.Poster);
        public string Thumbnail => StringMethods.ParseImageUrlToAppData(Item.Thumbnail);

        public string ExtraImage {
            get {
                if (Item.GetType() == typeof(MovieTableEntry)) {
                    return StringMethods.ParseImageUrlToAppData(Item.Poster);
                } else if (Item.GetType() == typeof(TVShowTableEntry)) {
                    return StringMethods.ParseImageUrlToAppData(Item.Banner);
                }
                return null;
            }
        }
        public bool Watched {
            get {
                if (Item.GetType() == typeof(MovieTableEntry)) {
                    return Item.PlayCount > 0;
                } else if (Item.GetType() == typeof(TVShowTableEntry)) {
                    return Item.Episode == Item.WatchedEpisodes;

                }
                return false;
            }
        }
        public string Label => Item.Label;

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
            this.Item = item;
            BackgroundItem = this;
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

        public dynamic Item { get; private set; }
        public void DownloadImage(string tag) {
            if (tag == null) {
                throw new ArgumentException("tag");
            }

            string url = null;

            switch (tag) {
                case "Poster":
                case "PosterThumbnail":
                    url = Item.Poster;
                    break;
                case "Thumbnail":
                    url = Item.Thumbnail;
                    break;
                case "Fanart":
                    url = Item.Fanart;
                    break;
                case "ExtraImage":
                    if (Item.GetType() == typeof(MovieTableEntry)) {
                        url = Item.Poster;
                    } else if (Item.GetType() == typeof(TVShowTableEntry)) {
                        url = Item.Banner;
                    }
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
