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
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KFiles;
using KodiRemote.Code.JSON.KFiles.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class FilesWebSocketService : WebSocketServiceBase, IFilesService {
        public FilesWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.Download) {
                DeserializeMessageAndTriggerTask<string>(guid, message);
            } else if (methods[guid] == Method.GetDirectory) {
                DeserializeMessageAndTriggerTask<FilesResult>(guid, message);
            } else if (methods[guid] == Method.GetFileDetails) {
                DeserializeMessageAndTriggerTask<FileResult>(guid, message);
            } else if (methods[guid] == Method.GetSources) {
                DeserializeMessageAndTriggerTask<SourcesResult>(guid, message);
            } else if (methods[guid] == Method.PrepareDownload) {
                DeserializeMessageAndTriggerTask<PrepareDownloadResult>(guid, message);
            }
        }


        protected override void WebSocketNotificationReceived(string method, string notification) {
            //Nothing to do
        }


        public Task<string> Download(string path) {
            return SendRequest<string, Download>(Method.Download, new Download { Path = path });
        }

        public Task<FilesResult> GetDirectory(string directory, MediaEnum media, FileField properties = null, Sort sort = null) {
            return SendRequest<FilesResult, GetDirectory>(Method.GetDirectory, new GetDirectory { Directory = directory, Media = media, Properties = properties?.ToList(), Sort = sort });
        }

        public Task<FileResult> GetFileDetails(string file, MediaEnum media, FileField properties = null) {
            return SendRequest<FileResult, GetFileDetails>(Method.GetFileDetails, new GetFileDetails { File = file, Media = media, Properties = properties?.ToList() });
        }

        public Task<SourcesResult> GetSources(MediaNotNullEnum media, Limits limits = null, Sort sort = null) {
            return SendRequest<SourcesResult, GetSources>(Method.GetSources, new GetSources { Media = media, Limits = limits, Sort = sort });
        }

        public Task<PrepareDownloadResult> PrepareDownload(string path) {
            return SendRequest<PrepareDownloadResult, PrepareDownload>(Method.PrepareDownload, new PrepareDownload { Path = path });
        }

    }
}
