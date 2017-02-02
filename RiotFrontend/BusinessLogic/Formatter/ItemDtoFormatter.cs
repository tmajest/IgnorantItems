using System.Collections.Generic;
using CoffeeCat.RiotCommon.Contracts.RiotApi.StaticData.Item;
using CoffeeCat.RiotCommon.Utils;

namespace CoffeeCat.RiotFrontend.BusinessLogic.Formatter
{
    internal class ItemDtoFormatter : BaseFormatter
    {
        private static readonly List<ItemDto> EmptyItemList = new List<ItemDto>();

        public ItemDtoFormatter(IStaticData staticData) : base(staticData)
        {
        }

        public List<ItemDto> FormatItems(List<string> itemIds)
        {
            if (itemIds == null)
            {
                return EmptyItemList;
            }

            var prev = "";
            var items = new List<ItemDto>();
            foreach (var itemId in itemIds)
            {
                if (!itemId.Equals("0") && !itemId.Equals(prev))
                {
                    prev = itemId;
                    items.Add(FormatItem(itemId));
                }
            }

            return items;
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
