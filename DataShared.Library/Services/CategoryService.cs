using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Category item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Category", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await  _httpClient.DeleteAsync($"api/Category/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Category?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Category>($"api/Category/{id}");
        }

        public Task<List<Category>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Category>>("api/Category");
        }

        public async Task<bool> UpdateItemAsync(Category item)
        {
            var response = await  _httpClient.PutAsJsonAsync($"api/Category/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}
