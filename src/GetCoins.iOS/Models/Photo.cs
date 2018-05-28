using System;
using Newtonsoft.Json;

namespace GetCoins.iOS.Models
{
    public class Photo
    {
        [JsonProperty("id")]
        public long Id
        {
            get;
            set;
        }

        [JsonProperty("img_src")]
        public string Image
        {
            get;
            set;
        }

        [JsonProperty("sol")]
        public long Sol
        {
            get;
            set;
        }

        [JsonProperty("earth_date")]
        public DateTimeOffset EarthDate
        {
            get;
            set;
        }
    }
}
