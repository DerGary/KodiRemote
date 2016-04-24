using KodiRemote.Code.JSON.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.General;
using KodiRemote.Code.JSON.KPVR.Results;
using KodiRemote.Code.JSON.KPVR;
using KodiRemote.Code.Utils;
using KodiRemote.Code.JSON.KPVR.Params;

namespace KodiRemote.Code.JSON.WebSocketServices {
    public class PVRWebSocketService : WebSocketServiceBase, IPVRService {
        public PVRWebSocketService(RPCWebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.Record
                || methods[guid] == Method.Scan) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetChannelDetails) {
                DeserializeMessageAndTriggerTask<ChannelResult>(guid, message);
            } else if (methods[guid] == Method.GetChannelGroupDetails) {
                DeserializeMessageAndTriggerTask<ChannelGroupDetailsResult>(guid, message);
            } else if (methods[guid] == Method.GetChannelGroups) {
                DeserializeMessageAndTriggerTask<ChannelGroupResult>(guid, message);
            } else if (methods[guid] == Method.GetProperties) {
                DeserializeMessageAndTriggerTask<PVRProperties>(guid, message);
            } else if (methods[guid] == Method.GetChannels) {
                DeserializeMessageAndTriggerTask<ChannelsResult>(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //no notifications
        }
        public Task<ChannelResult> GetChannelDetails(int channelId, PVRChannelField properties = null) {
            return SendRequest<ChannelResult, GetChannelDetails>(Method.GetChannelDetails, new GetChannelDetails() { ChannelId = channelId, Properties = properties?.ToList() });
        }

        public Task<ChannelGroupDetailsResult> GetChannelGroupDetails(int channelGroupId, PVRChannelField properties = null, Limits limits = null) {
            return SendRequest<ChannelGroupDetailsResult, GetChannelGroupDetails>(Method.GetChannelGroupDetails, new GetChannelGroupDetails() { ChannelGroupId = channelGroupId, Channels = new Channels { Properties = properties?.ToList(), Limits = limits } });
        }

        public Task<ChannelGroupResult> GetChannelGroups(ChannelTypeEnum channelType, Limits limits = null) {
            return SendRequest<ChannelGroupResult, GetChannelGroups>(Method.GetChannelGroups, new GetChannelGroups() { ChannelType = channelType, Limits = limits });
        }

        public Task<ChannelsResult> GetChannels(int channelGroupId, PVRChannelField properties = null, Limits limits = null) {
            return SendRequest<ChannelsResult, GetChannels>(Method.GetChannels, new GetChannels() { ChannelGroupId = channelGroupId, Properties = properties?.ToList(), Limits = limits });
        }

        public Task<PVRProperties> GetProperties(PVRField properties) {
            return SendRequest<PVRProperties, GetProperties>(Method.GetProperties, new GetProperties() { Properties = properties?.ToList() });
        }

        public Task<bool> Record(ToggleEnum record, int? channelId = default(int?)) {
            return SendRequest<bool, Record>(Method.Record, new Record() { RecordValue = record, ChannelId = channelId });
        }

        public Task<bool> Scan() {
            return SendRequest<bool>(Method.Scan);
        }
    }
}
