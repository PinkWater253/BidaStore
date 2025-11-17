using DataShared.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataShared.Library.Services
{
    public class ProductService : IService<Product>
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Product item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Product", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Product/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<Product?> GetItemByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }

        public async Task<List<Product>?> GetItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/Product");
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Product/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}
