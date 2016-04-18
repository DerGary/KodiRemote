using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KFiles.Results;
using XBMCRemote.JSONRPCClasses;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KFiles;
using KodiRemote.Code.JSON.KFiles.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class FilesWebSocketService : WebSocketServiceBase, IFilesService {
        #region Events
        public event ReceivedEventHandler<string> DownloadReceived;
        public event ReceivedEventHandler<List<FileDetails>> GetDirectoryReceived;
        public event ReceivedEventHandler<FileDetails> GetFileDetailsReceived;
        public event ReceivedEventHandler<List<string>> GetSourcesReceived;
        public event ReceivedEventHandler<PrepareDownloadResult> PrepareDownloadReceived;
        #endregion Events

        public FilesWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == Method.Download.ToInt()) {
                DownloadReceived?.Invoke(message);
            } else if (id == Method.GetDirectory.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<List<FileDetails>>>(message);
                GetDirectoryReceived?.Invoke(item.Result);
            } else if (id == Method.GetFileDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<FileDetails>>(message);
                GetFileDetailsReceived?.Invoke(item.Result);
            } else if (id == Method.GetSources.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<List<string>>>(message);
                GetSourcesReceived?.Invoke(item.Result);
            } else if (id == Method.PrepareDownload.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<PrepareDownloadResult>>(message);
                PrepareDownloadReceived?.Invoke(item.Result);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //Nothing to do
        }

        public void Download(string path) {
            SendRequest(Method.Download, new Download() { Path = path });
        }

        public void GetDirectory(string directory, MediaEnum media, FileField properties = null, Sort sort = null) {
            SendRequest(Method.GetDirectory, new GetDirectory() { Directory = directory, Media = media, Properties = properties?.ToList(), Sort = sort });
        }

        public void GetFileDetails(string file, MediaEnum media, FileField properties = null) {
            SendRequest(Method.GetFileDetails, new GetFileDetails() { File = file, Media = media, Properties = properties?.ToList() });
        }

        public void GetSources(MediaNotNullEnum media, Limits limits = null, Sort sort = null) {
            SendRequest(Method.GetSources, new GetSources() { Media = media, Limits = limits, Sort = sort });
        }

        public void PrepareDownload(string path) {
            SendRequest(Method.PrepareDownload, new PrepareDownload() { Path = path });
        }


    }
}
