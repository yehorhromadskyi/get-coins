using Newtonsoft.Json;
using System.Collections.Generic;

namespace GetCoins.iOS.Models
{
    public class RoversResponse
    {
        [JsonProperty("rovers")]
        public List<Rover> Rovers { get; set; }
    }
}