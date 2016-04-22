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
        Task<string> Download(string path);
        Task<FilesResult> GetDirectory(string directory, MediaEnum media, FileField properties = null, Sort sort = null);
        Task<FileResult> GetFileDetails(string file, MediaEnum media, FileField properties = null);
        Task<SourcesResult> GetSources(MediaNotNullEnum media, Limits limits = null, Sort sort = null);
        Task<PrepareDownloadResult> PrepareDownload(string path);
    }
}
