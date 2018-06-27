using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardwareInventory.Repository
{
    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get(string getItemBy);
        Task<T> Add(T itemToAdd);
        Task<T> Update(T itemToUpdate);
    }
}
