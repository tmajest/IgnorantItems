using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeCat.RiotCommon.Contracts.RiotApi.Match;

namespace CoffeeCat.MatchUploader.Converters
{
    internal class SkillOrderConverter
    {
        private static readonly string SkillOrderUpEvent = "SKILL_LEVEL_UP";

        public static List<int> GetSkillOrder(MatchDetailDto match, ParticipantDto participant)
        {
            Validation.ValidateNotNull(match, nameof(match));

            var levelUpEvents = EventConverter.GetEvents(match, e => EventFilter(e, participant.ParticipantId));
            return levelUpEvents.Select(e => e.SkillSlot).ToList();
        }

        private static bool EventFilter(EventDto e, int participantId)
        {
            return e.ParticipantId == participantId &&
                (e.EventType?.Equals(SkillOrderUpEvent, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
