using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GetCoins.iOS.Models
{
    public class Rover
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("landing_date")]
        public DateTimeOffset LandingDate { get; set; }

        [JsonProperty("launch_date")]
        public DateTimeOffset LaunchDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("max_sol")]
        public int MaxSol { get; set; }

        [JsonProperty("max_date")]
        public DateTimeOffset MaxDate { get; set; }

        [JsonProperty("total_photos")]
        public int TotalPhotos { get; set; }

        [JsonProperty("cameras")]
        public List<Camera> Cameras { get; set; }
    }
}