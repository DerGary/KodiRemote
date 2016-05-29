using KodiRemote.Code.Essentials;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Streams;

namespace KodiRemote.Code.Utils {
    public static class ImageDownloader {
        private static StorageFolder ThumbFolder;
        private static StorageFolder ImageFolder;
        private static StorageFolder CacheFolder;

        private static Dictionary<string,Tuple<Kodi, List<Action>>> QueuedUrls = new Dictionary<string,Tuple<Kodi, List<Action>>>();
        private static bool IsRunning = false;

        private static async Task CreateFolders() {
            if (ThumbFolder == null) {
                ThumbFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(Globals.ThumbnailFolder, CreationCollisionOption.OpenIfExists);
            }
            if (ImageFolder == null) {
                ImageFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(Globals.ImageFolder, CreationCollisionOption.OpenIfExists);
            }
            if (CacheFolder == null) {
                CacheFolder = ApplicationData.Current.LocalCacheFolder;
            }
        }

        public static void QueueDownloadImage(string image, Kodi kodi, Action completedAction) {
            if(image == null) {
                return;
            }
            if (QueuedUrls.ContainsKey(image)) {
                QueuedUrls[image].Item2.Add(completedAction);
            } else {
                QueuedUrls.Add(image, new Tuple<Kodi, List<Action>>(kodi, new List<Action>() { completedAction }));
            }

            if (!IsRunning) {
                IsRunning = true;
                Task t = new Task(async () => {
                    while(QueuedUrls.Any()) {
                        KeyValuePair<string,Tuple<Kodi, List<Action>>> kv = QueuedUrls.First();

                        string url = kv.Key;
                        Kodi k = kv.Value.Item1;
                        List<Action> completed = kv.Value.Item2;

                        await DownloadImageAsync(url, kodi);

                        QueuedUrls.Remove(url);
                        foreach(var action in completed) {
                            action.Invoke();
                        }
                    }
                });
                t.Start();
            }
        }

        private static async Task DownloadImageAsync(string image, Kodi kodi) {
            await CreateFolders();

            string imageFileName = StringMethods.ParseImageUrlToLocal(image);

            IStorageItem existingImage = await ImageFolder.TryGetItemAsync(imageFileName);
            if (existingImage == null && kodi != null) {
                //load Image from Kodi
                try {
                    using (HttpClientWrapper client = new HttpClientWrapper(kodi.Settings.Username, kodi.Settings.Password)) {
                        string kodiUrl = $"http://{kodi.Settings.Hostname}:{kodi.Settings.Port}/image/{StringMethods.ParseImageUrlToKodi(image)}";
                        existingImage = await GetImageCompressAndSaveAsync(client, kodiUrl, imageFileName);
                    }
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
            if (existingImage == null) {
                //load Image from Web
                try { 
                    using (HttpClientWrapper client = new HttpClientWrapper()) {
                        string webUrl = StringMethods.ParseImageUrlToWeb(image);
                        existingImage = await GetImageCompressAndSaveAsync(client, webUrl, imageFileName);
                    }
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
            IStorageItem existingImageThumbnail = await ThumbFolder.TryGetItemAsync(imageFileName);
            if (existingImageThumbnail == null && existingImage != null) {
                using (Stream inputStream = await (existingImage as StorageFile).OpenStreamForReadAsync()) {
                    await CompressAndSaveAsync(imageFileName, inputStream, true);
                }
            }
        }

        private static async Task<StorageFile> GetImageCompressAndSaveAsync(HttpClientWrapper client, string url, string imageFileName) {
            using (Stream responseStream = await client.GetAsync(url)) {
                return await CompressAndSaveAsync(imageFileName, responseStream);
            }
        }

        private static async Task<StorageFile> CompressAndSaveAsync(string imageFileName, Stream inputStream, bool toThumbnail = false) {
            using (Stream compressedImage = await CompressImageAsync(inputStream.AsRandomAccessStream(), toThumbnail)) {
                StorageFolder folder = toThumbnail ? ThumbFolder : ImageFolder;
                StorageFile file = await folder.CreateFileAsync(imageFileName, CreationCollisionOption.ReplaceExisting);
                using (Stream outputStream = await file.OpenStreamForWriteAsync()) {
                    await compressedImage.CopyToAsync(outputStream);
                    return file;
                }
            }
        }

        private static async Task<Stream> CompressImageAsync(IRandomAccessStream fileStream, bool toThumbnail = false) {
            InMemoryRandomAccessStream memStream = new InMemoryRandomAccessStream();
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);
            BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(memStream, decoder);

            if (toThumbnail) {
                double ratio = (double)(decoder.PixelWidth) / (double)(decoder.PixelHeight);
                encoder.BitmapTransform.ScaledHeight = 220;
                encoder.BitmapTransform.ScaledWidth = (uint)(220 * ratio);
            } else {
                if (decoder.PixelHeight > 1080) {
                    double ratio = (double)(decoder.PixelWidth) / (double)(decoder.PixelHeight);
                    encoder.BitmapTransform.ScaledHeight = 1080;
                    encoder.BitmapTransform.ScaledWidth = (uint)(1080 * ratio);
                } else {
                    encoder.BitmapTransform.ScaledWidth = decoder.PixelWidth - 1;
                    encoder.BitmapTransform.ScaledHeight = decoder.PixelHeight - 1;
                }
            }

            encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Linear;
            await encoder.FlushAsync();
            memStream.Seek(0);
            fileStream.Seek(0);
            fileStream.Size = 0;
            return memStream.AsStream();
        }
    }
}
