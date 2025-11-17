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

        public Task<bool> CreateItemAsync(Category item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category?> GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>?> GetItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>("api/Category");
        }

        public Task<bool> UpdateItemAsync(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
