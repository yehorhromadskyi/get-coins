using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceProgram.iOS.Models
{
    public class PhotosResponse
    {
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}
