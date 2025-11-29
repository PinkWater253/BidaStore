using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class PostService : IService<Post>
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Post item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Post", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Post/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Post?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Post>($"api/Post/{id}");
        }

        public Task<List<Post>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Post>>("api/Post");
        }

        public async Task<bool> UpdateItemAsync(Post item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Post/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}