using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Uploader;
using CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Utils;
using Newtonsoft.Json;

namespace CoffeeCat.MatchUploader.Converters
{
    public class MatchConverter
    {
        internal static MatchEntity GetMatchEntity(MatchDetailDto matchDetails, MatchReferenceDto match, SummonerEntity summoner)
        {
            var summonerId = long.Parse(summoner.Id);
            var participantInfo = matchDetails.ParticipantIdentities.Single(p => p.Player.SummonerId == summonerId);
            var participant = matchDetails.Participants.Single(p => p.ParticipantId == participantInfo.ParticipantId);
            var team = matchDetails.Teams.First(teams => teams.TeamId.Equals(participant.TeamId));
            var otherTeam = matchDetails.Teams.First(teams => !teams.TeamId.Equals(participant.TeamId));

            var creationTime = DateTimeUtils.FromUnixTimestamp(matchDetails.MatchCreation.ToString());
            var matchInfo = new MatchInfo
            {
                MatchId = match.MatchId.ToString(),
                MatchCreationTime = creationTime,
                SummonerName = participantInfo.Player.SummonerName.ToLowerInvariant(),
                SummonerId = participantInfo.Player.SummonerId.ToString(),
                ProName = summoner.ProName,
                Participants = matchDetails.Participants,
                ChampionId = participant.ChampionId.ToString(),
                Region = matchDetails.Region,
                Masteries = participant.Masteries,
                Runes = participant.Runes,
                Won = team.Winner,
                MatchDuration = matchDetails.MatchDuration,
                Kills = participant.Stats.Kills,
                Deaths = participant.Stats.Deaths,
                Assists = participant.Stats.Assists,
                TeamBannedChampions = team.Bans,
                EnemyTeamBannedChampions = otherTeam.Bans,
                Items = new List<string> { participant.Stats.Item0.ToString(), participant.Stats.Item1.ToString(), participant.Stats.Item2.ToString(), participant.Stats.Item3.ToString(), participant.Stats.Item4.ToString(), participant.Stats.Item5.ToString() },
                ItemsBought = ItemListConverter.GetSummonerItems(matchDetails, participant),
                Spell1Id = participant.Spell1Id,
                Spell2Id = participant.Spell2Id
            };

            var matchJson = JsonConvert.SerializeObject(matchInfo);
            return new MatchEntity(summoner.PartitionKey, matchInfo.MatchId, matchInfo.ChampionId, creationTime, matchJson);
        }
    }
}
