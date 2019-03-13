using System;
using System.Net;
using System.Net.Http;

namespace SpaceProgram.iOS.Services
{
    public sealed class HttpService
    {
        private static readonly Lazy<HttpClient> httpClient =
            new Lazy<HttpClient>(() => new HttpClient());

        public static HttpClient Client => httpClient.Value;

        static HttpService() { }
    }
}