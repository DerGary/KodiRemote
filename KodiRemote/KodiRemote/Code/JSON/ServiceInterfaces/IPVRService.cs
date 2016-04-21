using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KPVR.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodiRemote.Code.JSON.ServiceInterfaces {
    public interface IPVRService {
        Task<ChannelDetails> GetChannelDetails(int channelId, PVRChannelField properties = null);
        Task<List<ChannelGroupDetails>> GetChannelGroupDetails(int channelGroupId, PVRChannelField properties = null, Limits limits = null);
        Task<List<ChannelGroup>> GetChannelGroups(ChannelTypeEnum channelType, Limits limits = null);
        Task<List<ChannelDetails>> GetChannels(int channelGroupId, PVRChannelField properties = null, Limits limits = null);
        Task<PVRProperties> GetProperties(PVRField properties, Limits limits = null);
        Task<bool> Record(ToggleEnum record, int? channelId = null);
        Task<bool> Scan();
    }
}
