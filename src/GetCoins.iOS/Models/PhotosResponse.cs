using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetCoins.iOS.Models
{
    public class PhotosResponse
    {
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}
