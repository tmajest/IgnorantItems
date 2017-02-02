using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotFrontend.Models;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Formatter
{
    internal class MasteryFormatter : BaseFormatter
    {
        public MasteryFormatter(IStaticData staticData) : base(staticData)
        {
        }

        public Mastery FormatMastery(MasteryDto masteryDto)
        {
            var staticMastery = this.staticData.MasteryList.Data[masteryDto.MasteryId.ToString()];
            var clonedMastery = CloneDto(staticMastery);

            return new Mastery
            {
                Data = clonedMastery,
                Rank = masteryDto.Rank
            };
        }
    }
}
