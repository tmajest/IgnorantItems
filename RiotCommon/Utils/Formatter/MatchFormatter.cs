using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Frontend;
using CoffeeCat.RiotCommon.Contracts.Uploader;

namespace CoffeeCat.RiotCommon.Utils.Formatter
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

        public Match FormatMatch(MatchInfo matchInfo, FormatType type)
        {
            return type == FormatType.Detailed
                ? FormatMatchDetailed(matchInfo)
                : FormatMatchSimple(matchInfo);
        }

        private Match FormatMatchDetailed(MatchInfo matchInfo)
        {
            return new Match
            {
                MatchId = matchInfo.MatchId,
                SummonerName = matchInfo.SummonerName,
                ProName = matchInfo.ProName,
                SummonerId = matchInfo.SummonerId,
                Champion = championFormatter.FormatChampionDetailed(matchInfo.ChampionId),
                Region = matchInfo.Region,
                Masteries = matchInfo.Masteries.Select(masteryFormatter.FormatMastery).ToList(),
                Runes = matchInfo.Runes.Select(runeFormatter.FormatRune).ToList(),
                Won = matchInfo.Won,
                MatchDuration = matchInfo.MatchDuration,
                MatchCreationTime = matchInfo.MatchCreationTime,
                Kills = matchInfo.Kills,
                Deaths = matchInfo.Deaths,
                Assists = matchInfo.Assists,
                Spell1Id = matchInfo.Spell1Id,
                Spell2Id = matchInfo.Spell2Id,
                EnemyTeamBannedChampions = matchInfo.EnemyTeamBannedChampions
                    .Select(c => championFormatter.FormatChampionDetailed(c.ChampionId.ToString())).ToList(),
                TeamBannedChampions = matchInfo.TeamBannedChampions
                    .Select(c => championFormatter.FormatChampionDetailed(c.ChampionId.ToString())).ToList(),
                ItemsBought = matchInfo.ItemsBought.Select(itemFormatter.FormatItem).ToList()
            };
        }

        private Match FormatMatchSimple(MatchInfo matchInfo)
        {
            return new Match
            {
                MatchId = matchInfo.MatchId,
                SummonerName = matchInfo.SummonerName,
                ProName = matchInfo.ProName,
                SummonerId = matchInfo.SummonerId,
                Champion = championFormatter.FormatChampionSimple(matchInfo.ChampionId),
                Region = matchInfo.Region,
                Won = matchInfo.Won,
                MatchDuration = matchInfo.MatchDuration,
                Kills = matchInfo.Kills,
                Deaths = matchInfo.Deaths,
                Assists = matchInfo.Assists,
                Spell1Id = matchInfo.Spell1Id,
                Spell2Id = matchInfo.Spell2Id,
            };
        }
    }
}
