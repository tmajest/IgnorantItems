using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.UploaderV2;
using CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Utils;
using Newtonsoft.Json;

namespace CoffeeCat.MatchUploader.Converters
{
    internal class MatchConverter
    {
        internal static MatchEntity GetMatchEntity(
            MatchDetailDto matchDetails, 
            MatchReferenceDto match, 
            SummonerEntity summoner)
        {
            return new MatchEntity
            {
                Id = match.MatchId,
                Duration = (int) matchDetails.MatchDuration,
                CreationTime = DateTimeUtils.FromUnixTimestamp(matchDetails.MatchCreation.ToString()),
                Region = matchDetails.Region,
                BlueSideBans = matchDetails.Teams.First().Bans.Select(b => b.ChampionId).ToList(),
                RedSideBans = matchDetails.Teams.Last().Bans.Select(b => b.ChampionId).ToList(),
                Winner = matchDetails.Teams.First().Winner ? "Blue" : "Red",
            };
        }
    }
}
