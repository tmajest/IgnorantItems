using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Frontend;
using MasteryDto = CoffeeCat.RiotCommon.Contracts.RiotApi.Match.MasteryDto;

namespace CoffeeCat.RiotCommon.Utils.Formatter
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
