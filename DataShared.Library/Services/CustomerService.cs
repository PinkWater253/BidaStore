using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class CustomerService : IService<Customer>
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Customer item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Customer", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Customer/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Customer?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Customer>($"api/Customer/{id}");
        }

        public Task<List<Customer>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Customer>>("api/Customer");
        }

        public async Task<bool> UpdateItemAsync(Customer item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Customer/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}