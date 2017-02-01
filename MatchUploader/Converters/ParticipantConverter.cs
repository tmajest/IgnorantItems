using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;
using Microsoft.Data.OData.Query.SemanticAst;

namespace CoffeeCat.MatchUploader.Converters
{
    internal class ParticipantConverter
    {
        internal static List<ParticipantEntity> GetParticipants(MatchDetailDto matchDetails, RiotContext context)
        {
            var entities =
                from identity in matchDetails.ParticipantIdentities
                from participant in matchDetails.Participants
                from team in matchDetails.Teams
                where identity.ParticipantId.Equals(participant.ParticipantId) && team.TeamId == participant.TeamId
                select new ParticipantEntity
                {
                    Summoner = context.Summoners.FirstOrDefault(s => s.Id == identity.Player.SummonerId),
                    SummonerName = identity.Player.SummonerName,
                    ChampionId = participant.ChampionId,
                    MasteryList = participant.Masteries,
                    RuneList = participant.Runes,
                    ItemsBought = ItemListConverter.GetSummonerItems(matchDetails, participant),
                    Won = team.Winner,
                    Kills = (int) participant.Stats.Kills,
                    Deaths = (int) participant.Stats.Deaths,
                    Assists = (int) participant.Stats.Assists,
                    SummonerSpell1 = participant.Spell1Id,
                    SummonerSpell2 = participant.Spell2Id,
                    Team = team.TeamId == matchDetails.Teams.First().TeamId ? "Blue" : "Red"
                };

            return entities.ToList();
        }
    }
}