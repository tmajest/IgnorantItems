﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using TwitchClient.Dto;
using TwitchClient.Endpoints.Channels;

namespace TwitchClient.Client
{
    public class ChannelVideosClient : BaseClient
    {
        public ChannelVideosClient(string clientId) : base(clientId)
        {
        }

        internal ChannelVideosClient(string clientId, Uri baseAddress, HttpMessageHandler messageHandler) :
            base(clientId, baseAddress, messageHandler)
        {
        }

        public Task<VideoListDto> GetChannelVideoList(string channelName, int limit, int offset, bool broadcasts = true, bool hls = false)
        {
            var channelVideosEndpoint = new ChannelVideosEndpoint(channelName)
            {
                Limit = limit,
                Offset = offset,
                Broadcasts = broadcasts,
                Hls = hls,
            };

            return this.DownloadTwitchData<VideoListDto>(channelVideosEndpoint.GetUri());
        }
    }
}