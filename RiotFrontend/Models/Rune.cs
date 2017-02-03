using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Rune;

namespace CoffeeCat.RiotFrontend.Models
{
    public class Rune
    {
        public long Rank { get; set; }

        public RuneDto Data { get; set; }
    }
}
