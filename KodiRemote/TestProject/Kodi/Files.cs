using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KFiles.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class Files {
        //[Fact] Method not Found
        //public async Task Download() {
        //    string result = await ActiveKodi.Instance.Files.Download(@"D:\Drive\meine Projekte\xbmcremote\#01 Home.jpg");
        //    Assert.True(!string.IsNullOrEmpty(result));
        //}
        [Theory]
        [InlineData(false, 1)]
        [InlineData(true, 1)]
        [InlineData(true, 2)]
        [InlineData(true, 3)]
        [InlineData(true, 4)]
        [InlineData(true, 5)]
        [InlineData(true, 6)]
        public async Task GetDirectory(bool properties, int media) {
            FilesResult result = await ActiveKodi.Instance.Files.GetDirectory("Q:", MediaEnum.FromInt(media), properties ? FileField.WithAll() : null, new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending });
            if (result?.Files?.Count > 0) {
                Assert.True(!string.IsNullOrEmpty(result.Files.First().File));
            }
        }
        [Theory]
        [InlineData(false, 1)]
        [InlineData(true, 1)]
        [InlineData(true, 2)]
        [InlineData(true, 3)]
        [InlineData(true, 4)]
        [InlineData(true, 5)]
        [InlineData(true, 6)]
        public async Task GetFileDetails(bool properties, int media) {
            FileResult result = await ActiveKodi.Instance.Files.GetFileDetails(@"Q:\The Big Bang Theory\Staffel 9 englisch\The Big Bang Theory S09E03.mkv", MediaEnum.FromInt(media), properties ? FileField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.File.Label));
        }
        [Theory]
        [InlineData(2, 1, true)]
        [InlineData(3, null, false)]
        [InlineData(4, null, false)]
        [InlineData(5, null, false)]
        [InlineData(6, null, false)]
        public async Task GetSources(int media, int? limits, bool sort) {
            SourcesResult result = await ActiveKodi.Instance.Files.GetSources(MediaNotNullEnum.FromInt(media),
                limits != null ? new KodiRemote.Code.JSON.General.Limits(0, (int)limits) : null,
                sort ? new KodiRemote.Code.JSON.General.Sort() { Order = OrderEnum.descending } : null);
            if (result?.Sources?.Count > 0) {
                Assert.True(!string.IsNullOrEmpty(result.Sources.First().File));
                Assert.True(!string.IsNullOrEmpty(result.Sources.First().Label));
                if (limits != null) {
                    Assert.True(result.Sources.Count == limits);
                }
            }
        }
        //[Fact]
        //Method not Found
        //public async Task PrepareDownload() {
        //    PrepareDownloadResult result = await ActiveKodi.Instance.Files.PrepareDownload(@"D:\Drive\meine Projekte\xbmcremote\#01 Home.jpg");
        //    Assert.True(result.Details != null);
        //}
    }
}
