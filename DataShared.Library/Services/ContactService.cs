using DataShared.Library.Models;
using System.Net.Http.Json;

namespace DataShared.Library.Services
{
    public class ContactService : IService<Contact>
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateItemAsync(Contact item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Contact", item);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Contact/{id}");
            return response.IsSuccessStatusCode;
        }

        public Task<Contact?> GetItemByIdAsync(int id)
        {
            return _httpClient.GetFromJsonAsync<Contact>($"api/Contact/{id}");
        }

        public Task<List<Contact>?> GetItemsAsync()
        {
            return _httpClient.GetFromJsonAsync<List<Contact>>("api/Contact");
        }

        public async Task<bool> UpdateItemAsync(Contact item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Contact/{item.Id}", item);
            return response.IsSuccessStatusCode;
        }
    }
}