using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class CartService : IService<Cart>
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Cart item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Cart", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Cart/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Cart?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Cart>($"api/Cart/{id}");
        }

        public Task<List<Cart>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Cart>>("api/Cart");
        }

        public async Task<bool> UpdateItemAsync(Cart item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Cart/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}