using System;

namespace Meetings
{
    public class Meeting
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
        public MeetingPriority Priority { get; set; }
    }

    public enum MeetingPriority
    {
        Low,
        Medium,
        High
    }
}
