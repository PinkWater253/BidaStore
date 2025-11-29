using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class BrandService : IService<Brand>
    {
        private readonly HttpClient _httpClient;
        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Brand item)
        {
            var response = await _httpClient.PostAsJsonAsync<Brand>("api/brands", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response =  await _httpClient.DeleteAsync($"api/brands/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Brand?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Brand>($"api/brands/{id}");
        }

        public Task<List<Brand>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Brand>>("api/brands");
        }

        public Task<bool> UpdateItemAsync(Brand item)
        {
            var response =  _httpClient.PutAsJsonAsync<Brand>($"api/brands/{item.Id}", item);
            return response.ContinueWith(t => t.Result.IsSuccessStatusCode);
        }
    }
}
