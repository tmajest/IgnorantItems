using Newtonsoft.Json;
using System;

namespace TwitchClient.Dto
{
    [JsonObject]
    public class VideoDto
    {
        [JsonProperty]
        public int Length { get; set; }

        [JsonProperty(PropertyName = "published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty(PropertyName = "recorded_at")]
        public DateTime RecordedAt { get; set; }

        [JsonProperty]
        public string Url { get; set; }
    }
}
