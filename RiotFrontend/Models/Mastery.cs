using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Mastery;

namespace CoffeeCat.RiotFrontend.Models
{
    public class Mastery
    {
        public long Rank { get; set; }

        public MasteryDto Data { get; set; }
    }
}
