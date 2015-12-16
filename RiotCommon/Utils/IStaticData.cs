using System.ComponentModel.Composition;
using CoffeeCat.RiotCommon.Dto.StaticData.Champion;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;
using CoffeeCat.RiotCommon.Dto.StaticData.Mastery;
using CoffeeCat.RiotCommon.Dto.StaticData.Rune;

namespace CoffeeCat.RiotCommon.Utils
{
    [InheritedExport(typeof(IStaticData))]
    public interface IStaticData
    {
        RuneListDto RuneList { get; }

        MasteryListDto MasteryList { get; }

        ChampionListDto ChampionList { get; }

        ItemListDto ItemList { get; }
    }
}