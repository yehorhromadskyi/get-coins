using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpaceProgram.iOS.Models
{
    public class RoversResponse
    {
        [JsonProperty("rovers")]
        public List<Rover> Rovers { get; set; }
    }
}