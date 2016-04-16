﻿using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KPlayer {
    public sealed class Method : StringEnum {
        public static readonly Method GetActivePlayers = new Method(1, "GetActivePlayers");
        public static readonly Method GetItem = new Method(2, "GetItem");
        public static readonly Method GetProperties = new Method(3, "GetProperties");
        public static readonly Method GoTo = new Method(4, "GoTo");
        public static readonly Method Move = new Method(5, "Move");
        public static readonly Method OpenPlaylist = new Method(6, "OpenPlaylist");
        public static readonly Method OpenPicture = new Method(7, "OpenPicture");
        public static readonly Method OpenMovie = new Method(8, "OpenMovie");
        public static readonly Method OpenEpisode = new Method(9, "OpenEpisode");
        public static readonly Method OpenMusicVideo = new Method(10, "OpenMusicVideo");
        public static readonly Method OpenArtist = new Method(11, "OpenArtist");
        public static readonly Method OpenAlbum = new Method(12, "OpenAlbum");
        public static readonly Method OpenSong = new Method(13, "OpenSong");
        public static readonly Method OpenGenre = new Method(14, "OpenGenre");
        public static readonly Method OpenPartyMode = new Method(15, "OpenPartyMode");
        public static readonly Method OpenChannel = new Method(16, "OpenChannel");
        public static readonly Method PlayPause = new Method(17, "PlayPause");
        public static readonly Method Rotate = new Method(18, "Rotate");
        public static readonly Method Seek = new Method(19, "Seek");
        public static readonly Method SetAudioStream = new Method(20, "SetAudioStream");
        public static readonly Method SetSpeed = new Method(21, "SetSpeed");
        public static readonly Method SetSubtitle = new Method(22, "SetSubtitle");
        public static readonly Method SetPartymode = new Method(23, "SetPartymode");
        public static readonly Method SetRepeat = new Method(24, "SetRepeat");
        public static readonly Method SetShuffle = new Method(25, "SetShuffle");
        public static readonly Method Stop = new Method(26, "Stop");
        public static readonly Method Zoom = new Method(27, "Zoom");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "Player." + name;
        }
    }
}
