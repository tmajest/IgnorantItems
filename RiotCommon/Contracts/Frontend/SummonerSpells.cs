using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.SummonerSpells;

namespace CoffeeCat.RiotCommon.Contracts.Frontend
{
    public class SummonerSpells
    {
        public Dictionary<int, SummonerSpellDto> Data { get; set; }
    }
}
