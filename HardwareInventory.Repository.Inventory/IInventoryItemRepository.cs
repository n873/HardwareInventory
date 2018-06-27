using System.Collections.Generic;
using System.Threading.Tasks;
using HardwareInventory.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace HardwareInventory.Repository.Inventory
{
    public interface IInventoryItemRepository
    {
        Task<InventoryItem> Add(InventoryItem inventoryItemToAdd);
        Task<InventoryItem> Get(int id);
        Task<IEnumerable<InventoryItem>> Get(string type);
        Task<IEnumerable<InventoryItem>> GetLikeDescription(string description);
        Task<InventoryItem> Update(InventoryItem inventoryItemToUpdate);
    }
}