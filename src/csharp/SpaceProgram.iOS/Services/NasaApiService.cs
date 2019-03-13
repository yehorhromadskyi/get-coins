using SpaceProgram.iOS.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpaceProgram.iOS.Services
{
    public class NasaApiService
    {
        static readonly string BaseUrl = "https://api.nasa.gov/mars-photos/api/v1/rovers";

        readonly HttpClient _httpClient;

        public NasaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Rover>> GetRoversAsync()
        {
            var getRovers = string.Format("{0}?api_key={1}", BaseUrl, AppSettings.ApiKey);

            var rovers = new List<Rover>();

            using (var stream = await _httpClient.GetStreamAsync(getRovers))
            using (var streamReader = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                var response = serializer.Deserialize<RoversResponse>(reader);
                rovers = response.Rovers;
            }

            return rovers;
        }

        public async Task<List<Photo>> GetPhotosAsync(string rover, string camera, int page = 1)
        {
            var getPhotos = string.Format(
                "{0}/{1}/photos?sol=1000&camera={2}&page={3}&api_key={4}", 
                BaseUrl, rover, camera, page, AppSettings.ApiKey);

            var photos = new List<Photo>();

            using (var stream = await _httpClient.GetStreamAsync(getPhotos))
            using (var streamReader = new StreamReader(stream))
            using (var reader = new JsonTextReader(streamReader))
            {
                var serializer = new JsonSerializer();

                var response = serializer.Deserialize<PhotosResponse>(reader);
                photos = response.Photos;
            }

            return photos;
        }
    }
}