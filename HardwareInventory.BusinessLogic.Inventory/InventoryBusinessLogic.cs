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
                    var stockSummary = await StockSummaryRepository.Get(addedInventoryItem.Type, addedInventoryItem.Code, addedInventoryItem.Description);
                    if (stockSummary != null)
                    {
                        stockSummary.Total++;
                        stockSummary = await StockSummaryRepository.Update(stockSummary);
                        if (stockSummary != null)
                            return new Result
                            {
                                Success = true,
                                Message = "Successfully saved to inventory",
                                Description = $"Item {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})",
                                Response = addedInventoryItem.Id.ToString()
                            };
                        return new Result
                        {
                            Success = false,
                            Message = "Failed updating inventory summary",
                            Description = $"Item {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})"
                        };
                    }
                    stockSummary = await StockSummaryRepository.Add(new StockSummary
                    {
                        Code = inventoryItem.Code,
                        Description = inventoryItem.Description,
                        Type = inventoryItem.Type,
                        Total = 1
                    });
                    if (stockSummary != null)
                        return new Result
                        {
                            Success = true,
                            Message = "Successfully saved to inventory",
                            Description = $"Item {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})",
                            Response = addedInventoryItem.Id.ToString()
                        };
                    return new Result
                    {
                        Success = false,
                        Message = "Failed saving to inventory summary",
                        Description = $"Item {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})"
                    };
                }
                return new Result
                {
                    Success = false,
                    Message = "Failed saving to inventory",
                    Description = $"Item {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})"
                };
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InventoryItem>> Get(string type)
        {
            try
            {
                var inventoryItems = await InventoryItemRepository.Get(type);
                if (inventoryItems != null)
                    return inventoryItems;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InventoryItem>> Get(string type, string code)
        {
            try
            {
                var inventoryItems = await InventoryItemRepository.Get(type, code);
                if (inventoryItems != null)
                    return inventoryItems;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<Result> Update(InventoryItem inventoryItem)
        {
            try
            {
                var existingInventoryItem = await InventoryItemRepository.Get(inventoryItem.Id);
                if (existingInventoryItem != null)
                {
                    var updatedInventoryItem = await InventoryItemRepository.Update(inventoryItem);
                    if (updatedInventoryItem != null)
                        return new Result
                        {
                            Success = true,
                            Message = "Successfully updated inventory",
                            Description = $"Item {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})",
                            Response = updatedInventoryItem.Id.ToString()
                        };
                    return new Result
                    {
                        Success = false,
                        Message = "Failed to update inventory",
                        Description = $"Item {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})",
                    };
                }
                return new Result
                {
                    Success = false,
                    Message = "Failed to update inventory",
                    Description = $"Item doesn't exist - {inventoryItem.Type} {inventoryItem.Code} ({inventoryItem.Description})",
                };
            }
            catch (Exception) { throw; }
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                var existingInventoryItem = await InventoryItemRepository.Get(id);
                if (existingInventoryItem != null)
                {
                    existingInventoryItem.Deleted = true;
                    var updatedInventoryItem = await InventoryItemRepository.Update(existingInventoryItem);
                    if (updatedInventoryItem != null)
                        return new Result
                        {
                            Success = true,
                            Message = "Successfully deleted inventory",
                            Description = $"Item {existingInventoryItem.Type} {existingInventoryItem.Code} ({existingInventoryItem.Description})",
                            Response = updatedInventoryItem.Id.ToString()
                        };
                    return new Result
                    {
                        Success = false,
                        Message = "Failed to delete inventory",
                        Description = $"Item {existingInventoryItem.Type} {existingInventoryItem.Code} ({existingInventoryItem.Description})",
                    };
                }
                return new Result
                {
                    Success = false,
                    Message = "Failed to delete inventory",
                    Description = $"Item doesn't exist - {id})",
                };
            }
            catch (Exception) { throw; }
        }
    }
}
