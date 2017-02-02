using CoffeeCat.RiotCommon.Contracts.Entities;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;
using CoffeeCat.RiotCommon.Utils;
using CoffeeCat.RiotCommon.Utils.Formatter;
using CoffeeCat.RiotFrontend.BusinessLogic.Formatter;
using CoffeeCat.RiotFrontend.Models;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Converters
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

        public Match GetMatchContract(
            MatchEntity matchInfo, 
            ParticipantEntity participant, 
            FormatType type)
        {
            return this.matchFormatter.FormatMatch(matchInfo, participant, type);
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
