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
        public PVRWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(string guid, string message) {
            if (methods[guid] == Method.Record
                || methods[guid] == Method.Scan) {
                DeserializeMessageAndTriggerTask(guid, message);
            } else if (methods[guid] == Method.GetChannelDetails) {
                DeserializeMessageAndTriggerTask<ChannelDetails>(guid, message);
            } else if (methods[guid] == Method.GetChannelGroupDetails) {
                DeserializeMessageAndTriggerTask<List<ChannelGroupDetails>>(guid, message);
            } else if (methods[guid] == Method.GetChannelGroups) {
                DeserializeMessageAndTriggerTask<List<ChannelGroup>>(guid, message);
            } else if (methods[guid] == Method.GetProperties) {
                DeserializeMessageAndTriggerTask<PVRProperties>(guid, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //no notifications
        }
        public Task<ChannelDetails> GetChannelDetails(int channelId, PVRChannelField properties = null) {
            return SendRequest<ChannelDetails, GetChannelDetails>(Method.GetChannelDetails, new GetChannelDetails() { ChannelId = channelId, Properties = properties?.ToList() });
        }

        public Task<List<ChannelGroupDetails>> GetChannelGroupDetails(int channelGroupId, PVRChannelField properties = null, Limits limits = null) {
            return SendRequest<List<ChannelGroupDetails>, GetChannelGroupDetails>(Method.GetChannelGroupDetails, new GetChannelGroupDetails() { ChannelGroupId = channelGroupId, Channels = new Channels { Properties = properties?.ToList(), Limits = limits } });
        }

        public Task<List<ChannelGroup>> GetChannelGroups(ChannelTypeEnum channelType, Limits limits = null) {
            return SendRequest<List<ChannelGroup>, GetChannelGroups>(Method.GetChannelGroups, new GetChannelGroups() { ChannelType = channelType, Limits = limits });
        }

        public Task<List<ChannelDetails>> GetChannels(int channelGroupId, PVRChannelField properties = null, Limits limits = null) {
            return SendRequest<List<ChannelDetails>, GetChannels>(Method.GetChannels, new GetChannels() { ChannelGroupId = channelGroupId, Properties = properties?.ToList(), Limits = limits });
        }

        public Task<PVRProperties> GetProperties(PVRField properties, Limits limits = null) {
            return SendRequest<PVRProperties, GetProperties>(Method.GetProperties, new GetProperties() { Limits = limits, Properties = properties?.ToList() });
        }

        public Task<bool> Record(ToggleEnum record, int? channelId = default(int?)) {
            return SendRequest<bool, Record>(Method.Record, new Record() { RecordValue = record, ChannelId = channelId });
        }

        public Task<bool> Scan() {
            return SendRequest<bool>(Method.Scan);
        }
    }
}
