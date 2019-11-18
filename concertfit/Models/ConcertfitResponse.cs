using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace concertfit.Models
{
    public class ConcertfitResponse
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("track")]
        public SpotifyArtistsResponse.Track[] Track { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("eventUrl")]
        public string EventUrl { get; set; }

        [JsonProperty("dates")]
        public TicketMasterResponse.Dates Dates { get; set; }
    }
}
