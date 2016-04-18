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
        event ReceivedEventHandler<ChannelDetails> GetChannelDetailsReceived;
        event ReceivedEventHandler<List<ChannelGroupDetails>> GetChannelGroupDetailsReceived;
        event ReceivedEventHandler<List<ChannelGroup>> GetChannelGroupsReceived;
        event ReceivedEventHandler<List<ChannelDetails>> GetChannelsReceived;
        event ReceivedEventHandler<PVRProperties> GetPropertiesReceived;
        event ReceivedEventHandler<bool> RecordReceived;
        event ReceivedEventHandler<bool> ScanReceived;

        void GetChannelDetails(int channelId, PVRChannelField properties = null);
        void GetChannelGroupDetails(int channelGroupId, PVRChannelField properties = null, Limits limits = null);
        void GetChannelGroups(ChannelTypeEnum channelType, Limits limits = null);
        void GetChannels(int channelGroupId, PVRChannelField properties = null, Limits limits = null);
        void GetProperties(PVRField properties, Limits limits = null);
        void Record(ToggleEnum record, int? channelId = null);
        void Scan();
    }
}
