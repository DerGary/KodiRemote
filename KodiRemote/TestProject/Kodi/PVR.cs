﻿using KodiRemote.Code.JSON;
using KodiRemote.Code.JSON.Enums;
using KodiRemote.Code.JSON.Fields;
using KodiRemote.Code.JSON.KPVR.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Kodi {
    [Collection("Kodi")]
    public class PVR {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task GetChannelDetails(bool properties) {
            ChannelResult result = await ActiveKodi.Instance.PVR.GetChannelDetails(1, properties ? PVRChannelField.WithAll() : null);
            Assert.True(!string.IsNullOrEmpty(result.Channel.Label));
        }
        [Theory]
        [InlineData(true, null)]
        [InlineData(false, 5)]
        public async Task GetChannelGroupDetails(bool properties, int? limits) {
            ChannelGroupDetailsResult result = await ActiveKodi.Instance.PVR.GetChannelGroupDetails(1, properties ? PVRChannelField.WithAll() : null, limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits): null);
            Assert.True(result.ChannelGroup.Channels.Count > 0);
        }
        [Theory]
        [InlineData(null)]
        [InlineData(5)]
        public async Task GetChannelGroups(int? limits) {
            ChannelGroupResult result = await ActiveKodi.Instance.PVR.GetChannelGroups(ChannelTypeEnum.TV, limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits): null);
            Assert.True(result.ChannelGroups.Count > 0);
        }
        [Theory]
        [InlineData(true, null)]
        [InlineData(false, 5)]
        public async Task GetChannels(bool properties, int? limits) {
            ChannelsResult result = await ActiveKodi.Instance.PVR.GetChannels(1, properties ? PVRChannelField.WithAll() : null, limits != null ? new KodiRemote.Code.JSON.General.Limits(0,(int)limits): null);
            Assert.True(result.Channels.Count > 0);
        }
        [Fact]
        public async Task GetProperties() {
            PVRProperties result = await ActiveKodi.Instance.PVR.GetProperties(PVRField.WithAll());
            Assert.True(result.Available);
        }
        [Fact]
        public async Task Record() {
            bool result = await ActiveKodi.Instance.PVR.Record(ToggleEnum.True, 1);
            Assert.True(result);
            result = await ActiveKodi.Instance.PVR.Record(ToggleEnum.False, 1);
            Assert.True(result);
        }
        [Fact]
        public async Task RecordToToggle() {
            bool result = await ActiveKodi.Instance.PVR.Record(ToggleEnum.True, 1);
            Assert.True(result);
            result = await ActiveKodi.Instance.PVR.Record(ToggleEnum.Toggle, 1);
            Assert.True(result);
        }
        [Fact]
        public async Task Scan() {
            bool result = await ActiveKodi.Instance.PVR.Scan();
            Assert.True(result);
        }
    }
}
