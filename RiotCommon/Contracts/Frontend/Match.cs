using System;
using System.Collections.Generic;
using CoffeeCat.RiotCommon.Dto.StaticData.Champion;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;

namespace CoffeeCat.RiotCommon.Contracts.Frontend
{
    public class Match
    {
        public string MatchId { get; set; }

        public DateTime MatchCreationTime { get; set; }

        public string SummonerName { get; set; }

        public string ProName { get; set; }

        public string SummonerId { get; set; }

        public ChampionDto Champion { get; set; }

        public string Region { get; set; }

        public List<Mastery> Masteries { get; set; }

        public List<Rune> Runes { get; set; }

        public bool Won { get; set; }

        public long MatchDuration { get; set; }

        public long Kills { get; set; }

        public long Deaths { get; set; }

        public long Assists { get; set; }

        public List<ChampionDto> TeamBannedChampions { get; set; }

        public List<ChampionDto> EnemyTeamBannedChampions { get; set; }

        public List<ItemDto> ItemsBought { get; set; }

        public List<ItemDto> Items { get; set; }

        public int Spell1Id { get; set; }

        public int Spell2Id { get; set; }
    }
}
