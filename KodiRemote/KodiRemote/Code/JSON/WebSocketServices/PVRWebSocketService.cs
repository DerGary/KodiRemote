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
        #region Events
        public event ReceivedEventHandler<ChannelDetails> GetChannelDetailsReceived;
        public event ReceivedEventHandler<List<ChannelGroupDetails>> GetChannelGroupDetailsReceived;
        public event ReceivedEventHandler<List<ChannelGroup>> GetChannelGroupsReceived;
        public event ReceivedEventHandler<List<ChannelDetails>> GetChannelsReceived;
        public event ReceivedEventHandler<PVRProperties> GetPropertiesReceived;
        public event ReceivedEventHandler<bool> RecordReceived;
        public event ReceivedEventHandler<bool> ScanReceived;
        #endregion Events

        public PVRWebSocketService(WebSocketHelper helper) : base(helper) { }

        protected override void WebSocketMessageReceived(int id, string message) {
            if (id == Method.GetChannelDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<ChannelDetails>>(message);
                GetChannelDetailsReceived?.Invoke(item.Result);
            } else if (id == Method.GetChannelGroupDetails.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<List<ChannelGroupDetails>>>(message);
                GetChannelGroupDetailsReceived?.Invoke(item.Result);
            } else if (id == Method.GetChannelGroups.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<List<ChannelGroup>>>(message);
                GetChannelGroupsReceived?.Invoke(item.Result);
            } else if (id == Method.GetChannels.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<List<ChannelDetails>>>(message);
                GetChannelsReceived?.Invoke(item.Result);
            } else if (id == Method.GetProperties.ToInt()) {
                var item = JsonSerializer.FromJson<RPCResponse<PVRProperties>>(message);
                GetPropertiesReceived?.Invoke(item.Result);
            } else if (id == Method.Record.ToInt()) {
                ConvertResultToBool(RecordReceived, message);
            } else if (id == Method.Scan.ToInt()) {
                ConvertResultToBool(ScanReceived, message);
            }
        }

        protected override void WebSocketNotificationReceived(string method, string notification) {
            //no notifications
        }

        public void GetChannelDetails(int channelId, PVRChannelField properties = null) {
            SendRequest(Method.GetChannelDetails, new GetChannelDetails() { ChannelId = channelId, Properties = properties?.ToList() });
        }

        public void GetChannelGroupDetails(int channelGroupId, PVRChannelField properties = null, Limits limits = null) {
            SendRequest(Method.GetChannelGroupDetails, new GetChannelGroupDetails() { ChannelGroupId = channelGroupId, Channels = new Channels { Properties = properties?.ToList(), Limits = limits } });
        }

        public void GetChannelGroups(ChannelTypeEnum channelType, Limits limits = null) {
            SendRequest(Method.GetChannelGroups, new GetChannelGroups() { ChannelType = channelType, Limits = limits });
        }

        public void GetChannels(int channelGroupId, PVRChannelField properties = null, Limits limits = null) {
            SendRequest(Method.GetChannels, new GetChannels() { ChannelGroupId = channelGroupId, Properties = properties?.ToList(), Limits = limits });
        }

        public void GetProperties(PVRField properties, Limits limits = null) {
            SendRequest(Method.GetProperties, new GetProperties() { Limits = limits, Properties = properties?.ToList() });
        }

        public void Record(ToggleEnum record, int? channelId = null) {
            SendRequest(Method.Record, new Record() { RecordValue = record, ChannelId = channelId });
        }

        public void Scan() {
            SendRequest(Method.Scan);
        }

    }
}
