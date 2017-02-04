using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.TwitchClient.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.MatchUploader.Converters
{
    internal class StreamConverter
    {
        public static StreamEntity GetStreamEntity(
            VideoDto video, 
            MatchDetailDto match,
            StreamerEntity streamer)
        {
            return new StreamEntity
            {
                Url = video.Url,
                Offset = GetVideoOffset(video, match),
                Streamer = streamer,
            };
        }

        private static int GetVideoOffset(VideoDto video, MatchDetailDto match)
        {
            var matchStart = DateTimeUtils.FromUnixTimestamp(match.MatchCreation.ToString());
            return matchStart < video.RecordedAt
                ? 0
                : (int) (matchStart - video.RecordedAt).TotalSeconds;
        }
    }
}
