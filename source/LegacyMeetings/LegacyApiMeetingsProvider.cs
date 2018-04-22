using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace LegacyMeetings
{
    public class LegacyApiMeetingsProvider : ILegacyMeetingsProvider
    {
        private readonly string _url;

        public LegacyApiMeetingsProvider(string url)
        {
            _url = url;
        }

        public List<LegacyMeeting> Fetch()
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(_url);

                return JsonConvert.DeserializeObject<List<LegacyMeeting>>(json);
            }
        }
    }
}