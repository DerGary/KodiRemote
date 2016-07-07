﻿using KodiRemote.Code.Database.TVShowTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.Essentials;
using KodiRemote.Code.Common;
using KodiRemote.Code.JSON.KPlayer.Params;

namespace KodiRemote.ViewModel.Video {
    public class TVShowDetailsViewModel : ItemViewModel {
        private TVShowTableEntry tvshow;
        public TVShowTableEntry TVShow {
            get {
                return tvshow;
            }
            set {
                tvshow = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(UnWatchedEpisodes));
            }
        }
        public int UnWatchedEpisodes => TVShow.Episode - TVShow.WatchedEpisodes;

        private TVShowDetailsViewModel(TVShowTableEntry item) : base(item) {
            TVShow = item;
            BackgroundItem = this;
        }

        public static async Task<TVShowDetailsViewModel> Init(TVShowTableEntry item) {
            var tvshow = await Kodi.ActiveInstance.Database.GetTVShow(item);
            return new TVShowDetailsViewModel(tvshow);
        }

        private RelayCommand play;
        public RelayCommand Play {
            get {
                if(play == null) {
                    play = new RelayCommand(async () => {
                        //await this.Kodi.Player.Open(new Movie() { MovieId = Movie.MovieId }, OptionalRepeatEnum.Null);TODO:
                    });
                }
                return play;
            }
        }
    }
}
