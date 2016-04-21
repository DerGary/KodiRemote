using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAudioLibrary {
    public sealed class Method : StringEnum {
        public static readonly Method Clean = new Method(1001, "Clean");
        public static readonly Method Export = new Method(1002, "Export");
        public static readonly Method GetAlbumDetails = new Method(1003, "GetAlbumDetails");
        public static readonly Method GetAlbums = new Method(1004, "GetAlbums");
        public static readonly Method GetArtistDetails = new Method(1005, "GetArtistDetails");
        public static readonly Method GetArtists = new Method(1006, "GetArtists");
        public static readonly Method GetGenres = new Method(1007, "GetGenres");
        public static readonly Method GetRecentlyAddedAlbums = new Method(1008, "GetRecentlyAddedAlbums");
        public static readonly Method GetRecentlyAddedSongs = new Method(1009, "GetRecentlyAddedSongs");
        public static readonly Method GetRecentlyPlayedAlbums = new Method(1010, "GetRecentlyPlayedAlbums");
        public static readonly Method GetRecentlyPlayedSongs = new Method(1011, "GetRecentlyPlayedSongs");
        public static readonly Method GetSongDetails = new Method(1012, "GetSongDetails");
        public static readonly Method GetSongs = new Method(1013, "GetSongs");
        public static readonly Method Scan = new Method(1014, "Scan");
        public static readonly Method SetAlbumDetails = new Method(1015, "SetAlbumDetails");
        public static readonly Method SetArtistDetails = new Method(1016, "SetArtistDetails");
        public static readonly Method SetSongDetails = new Method(1017, "SetSongDetails");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "AudioLibrary." + name;
        }
    }
}
