using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GetCoins.iOS.Models;
using Newtonsoft.Json;

namespace GetCoins.iOS.Services
{
    public class LaunchLibraryApiService
    {
        const string ApiVersion = "1.4";

        static readonly string BaseUrl = string.Format("https://launchlibrary.net/{0}", ApiVersion);

        readonly HttpClient _httpClient;

        public LaunchLibraryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Launch>> GetLaunchesAsync(int page = 0)
        {
            var getLaunches = string.Format("{0}/launch?offset={1}", BaseUrl, page);

            var launches = new List<Launch>();

            using (var stream = await _httpClient.GetStreamAsync(getLaunches))
            using (var streamReader = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                var response = serializer.Deserialize<LaunchesResponse>(reader);
                launches = response.Launches;
            }

            return launches;
        }
    }
}
