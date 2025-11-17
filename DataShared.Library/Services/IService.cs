using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShared.Library.Services
{
    public interface IService<T>
    {
        Task<List<T>?> GetItemsAsync();
        Task<T?> GetItemByIdAsync(int id);
        Task<bool> CreateItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
    }
}
