using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Utils;

namespace CoffeeCat.MatchUploader.Converters
{
    internal class ItemListConverter
    {
        private static readonly string ItemPurchased = "ITEM_PURCHASED";
        private static readonly List<string> EmptySummonerItemsList = new List<string>(); 

        public static List<string> GetSummonerItems(MatchDetailDto match, ParticipantDto participant)
        {
            Validation.ValidateNotNull(match, nameof(match));
            Validation.ValidateNotNull(participant, nameof(participant));

            var frames = match.TimeLine?.Frames;
            if (frames == null || frames.Count == 0)
            {
                return EmptySummonerItemsList;
            }

            // Get all events from all the frames
            var events = frames.Where(f => f?.Events != null).SelectMany(f => f.Events).Where(e => e != null);

            // Order the events by their timestamp
            var orderedEvents = events.OrderBy(e => e.Timestamp);

            // Get events relating to the given participant
            var participantEvents = orderedEvents.Where(e => e.ParticipantId == participant.ParticipantId);

            // Get events where the participant purchased an item
            var itemEvents = participantEvents.Where(
                e => e.EventType?.Equals(ItemPurchased, StringComparison.OrdinalIgnoreCase) ?? false);

            // Return all item IDs for the items that the participant purchased
            return itemEvents.Select(item => item.ItemId.ToString()).ToList();
        }
    }
}
