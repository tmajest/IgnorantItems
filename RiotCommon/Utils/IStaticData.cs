using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Item;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Mastery;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Rune;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.SummonerSpells;

namespace CoffeeCat.RiotCommon.Utils
{
    public interface IStaticData
    {
        RuneListDto RuneList { get; }

        MasteryListDto MasteryList { get; }

        ChampionListDto ChampionList { get; }

        ItemListDto ItemList { get; }

        SummonerSpellListDto SummonerSpellList { get; }
    }
}