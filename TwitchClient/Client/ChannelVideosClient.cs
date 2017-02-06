namespace CoffeeCat.TwitchClient.Client
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using CoffeeCat.TwitchClient.Dto;
    using CoffeeCat.TwitchClient.Endpoints.Channels;
    using System.Collections.Generic;
    public class ChannelVideosClient : BaseClient
    {
        public ChannelVideosClient(string clientId) : base(clientId)
        {
        }

        internal ChannelVideosClient(string clientId, Uri baseAddress, HttpMessageHandler messageHandler) :
            base(clientId, baseAddress, messageHandler)
        {
        }

        public async Task<List<VideoDto>> GetChannelVideos(
            string channelName,
            bool broadcasts = true,
            bool hls = false)
        {
            var videos = new List<VideoDto>();
            var offset = 0;
            int total;

            do
            {
                var channelVideosEndpoint = new ChannelVideosEndpoint(channelName)
                {
                    Offset = offset,
                    Broadcasts = broadcasts,
                    Hls = hls,
                };

                var response = await this.DownloadTwitchData<VideoListDto>(channelVideosEndpoint.GetUri());
                total = response.Total;

                if (response.Videos == null || !response.Videos.Any())
                {
                    break;
                }

                videos.AddRange(response.Videos);
                offset += response.Videos.Count;
            }
            while (offset < total);

            return videos;
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
