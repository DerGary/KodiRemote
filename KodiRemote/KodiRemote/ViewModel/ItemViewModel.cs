﻿using KodiRemote.Code.Common;
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
        protected string poster;
        protected string fanart;
        protected string thumbnail;
        protected string extraImage;
        protected string label;
        protected bool watched;
        protected int id;
        public string Poster => StringMethods.ParseImageUrlToAppData(poster);
        public string Fanart => StringMethods.ParseImageUrlToAppData(fanart);
        public string PosterThumbnail => StringMethods.ParseThumbnailUrlToAppData(poster);
        public string Thumbnail => StringMethods.ParseImageUrlToAppData(thumbnail);
        public string ExtraImage => StringMethods.ParseImageUrlToAppData(extraImage);
        public string Label => label;
        public bool Watched => watched;
        public int Id => id;

        protected bool posterProgressRingActive;
        public bool PosterProgressRingActive {
            get {
                return posterProgressRingActive;
            }
            set {
                posterProgressRingActive = value;
                RaisePropertyChanged();
            }
        }
        protected bool fanartProgressRingActive;
        public bool FanartProgressRingActive {
            get {
                return fanartProgressRingActive;
            }
            set {
                fanartProgressRingActive = value;
                RaisePropertyChanged();
            }
        }
        protected bool thumbnailProgressRingActive;
        public bool ThumbnailProgressRingActive {
            get {
                return thumbnailProgressRingActive;
            }
            set {
                thumbnailProgressRingActive = value;
                RaisePropertyChanged();
            }
        }
        protected bool extraImageProgressRingActive;
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
                id = movie.MovieId;
            }
            var tvshow = item as TVShowTableEntry;
            if(tvshow != null) {
                poster = tvshow.Poster;
                extraImage = tvshow.Banner;
                thumbnail = tvshow.Poster;
                fanart = tvshow.Fanart;
                label = tvshow.Label;
                watched = tvshow.WatchedEpisodes == tvshow.Episode;
                id = tvshow.TVShowId;
            }
            var tvshowSeason = item as TVShowSeasonTableEntry;
            if (tvshowSeason != null) {
                poster = tvshowSeason.Poster;
                extraImage = tvshowSeason.Banner;
                thumbnail = tvshowSeason.Poster;
                fanart = tvshowSeason.TVShow?.Fanart;
                label = tvshowSeason.Label;
                watched = tvshowSeason.WatchedEpisodes == tvshowSeason.Episode;
                id = tvshowSeason.TVShowId;
            }
            var movieset = item as MovieSetTableEntry;
            if (movieset != null) {
                poster = movieset.Poster;
                fanart = movieset.Fanart;
                thumbnail = movieset.Thumbnail;
                extraImage = movieset.Poster;
                label = movieset.Label;
                watched = movieset.PlayCount > 0;
                id = movieset.SetId;
            }
            var actor = item as ActorTableEntry;
            if(actor != null) {
                poster = actor.Thumbnail;
                thumbnail = actor.Thumbnail;
                extraImage = actor.Thumbnail;
                label = actor.Name;
                id = actor.ActorId;
            }
            var episode = item as EpisodeTableEntry;
            if(episode != null) {
                poster = episode.TVShowSeason?.Poster;
                thumbnail = episode.Thumbnail;
                fanart = episode.TVShowSeason?.TVShow?.Fanart;
                label = $"{episode.TVShowSeason.TVShow.Label} - Staffel {episode.TVShowSeason.Season} - Folge {episode.Episode} ({episode.Title})";
                watched = episode.PlayCount > 0;
                id = episode.EpisodeId;
            }
            this.Item = item;
            Title = Label;
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

        protected RelayCommand<object> imageFailedCommand;
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

        public TableEntryBase Item { get; protected set; }
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
