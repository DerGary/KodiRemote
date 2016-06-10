using KodiRemote.Code.Essentials;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static SemaphoreSlim semaphore = new SemaphoreSlim(1);
        public static async void QueueDownloadImage(string image, Kodi kodi, Action completedAction) {
            if(image == null) {
                return;
            }
            await semaphore.WaitAsync();
            if (QueuedUrls.ContainsKey(image)) {
                QueuedUrls[image].Item2.Add(completedAction);
            } else {
                QueuedUrls.Add(image, new Tuple<Kodi, List<Action>>(kodi, new List<Action>() { completedAction }));
            }
            semaphore.Release();

            await semaphore.WaitAsync();
            if (!IsRunning) {
                IsRunning = true; 
                Task t = Task.Run(async () => {
                    await DownloadImage(kodi);
                    IsRunning = false;
                });
            }
            semaphore.Release();
        }

        public static async Task DownloadImage(Kodi kodi) {
            await semaphore.WaitAsync();
            KeyValuePair<string,Tuple<Kodi, List<Action>>> kv = QueuedUrls.FirstOrDefault();
            semaphore.Release();
            while (kv.Value != null) {
                string url = kv.Key;
                Kodi k = kv.Value.Item1;
                List<Action> completed = kv.Value.Item2;

                bool result = await DownloadImageAsync(url, kodi);

                await semaphore.WaitAsync();
                QueuedUrls.Remove(url);
                kv = QueuedUrls.FirstOrDefault();
                semaphore.Release();
                if (result) {
                    foreach (var action in completed) {
                        action.Invoke();
                    }
                }
            }
        }

        private static async Task<bool> DownloadImageAsync(string image, Kodi kodi) {
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
                    await CompressAndSaveAsync(imageFileName, inputStream.AsRandomAccessStream(), true);
                }
            }

            return existingImage != null;
        }

        private static async Task<StorageFile> GetImageCompressAndSaveAsync(HttpClientWrapper client, string url, string imageFileName) {
            using (InMemoryRandomAccessStream responseStream = await client.GetAsync(url)) {
                return await CompressAndSaveAsync(imageFileName, responseStream);
            }
        }

        private static async Task<StorageFile> CompressAndSaveAsync(string imageFileName, IRandomAccessStream inputStream, bool toThumbnail = false) {
            using (Stream compressedImage = await CompressImageAsync(inputStream, toThumbnail)) {
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
                encoder.BitmapTransform.ScaledHeight = 260;
                encoder.BitmapTransform.ScaledWidth = (uint)(260 * ratio);
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
