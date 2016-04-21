using KodiRemote.Code.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.KAudioLibrary {
    public class Methods<T> : StringEnum {
        public Methods(int value, string name) : base(value, name) {
        }
    }
    public sealed class Method<T> : Methods<T> {
        public static readonly Method<bool> Clean = new Method<bool>(1001, "Clean");
        public static readonly Method<bool> Export = new Method<bool>(1002, "Export");
        public static readonly Method<bool> GetAlbumDetails = new Method<bool>(1003, "GetAlbumDetails");
        public static readonly Method<bool> GetAlbums = new Method<bool>(1004, "GetAlbums");
        public static readonly Method<bool> GetArtistDetails = new Method<bool>(1005, "GetArtistDetails");
        public static readonly Method<bool> GetArtists = new Method<bool>(1006, "GetArtists");
        public static readonly Method<bool> GetGenres = new Method<bool>(1007, "GetGenres");
        public static readonly Method<bool> GetRecentlyAddedAlbums = new Method<bool>(1008, "GetRecentlyAddedAlbums");
        public static readonly Method<bool> GetRecentlyAddedSongs = new Method<bool>(1009, "GetRecentlyAddedSongs");
        public static readonly Method<bool> GetRecentlyPlayedAlbums = new Method<bool>(1010, "GetRecentlyPlayedAlbums");
        public static readonly Method<bool> GetRecentlyPlayedSongs = new Method<bool>(1011, "GetRecentlyPlayedSongs");
        public static readonly Method<bool> GetSongDetails = new Method<bool>(1012, "GetSongDetails");
        public static readonly Method<bool> GetSongs = new Method<bool>(1013, "GetSongs");
        public static readonly Method<bool> Scan = new Method<bool>(1014, "Scan");
        public static readonly Method<bool> SetAlbumDetails = new Method<bool>(1015, "SetAlbumDetails");
        public static readonly Method<bool> SetArtistDetails = new Method<bool>(1016, "SetArtistDetails");
        public static readonly Method<bool> SetSongDetails = new Method<bool>(1017, "SetSongDetails");

        private Method(int value, string name) : base(value, name) { }

        public override string ToString() {
            return "AudioLibrary." + name;
        }
    }
}
