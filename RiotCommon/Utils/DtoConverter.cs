using CoffeeCat.RiotCommon.Contracts.Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Uploader;
using CoffeeCat.RiotCommon.Dto.StaticData.Champion;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;
using CoffeeCat.RiotCommon.Dto.StaticData.Rune;
using MatchContracts = CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Dto.StaticData.Mastery;

namespace CoffeeCat.RiotCommon.Utils
{
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class DtoConverter : IDtoConverter
    {
        private readonly IStaticData staticData;

        [ImportingConstructor]
        public DtoConverter(IStaticData staticData)
        {
            Validation.ValidateNotNull(staticData, nameof(staticData));
            this.staticData = staticData;
        }

        public Match GetMatchContract(MatchInfo matchInfo)
        {
            return new Match
            {
                MatchId = matchInfo.MatchId,
                SummonerName = matchInfo.SummonerName,
                ProName = matchInfo.ProName,
                SummonerId = matchInfo.SummonerId,
                Champion = this.staticData.ChampionList.Data[matchInfo.ChampionId],
                Region = matchInfo.Region,
                Masteries = matchInfo.Masteries.Select(GetMasteryContract).ToList(),
                Runes = matchInfo.Runes.Select(GetRuneContract).ToList(),
                Won = matchInfo.Won,
                MatchDuration = matchInfo.MatchDuration,
                MatchCreationTime = matchInfo.MatchCreationTime,
                Kills = matchInfo.Kills,
                Deaths = matchInfo.Deaths,
                Assists = matchInfo.Assists,
                EnemyTeamBannedChampions = matchInfo.EnemyTeamBannedChampions.Select(c => GetChampionDto(c.ChampionId)).ToList(),
                TeamBannedChampions = matchInfo.TeamBannedChampions.Select(c => GetChampionDto(c.ChampionId)).ToList(),
                ItemsBought = matchInfo.ItemsBought.Select(GetItemDto).ToList()
            };
        }

        public Rune GetRuneContract(MatchContracts.RuneDto runeDto)
        {
            Validation.ValidateNotNull(runeDto, nameof(runeDto));

            var staticRune = this.staticData.RuneList.Data[runeDto.RuneId.ToString()];
            var clonedRune = CloneDto<RuneDto>(staticRune);
            clonedRune.SanitizedDescription = GetModifiedRuneDescription(clonedRune.SanitizedDescription, runeDto.Rank);
            return new Rune
            {
                Data = clonedRune,
                Rank = runeDto.Rank
            };
        }

        public Mastery GetMasteryContract(MatchContracts.MasteryDto masteryDto)
        {
            Validation.ValidateNotNull(masteryDto, nameof(masteryDto));

            var staticMastery = this.staticData.MasteryList.Data[masteryDto.MasteryId.ToString()];
            var clonedMastery = CloneDto<MasteryDto>(staticMastery);
            return new Mastery
            {
                Data = clonedMastery,
                Rank = masteryDto.Rank
            };
        }

        private string GetModifiedRuneDescription(string description, long rank)
        {
            var modified = description
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s =>
                {
                    var start = "";
                    var end = "";
                    if (s.StartsWith("("))
                    {
                        start += "(";
                        s = s.Substring(1);
                    }
                    if (s.StartsWith("+") || s.StartsWith("-"))
                    {
                        start += s[0];
                        s = s.Substring(1);
                    }
                    if (s.EndsWith("%"))
                    {
                        end += "%";
                        s = s.Substring(0, s.Length - 1);
                    }

                    double value;
                    if (double.TryParse(s, out value))
                    {
                        var newValue = value * rank;
                        return string.Concat(start, newValue, end);
                    }

                    return s;
                });

            return string.Join(" ", modified);
        }

        private ChampionDto GetChampionDto(int id)
        {
            return this.staticData.ChampionList.Data[id.ToString()];
        }

        private ItemDto GetItemDto(string itemId)
        {
            Validation.ValidateNotNullOrWhitespace(itemId, nameof(itemId));
            return this.staticData.ItemList.Data[itemId];
        }

        private static T CloneDto<T>(T obj)
        {
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));
        }
    }
}
