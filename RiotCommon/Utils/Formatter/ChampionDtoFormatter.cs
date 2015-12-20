using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Dto.StaticData.Champion;

namespace CoffeeCat.RiotCommon.Utils.Formatter
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
                Spells = championDto.Spells,
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
    }
}
