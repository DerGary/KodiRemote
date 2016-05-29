using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.Utils {
    public static class StringMethods {
        public static string ParseImageUrlToKodi(string url) {
            if (!string.IsNullOrEmpty(url)) {
                url = ReplaceImageAndDeleteSlash(url);
            }
            return url;
        }
        public static string ParseImageUrlToLocal(string url) {
            if (!string.IsNullOrEmpty(url)) {
                url = ReplaceEscapedSlash(url);
                url = ReplaceEscapedColon(url);
                url = ReplaceImageAndDeleteSlash(url);
            }
            return url;
        }
        public static string ParseImageUrlToWeb(string url) {
            if (!string.IsNullOrEmpty(url)) {
                url = ReplaceEscapedSlash(url, "/");
                url = ReplaceEscapedColon(url, ":");
                url = ReplaceImageAndDeleteSlash(url);
            }
            return url;
        }
        public static string ParseImageUrlToAppData(string url) {
            if (!string.IsNullOrEmpty(url)) {
                url = ParseImageUrlToLocal(url);
                url = $"ms-appdata:///local/{Globals.ImageFolder}/{url}";
            }
            return url;
        }
        public static string ParseThumbnailUrlToAppData(string url) {
            if (!string.IsNullOrEmpty(url)) {
                url = ParseImageUrlToLocal(url);
                url = $"ms-appdata:///local/{Globals.ThumbnailFolder}/{url}";
            }
            return url;
        }
        private static string ReplaceEscapedSlash(string url, string with = "") { 
            return url.Replace("%2f", with);
        }
        private static string ReplaceEscapedColon(string url, string with = "") {
            return url.Replace("%3a", with);
        }
        private static string ReplaceImageAndDeleteSlash(string url) {
            url = url.Replace("image://", "");
            if (url[url.Length - 1] == '/') {
                url = url.Substring(0, url.Length - 1);
            }
            return url;
        }
    }
}
