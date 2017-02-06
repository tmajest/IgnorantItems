using System;
using System.Linq;
using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotCommon.Utils.Formatter;
using CoffeeCat.RiotFrontend.Models;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Formatter
{
    internal class MatchFormatter : BaseFormatter
    {
        private readonly MasteryFormatter masteryFormatter;
        private readonly RuneFormatter runeFormatter;
        private readonly ChampionDtoFormatter championFormatter;
        private readonly ItemDtoFormatter itemFormatter;

        public MatchFormatter(
            IStaticData staticData,
            MasteryFormatter masteryFormatter,
            RuneFormatter runeFormatter,
            ChampionDtoFormatter championFormatter,
            ItemDtoFormatter itemFormatter) 
            : base(staticData)
        {
            this.masteryFormatter = masteryFormatter;
            this.runeFormatter = runeFormatter;
            this.championFormatter = championFormatter;
            this.itemFormatter = itemFormatter;
        }

        public Match FormatMatch(
            MatchEntity matchInfo, 
            ParticipantEntity participant, 
            FormatType type)
        {
            return type == FormatType.Detailed
                ? FormatMatchDetailed(matchInfo, participant)
                : FormatMatchSimple(matchInfo, participant);
        }

        private Match FormatMatchDetailed(MatchEntity match, ParticipantEntity participant)
        {
            var stream = match.Streams.FirstOrDefault(s => s.Streamer.Id == participant.Summoner.Streamer.Id);
            return new Match
            {
                MatchId = match.Id.ToString(),
                TwitchVideoId = stream.StreamId,
                TwitchOffset = stream.Offset,
                ProName = participant.Summoner.Streamer.ProName,
                SummonerName = participant.Summoner.Name,
                SummonerId = participant.Summoner.Id.ToString(),
                Champion = championFormatter.FormatChampionDetailed(participant.ChampionId.ToString()),
                Region = match.Region,
                Masteries = participant.MasteryList?.Select(masteryFormatter.FormatMastery).ToList(),
                Runes = participant.RuneList?.Select(runeFormatter.FormatRune).ToList(),
                Won = participant.Won,
                MatchDuration = match.Duration,
                MatchCreationTime = match.CreationTime,
                Kills = participant.Kills,
                Deaths = participant.Deaths,
                Assists = participant.Assists,
                Spell1Id = participant.SummonerSpell1,
                Spell2Id = participant.SummonerSpell2,
                SkillOrder = participant.SkillOrder?.ToList(),
                FinalBuild = participant.FinalItems?.Where(x => !x.Equals("0")).Select(itemFormatter.FormatItem).ToList(),
                BlueSideBannedChampions = match.BlueSideBans?
                    .Select(c => championFormatter.FormatChampionDetailed(c.ToString())).ToList(),
                RedSideBannedChampions = match.RedSideBans?
                    .Select(c => championFormatter.FormatChampionDetailed(c.ToString())).ToList(),
                ItemsBought = itemFormatter.FormatItems(participant.ItemsBought)
            };
        }

        private Match FormatMatchSimple(MatchEntity match, ParticipantEntity participant)
        {
            return new Match
            {
                MatchId = match.Id.ToString(),
                ProName = participant.Summoner.Streamer.ProName,
                SummonerName = participant.SummonerName,
                SummonerId = participant.Summoner.Id.ToString(),
                Champion = championFormatter.FormatChampionSimple(participant.ChampionId.ToString()),
                Region = match.Region,
                Won = participant.Won,
                MatchDuration = match.Duration,
                Kills = participant.Kills,
                Deaths = participant.Deaths,
                Assists = participant.Assists,
                Spell1Id = participant.SummonerSpell1,
                Spell2Id = participant.SummonerSpell2,
                FinalBuild = participant.FinalItems?.Where(x => !x.Equals("0")).Select(itemFormatter.FormatItem).ToList(),
            };
        }
    }
}
