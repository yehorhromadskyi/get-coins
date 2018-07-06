using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetCoins.iOS.Models
{
    public class LaunchesResponse
    {
        [JsonProperty("launches")]
        public List<Launch> Launches { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
