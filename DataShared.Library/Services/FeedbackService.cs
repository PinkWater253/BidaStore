using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class FeedbackService : IService<Feedback>
    {
        private readonly HttpClient _httpClient;

        public FeedbackService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Feedback item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Feedback", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Feedback/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Feedback?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Feedback>($"api/Feedback/{id}");
        }

        public Task<List<Feedback>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Feedback>>("api/Feedback");
        }

        public async Task<bool> UpdateItemAsync(Feedback item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Feedback/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}