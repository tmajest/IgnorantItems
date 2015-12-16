using CoffeeCat.RiotCommon.Dto.StaticData.Rune;

namespace CoffeeCat.RiotCommon.Contracts.Frontend
{
    public class Rune
    {
        public long Rank { get; set; }

        public RuneDto Data { get; set; }
    }
}
