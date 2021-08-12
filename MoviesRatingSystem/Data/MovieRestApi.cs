using MoviesRatingSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Data
{
    // use for get app Data  
    public class MovieRestApi
    {
        private const string Url = "http://62.90.114.24:9106/api/MoviesRatingSystem/";
        private readonly HttpClient _httpClient;
        public MovieRestApi()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Url),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public async Task<dynamic> GetMoviesDescrption()
        {
            var resultString = $"GetMoviesDescrption";
            var result = await CallAsync(HttpMethod.Get, resultString);
            return (dynamic)result;
        }

        public async Task<dynamic> GetOnlineVotes(DateTime lastReceived)
        {
            // ConvertFunc.ConvertFromDateTime for set the data in exact api format yyyy-MM-ddTHH:mm:ss 
            var resultString = $"GetOnlineVotes?lastReceived={ConvertFunc.ConvertFromDateTime(lastReceived)}";
            var result = await CallAsync(HttpMethod.Get, resultString);
            return (dynamic)result;
        }

        private async Task<string> CallAsync(HttpMethod method, string endpoint)
        {
            var request = new HttpRequestMessage(method, endpoint);
            var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return result;
        }
    }
}
