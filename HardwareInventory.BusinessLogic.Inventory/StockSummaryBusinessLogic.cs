using HardwareInventory.Domain.Model;
using HardwareInventory.Repository.Inventory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardwareInventory.BusinessLogic.Inventory
{
    public class StockSummaryBusinessLogic
    {
        private readonly IStockSummaryRepository StockSummaryRepository;

        public StockSummaryBusinessLogic(IStockSummaryRepository stockSummaryRepository)
        {
            StockSummaryRepository = stockSummaryRepository;
        }

        public async Task<IEnumerable<StockSummary>> Get(string type) {
            try
            {
                var stockSummaries = await StockSummaryRepository.Get(type);
                if (stockSummaries != null)
                    return stockSummaries;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<StockSummary>> GetByDescription(string description)
        {
            try
            {
                var stockSummaries = await StockSummaryRepository.GetLikeDescription(description);
                if (stockSummaries != null)
                    return stockSummaries;
                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
