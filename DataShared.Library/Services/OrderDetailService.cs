using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class OrderDetailService : IService<OrderDetail>
    {
        private readonly HttpClient _httpClient;

        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(OrderDetail item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/OrderDetail", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/OrderDetail/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<OrderDetail?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<OrderDetail>($"api/OrderDetail/{id}");
        }

        public Task<List<OrderDetail>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<OrderDetail>>("api/OrderDetail");
        }

        public async Task<bool> UpdateItemAsync(OrderDetail item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/OrderDetail/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}