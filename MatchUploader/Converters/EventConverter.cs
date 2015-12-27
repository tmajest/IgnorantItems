using CoffeeCat.RiotCommon.Dto.Match;
using CoffeeCat.RiotCommon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeCat.MatchUploader.Converters
{
    internal class EventConverter
    {
        private static readonly List<EventDto> EmptyEventList = new List<EventDto>();

        public static IEnumerable<EventDto> GetEvents(MatchDetailDto match)
        {
            Validation.ValidateNotNull(match, nameof(match));

            var frames = match.TimeLine?.Frames;
            if (frames == null || frames.Count == 0)
            {
                return EmptyEventList;
            }

            // Get all events from all the frames
            var events = frames.Where(f => f?.Events != null).SelectMany(f => f.Events).Where(e => e != null);

            // Order the events by their timestamp
            return events.OrderBy(e => e.Timestamp);
        }

        public static IEnumerable<EventDto> GetEvents(MatchDetailDto match, Func<EventDto, bool> filter)
        {
            Validation.ValidateNotNull(filter, nameof(filter));

            var events = GetEvents(match);
            return events.Where(filter);
        }
    }
}
