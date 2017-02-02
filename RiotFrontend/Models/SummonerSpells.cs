using System.Collections.Generic;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.SummonerSpells;

namespace CoffeeCat.RiotFrontend.Models
{
    public class SummonerSpells
    {
        public Dictionary<int, SummonerSpellDto> Data { get; set; }
    }
}
