using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Rune;

namespace CoffeeCat.RiotCommon.Contracts.Frontend
{
    public class Rune
    {
        public long Rank { get; set; }

        public RuneDto Data { get; set; }
    }
}
