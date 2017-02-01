using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Utils.Formatter;
using CoffeeCat.RiotCommon.Contracts.Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasteryDto = CoffeeCat.RiotCommon.Contracts.RiotApi.Match.MasteryDto;
using RuneDto = CoffeeCat.RiotCommon.Contracts.RiotApi.Match.RuneDto;

namespace CoffeeCat.RiotCommon.Utils
{
    public class DtoConverter : IDtoConverter
    {
        private readonly MasteryFormatter masteryFormatter;
        private readonly RuneFormatter runeFormatter;
        private readonly ChampionDtoFormatter championFormatter;
        private readonly ItemDtoFormatter itemFormatter;
        private readonly MatchFormatter matchFormatter;

        public DtoConverter(IStaticData staticData)
        {
            Validation.ValidateNotNull(staticData, nameof(staticData));
            this.masteryFormatter = new MasteryFormatter(staticData);
            this.runeFormatter = new RuneFormatter(staticData);
            this.championFormatter = new ChampionDtoFormatter(staticData);
            this.itemFormatter = new ItemDtoFormatter(staticData);
            this.matchFormatter = new MatchFormatter(
                staticData,
                this.masteryFormatter,
                this.runeFormatter,
                this.championFormatter,
                this.itemFormatter);
        }

        public Match GetMatchContract(MatchEntity matchInfo, FormatType type)
        {
            return this.matchFormatter.FormatMatch(matchInfo, type);
        }

        public Rune GetRuneContract(RuneDto runeDto)
        {
            return this.runeFormatter.FormatRune(runeDto);
        }

        public Mastery GetMasteryContract(MasteryDto masteryDto)
        {
            return this.masteryFormatter.FormatMastery(masteryDto);
        }
    }
}
