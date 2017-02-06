namespace CoffeeCat.TwitchClient.Dto
{
    using System;
    using Newtonsoft.Json;

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

        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
