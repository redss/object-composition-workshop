using System.Collections.Generic;

namespace LegacyMeetings
{
    public interface ILegacyMeetingsProvider
    {
        List<LegacyMeeting> Fetch();
    }
}