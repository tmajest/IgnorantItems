using System.Linq;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Champion;
using CoffeeCat.RiotCommon.Utils;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Formatter
{
    internal class ChampionDtoFormatter : BaseFormatter
    {
        public ChampionDtoFormatter(IStaticData staticData) : base(staticData)
        {
        }

        public ChampionDto FormatChampionDetailed(string id)
        {
            var championDto = this.staticData.ChampionList.Data[id];
            return new ChampionDto
            {
                Id = championDto.Id,
                Image = championDto.Image,
                Name = championDto.Name,
                Passive = championDto.Passive,
                Spells = championDto.Spells.Select(FormatSpell).ToList()
            };
        }

        public ChampionDto FormatChampionSimple(string id)
        {
            var championDto = this.staticData.ChampionList.Data[id];
            return new ChampionDto
            {
                Id = championDto.Id,
                Image = championDto.Image,
                Name = championDto.Name
            };
        }

        private ChampionSpellDto FormatSpell(ChampionSpellDto spell)
        {
            return new ChampionSpellDto
            {
                SanitizedDescription = spell.SanitizedDescription,
                Image = spell.Image,
                Name = spell.Name
            };
        }
    }
}
