using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KFiles.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IFilesService {
        event ReceivedEventHandler<string> DownloadReceived;
        event ReceivedEventHandler<List<FileDetails>> GetDirectoryReceived;
        event ReceivedEventHandler<FileDetails> GetFileDetailsReceived;
        event ReceivedEventHandler<List<string>> GetSourcesReceived;
        event ReceivedEventHandler<PrepareDownloadResult> PrepareDownloadReceived;
        void Download(string path);
        void GetDirectory(string directory, MediaEnum media, FileField properties = null, Sort sort = null);
        void GetFileDetails(string file, MediaEnum media, FileField properties = null);
        void GetSources(MediaNotNullEnum media, Limits limits = null, Sort sort = null);
        void PrepareDownload(string path);
    }
}
