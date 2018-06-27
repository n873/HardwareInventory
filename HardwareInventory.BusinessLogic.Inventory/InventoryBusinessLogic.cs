using HardwareInventory.Domain.Model;
using HardwareInventory.Repository.Inventory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HardwareInventory.BusinessLogic.Inventory
{
    public class InventoryItemBusinessLogic
    {
        private readonly IInventoryItemRepository InventoryItemRepository;
        private readonly IStockSummaryRepository StockSummaryRepository;

        public InventoryItemBusinessLogic(IInventoryItemRepository inventoryItemRepository,
            IStockSummaryRepository stockSummaryRepository)
        {
            InventoryItemRepository = inventoryItemRepository;
            StockSummaryRepository = stockSummaryRepository;
        }

        public async Task<Result> Add(InventoryItem inventoryItem)
        {
            try
            {
                var addedInventoryItem = await InventoryItemRepository.Add(inventoryItem);
                if (addedInventoryItem != null)
                {
                    var stockSummary = await StockSummaryRepository.GetByCode(addedInventoryItem.Type, addedInventoryItem.Code);
                    if (stockSummary != null)
                    {
                        stockSummary.Total++;
                        stockSummary = await StockSummaryRepository.Update(stockSummary);
                        if (stockSummary != null)
                            return new Result { };
                    }
                    stockSummary = await StockSummaryRepository.Add(new StockSummary { });
                    if (stockSummary != null)
                        return new Result { };
                    return new Result { };
                }
                return new Result { };
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InventoryItemRepository>> Get(string type)
        {
            try
            {
                var inventoryItems = await InventoryItemRepository.Get(type);
                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
