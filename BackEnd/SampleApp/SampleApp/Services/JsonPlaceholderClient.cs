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
            var users = new List<Users>();
            
            var request = new HttpRequestMessage(HttpMethod.Get, "users");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                users = await JsonSerializer.DeserializeAsync
                    <List<Users>>(responseStream, options);
            }

            return users;
        }
        
        
        public async Task<IEnumerable<Albums>> GetAlbums()
        {
            var albums = new List<Albums>();
            
            var request = new HttpRequestMessage(HttpMethod.Get, "albums");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                albums = await JsonSerializer.DeserializeAsync
                    <List<Albums>>(responseStream, options);
            }

            return albums;
        }
        
        public async Task<IEnumerable<Albums>> GetAlbums(long userId)
        {
            var albums = new List<Albums>();
            
            var request = new HttpRequestMessage(HttpMethod.Get, "albums?userId=" + userId);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                albums = await JsonSerializer.DeserializeAsync
                    <List<Albums>>(responseStream, options);
            }

            return albums;
        }
        
        
        public async Task<IEnumerable<Photos>> GetPhotos(long albumId)
        {
            var photos = new List<Photos>();
            
            var request = new HttpRequestMessage(HttpMethod.Get, "photos?albumId=" + albumId);
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };
                photos = await JsonSerializer.DeserializeAsync
                    <List<Photos>>(responseStream, options);
            }

            return photos;
        }
    }
}