﻿using System;
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
        private static readonly string ItemPurchasedEvent = "ITEM_PURCHASED";

        public static List<string> GetSummonerItems(MatchDetailDto match, ParticipantDto participant)
        {
            Validation.ValidateNotNull(match, nameof(match));
            Validation.ValidateNotNull(participant, nameof(participant));

            var events = EventConverter.GetEvents(match, e => EventFilter(e, participant.ParticipantId));

            // Return all item IDs for the items that the participant purchased
            return events.Select(e => e.ItemId.ToString()).ToList();
        }

        /// <summary>
        /// Get list of Item Ids for the participant's final build.
        /// </summary>
        public static List<string> GetFinalBuild(ParticipantDto participant)
        {
            return new List<long>
            {
                participant.Stats.Item0,
                participant.Stats.Item1,
                participant.Stats.Item2,
                participant.Stats.Item3,
                participant.Stats.Item4,
                participant.Stats.Item5,
                participant.Stats.Item6,
            }
            .Where(i => i > 0)
            .Select(i => i.ToString())
            .ToList();
        }

        private static bool EventFilter(EventDto e, int participantId)
        {
            return e.ParticipantId == participantId &&
                (e.EventType?.Equals(ItemPurchasedEvent, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
