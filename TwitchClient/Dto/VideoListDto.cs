namespace CoffeeCat.TwitchClient.Dto
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject]
    public class VideoListDto
    {
        [JsonProperty(PropertyName = "_links")]
        public Dictionary<string, string> Links { get; set; }

        [JsonProperty(PropertyName = "_total")]
        public int Total { get; set; }

        public List<VideoDto> Videos { get; set; }
    }
}
