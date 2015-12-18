using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Frontend;
using CoffeeCat.RiotCommon.Dto.StaticData.Mastery;
using MatchContracts = CoffeeCat.RiotCommon.Dto.Match;

namespace CoffeeCat.RiotCommon.Utils.Formatter
{
    internal class MasteryFormatter : BaseFormatter
    {
        public MasteryFormatter(IStaticData staticData) : base(staticData)
        {
        }

        public Mastery FormatMastery(MatchContracts.MasteryDto masteryDto)
        {
            Validation.ValidateNotNull(masteryDto, nameof(masteryDto));

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
