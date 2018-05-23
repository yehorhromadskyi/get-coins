using GetCoins.iOS.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace GetCoins.iOS.Services
{
    public class NasaApiService
    {
        private readonly string getRovers = string.Format(
            "https://api.nasa.gov/mars-photos/api/v1/rovers?api_key={0}", AppSettings.ApiKey);

        public async Task<List<Rover>> GetRoversAsync()
        {
            var rovers = new List<Rover>();

            using (var stream = await HttpService.Client.GetStreamAsync(getRovers))
            using (var streamReader = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                var response = serializer.Deserialize<RoversResponse>(reader);
                rovers = response.Rovers;
            }

            return rovers;
        }
    }
}