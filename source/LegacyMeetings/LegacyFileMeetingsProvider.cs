using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LegacyMeetings
{
    public class LegacyFileMeetingsProvider : ILegacyMeetingsProvider
    {
        private readonly string _filePath;

        public LegacyFileMeetingsProvider(string filePath)
        {
            _filePath = filePath;
        }

        public List<LegacyMeeting> Fetch()
        {
            return File.ReadAllLines(_filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(ParseLine)
                .ToList();
        }

        public static LegacyMeeting ParseLine(string line)
        {
            var values = line.Split(';');

            return new LegacyMeeting
            {
                Title = values[0],
                Location = values[1],
                StartDateTime = DateTime.Parse(values[2], CultureInfo.InvariantCulture),
                EndDateTime = DateTime.Parse(values[3], CultureInfo.InvariantCulture),
                Priority = Enum.Parse<LegacyMeetingPriority>(values[4])
            };
        }
    }
}