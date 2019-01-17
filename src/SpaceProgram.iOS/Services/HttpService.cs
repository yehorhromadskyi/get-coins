using System;
using System.Net;
using System.Net.Http;

namespace SpaceProgram.iOS.Services
{
    public sealed class HttpService
    {
        private static readonly Lazy<HttpClient> httpClient =
            new Lazy<HttpClient>(() => new HttpClient(new HttpClientHandler()
            {
                Proxy = new WebProxy("http://127.0.0.1:5865"),
                UseProxy = true
            }));

        public static HttpClient Client => httpClient.Value;

        static HttpService() { }
    }
}