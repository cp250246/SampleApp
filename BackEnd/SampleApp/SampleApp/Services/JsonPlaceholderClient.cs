using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SampleApp.Models;

namespace SampleApp.Services
{
    public class JsonPlaceholderClient
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _httpClient;

        public JsonPlaceholderClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;

            _httpClient = _clientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "users");
            var response = await _httpClient.SendAsync(request);
            return await CheckResponse<Users>(response);
        }

        public async Task<IEnumerable<Albums>> GetAlbums(long userId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "albums?userId=" + userId);
            var response = await _httpClient.SendAsync(request);
            return await CheckResponse<Albums>(response);

        }

        public async Task<IEnumerable<Photos>> GetPhotos(long albumId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "photos?albumId=" + albumId);
            var response = await _httpClient.SendAsync(request);
            return await CheckResponse<Photos>(response);
        }

        public async Task<IEnumerable<T>> CheckResponse<T>(HttpResponseMessage response)
        {
            List<T> list = new List<T>();
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                list = await JsonSerializer.DeserializeAsync
                    <List<T>>(responseStream, options);
            }

            return list;

        }


    }
}
