using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class OrderService : IService<Order>
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Order item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Order", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Order/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Order?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Order>($"api/Order/{id}");
        }

        public Task<List<Order>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Order>>("api/Order");
        }

        public async Task<bool> UpdateItemAsync(Order item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Order/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}