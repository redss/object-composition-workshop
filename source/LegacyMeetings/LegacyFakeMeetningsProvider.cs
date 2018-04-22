using System.Collections.Generic;
using System.Linq;

namespace LegacyMeetings
{
    public class LegacyFakeMeetningsProvider : ILegacyMeetingsProvider
    {
        private readonly LegacyMeeting[] _legacyMeetings;
        
        public LegacyFakeMeetningsProvider(List<LegacyMeeting> legacyMeetings)
        {
            _legacyMeetings = legacyMeetings.ToArray();
        }

        public List<LegacyMeeting> Fetch()
        {
            return _legacyMeetings.ToList();
        }
    }
}