using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace concertfit.Models
{

    public partial class Dates
    {
        [JsonProperty("start")]
        public End Start { get; set; }

        [JsonProperty("end")]
        public End End { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("displayOptions")]
        public DisplayOptions DisplayOptions { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}
