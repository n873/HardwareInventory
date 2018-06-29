using System.Collections.Generic;
using System.Threading.Tasks;
using HardwareInventory.Domain.Model;

namespace HardwareInventory.Repository.Inventory
{
    public interface IStockSummaryRepository
    {
        Task<StockSummary> Add(StockSummary stockSummaryToAdd);
        Task<StockSummary> Get(int id);
        Task<StockSummary> Get(string type, string code, string description);

        Task<IEnumerable<StockSummary>> Get(string type);
        Task<IEnumerable<StockSummary>> Get(string type, string code);

        Task<IEnumerable<StockSummary>> GetLikeDescription(string description);
        Task<StockSummary> Update(StockSummary stockSummaryToUpdate);
    }
}