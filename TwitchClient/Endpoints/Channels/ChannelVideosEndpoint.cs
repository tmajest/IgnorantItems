namespace CoffeeCat.TwitchClient.Endpoints.Channels
{
    using System.Collections.Generic;

    public class ChannelVideosEndpoint : ChannelBaseEndpoint
    {
        /// <summary>
        /// Maximum number of objects in array. Default is 10. Maximum is 100.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Object offset for pagination. Default is 0.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Returns only broadcasts when true. Otherwise only highlights are returned. Default is false.
        /// </summary>
        public bool? Broadcasts { get; set; } = true;

        /// <summary>
        /// Returns only HLS VoDs when true. Otherwise only non-HLS VoDs are returned. Default is false.
        /// </summary>
        public bool? Hls { get; set; }

        public ChannelVideosEndpoint(string channelName) : base(channelName)
        {
        }

        public override string ChannelResource => "videos";

        protected override IDictionary<string, string> CreateQueryParameters()
        {
            return new Dictionary<string, string>()
            {
                ["limit"] = this.Limit?.ToString(),
                ["offset"] = this.Offset?.ToString(),
                ["broadcasts"] = this.Broadcasts?.ToString(),
                ["hls"] = this.Hls?.ToString()
            }; 
        }
    }
}
