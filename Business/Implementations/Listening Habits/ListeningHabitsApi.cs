using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits;
using ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits.LastFm.Model;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits.LastFm
{
    public class ListeningHabitsApi : IListeningHabitsApi
    {
        private IHttpClientFactory _httpClientFactory;

        private const string _baseUrl = "https://ws.audioscrobbler.com/2.0/?";
        private const string _apiKey = "37c275055b74fd63d78944c9ddbacc36";

        private static readonly Dictionary<TopAlbumPeriod, string> _periodMapping = new Dictionary<TopAlbumPeriod, string>() {
            { TopAlbumPeriod.OneMonth, "1month" },
            { TopAlbumPeriod.ThreeMonths, "3month" },
            { TopAlbumPeriod.SixMonths, "6month" },
            { TopAlbumPeriod.OneYear, "12month" },
            { TopAlbumPeriod.AllTime, "overall" }
        };

        public ListeningHabitsApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public struct TopAlbumsResponse
        {
            [JsonPropertyName("topalbums")]
            public TopAlbums TopAlbums { get; set; }
        }

        public async Task<ITopAlbums> FetchTopAlbums(string username, TopAlbumPeriod period)
        {           
            var periodAsString = _periodMapping[period];

            var url = BuildUrl("user.gettopalbums", new Dictionary<string, string>() {
                { "user", username },
                { "period", periodAsString },
                { "limit", "100" },
            });

            Console.WriteLine("Fetching {0}", url);

            var httpClient = _httpClientFactory.CreateClient();

            var rawJsonAsString = await httpClient.GetStringAsync(url);

            var options = new JsonSerializerOptions();

            options.PropertyNameCaseInsensitive = true;

            var content = JsonSerializer.Deserialize<TopAlbumsResponse>(rawJsonAsString, options);

            return content.TopAlbums;
        }

        private string BuildUrl(string method, Dictionary<string, string> parameters)
        {
            StringBuilder completeUrl = new StringBuilder(_baseUrl);

            parameters["method"] = method;
            parameters["api_key"] = _apiKey;
            parameters["format"] = "json";

            var formattedParameters = parameters.Select(e => $"{e.Key}={e.Value}").ToList();

            completeUrl.AppendFormat(String.Join("&", formattedParameters));

            return completeUrl.ToString();
        }
    }
}
