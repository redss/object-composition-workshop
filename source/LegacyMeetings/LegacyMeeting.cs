using System;

namespace LegacyMeetings
{
    public class LegacyMeeting : IComparable<LegacyMeeting>
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public LegacyMeetingPriority Priority { get; set; }

        public int CompareTo(LegacyMeeting other)
        {
            var priorityComparison = Priority - other.Priority;

            if (priorityComparison != 0)
            {
                return priorityComparison;
            }

            var startDateTimeComparison = StartDateTime.CompareTo(other.StartDateTime);

            if (startDateTimeComparison != 0)
            {
                return startDateTimeComparison;
            }

            return string.Compare(Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
        }
    }

    public enum LegacyMeetingPriority
    {
        Insignificant,
        Low,
        Medium,
        Major,
        Critical
    }
}