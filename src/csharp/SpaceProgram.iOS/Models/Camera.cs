using Newtonsoft.Json;

namespace SpaceProgram.iOS.Models
{
    public class Camera
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }
    }
}