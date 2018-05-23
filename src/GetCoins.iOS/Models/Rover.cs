using System;

namespace GetCoins.iOS.Models
{
    public class Rover
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset LandingDate { get; set; }
        public DateTimeOffset LaunchDate { get; set; }
        public string Status { get; set; }
        public long MaxSol { get; set; }
        public DateTimeOffset MaxDate { get; set; }
        public long TotalPhotos { get; set; }
        public Camera[] Cameras { get; set; }
    }
}