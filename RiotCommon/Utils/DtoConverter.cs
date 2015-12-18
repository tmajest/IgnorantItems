using CoffeeCat.RiotCommon.Contracts.Frontend;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.Uploader;
using CoffeeCat.RiotCommon.Dto.StaticData.Champion;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;
using CoffeeCat.RiotCommon.Dto.StaticData.Rune;
using MatchContracts = CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Dto.StaticData.Mastery;
using CoffeeCat.RiotCommon.Utils.Formatter;

namespace CoffeeCat.RiotCommon.Utils
{
    public class DtoConverter : IDtoConverter
    {
        private readonly MasteryFormatter masteryFormatter;
        private readonly RuneFormatter runeFormatter;
        private readonly ChampionFormatter championFormatter;
        private readonly ItemFormatter itemFormatter;
        private readonly MatchFormatter matchFormatter;

        public DtoConverter(IStaticData staticData)
        {
            Validation.ValidateNotNull(staticData, nameof(staticData));
            this.masteryFormatter = new MasteryFormatter(staticData);
            this.runeFormatter = new RuneFormatter(staticData);
            this.championFormatter = new ChampionFormatter(staticData);
            this.itemFormatter = new ItemFormatter(staticData);
            this.matchFormatter = new MatchFormatter(
                staticData,
                this.masteryFormatter,
                this.runeFormatter,
                this.championFormatter,
                this.itemFormatter);
        }

        public Match GetMatchContract(MatchInfo matchInfo, FormatType type)
        {
            return this.matchFormatter.FormatMatch(matchInfo, type);
        }

        public Rune GetRuneContract(MatchContracts.RuneDto runeDto)
        {
            return this.runeFormatter.FormatRune(runeDto);
        }

        public Mastery GetMasteryContract(MatchContracts.MasteryDto masteryDto)
        {
            return this.masteryFormatter.FormatMastery(masteryDto);
        }
    }
}
