using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Dto.StaticData.Item;

namespace CoffeeCat.RiotCommon.Utils.Formatter
{
    internal class ItemDtoFormatter : BaseFormatter
    {
        public ItemDtoFormatter(IStaticData staticData) : base(staticData)
        {
        }

        public ItemDto FormatItem(string itemId)
        {
            Validation.ValidateNotNullOrWhitespace(itemId, nameof(itemId));

            var itemDto = CloneDto(this.staticData.ItemList.Data[itemId]);
            return new ItemDto
            {
                Description = itemDto.Description,
                Id = itemDto.Id,
                Image = itemDto.Image,
                Name = itemDto.Name,
                SanitizedDescription = itemDto.SanitizedDescription
            };
        }
    }
}
