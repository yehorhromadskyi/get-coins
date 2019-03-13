using System;
using Newtonsoft.Json;

namespace SpaceProgram.iOS.Models
{
    public class Launch
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("windowstart")]
        public DateTimeOffset WindowStart { get; set; }

        [JsonProperty("windowend")]
        public DateTimeOffset WindowEnd { get; set; }

        [JsonProperty("net")]
        public string Net { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("tbdtime")]
        public long Tbdtime { get; set; }

        [JsonProperty("tbddate")]
        public long Tbddate { get; set; }

        [JsonProperty("probability")]
        public long? Probability { get; set; }

        [JsonProperty("changed")]
        public DateTimeOffset Changed { get; set; }

        [JsonProperty("lsp")]
        public long Lsp { get; set; }

        [JsonProperty("vidURLs")]
        public string[] VidUrLs { get; set; }

        [JsonProperty("vidURL")]
        public object VidUrl { get; set; }

        [JsonProperty("hashtag")]
        public string Hashtag { get; set; }
    }
}
