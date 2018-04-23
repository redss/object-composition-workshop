using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Meetings
{
    public class MeetingsPanel
    {
        public void Display()
        {
            Console.WindowWidth = 100;
            Console.BufferWidth = 100;

            Console.WriteLine("Loading meetings list...");

            var meetings = GetMeetings().ToArray();

            Console.Clear();

            if (meetings.Any())
            {
                foreach (var meeting in meetings)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(meeting.StartsAt.ToString("yyyy-MM-dd"));
                    Console.Write("  ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(meeting.StartsAt.ToString("HH:mm"));
                    Console.Write("-");
                    Console.Write(meeting.EndsAt.ToString("HH:mm"));
                    Console.Write("  ");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(meeting.Location.PadRight(25));

                    Console.ForegroundColor = _priorityColors[meeting.Priority];
                    Console.Write(meeting.Name);

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No meetings found!");
            }

            Console.ReadKey();
        }

        private Meeting[] GetMeetings()
        {
            return File.ReadAllLines(_filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(ParseLine)
                .ToArray();
        }

        private Meeting ParseLine(string line)
        {
            var values = line.Split(';');

            return new Meeting
            {
                Name = values[0],
                Location = values[1],
                StartsAt = DateTime.Parse(values[2], CultureInfo.InvariantCulture),
                EndsAt = DateTime.Parse(values[3], CultureInfo.InvariantCulture),
                Priority = Enum.Parse<MeetingPriority>(values[4])
            };
        }

        private readonly string _filePath = "Data/ProgrammerMeetings.csv";

        private readonly Dictionary<MeetingPriority, ConsoleColor> _priorityColors = new Dictionary<MeetingPriority, ConsoleColor>
        {
            { MeetingPriority.Low, ConsoleColor.Gray },
            { MeetingPriority.Medium, ConsoleColor.Cyan },
            { MeetingPriority.High, ConsoleColor.Red }
        };
    }
}