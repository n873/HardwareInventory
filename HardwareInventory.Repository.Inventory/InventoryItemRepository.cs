using HardwareInventory.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareInventory.Repository.Inventory
{
    public class InventoryItemRepository : DbContext, IRepository<InventoryItem>, IInventoryItemRepository
    {
        private DbSet<InventoryItem> InventoryItem { get; set; }

        public InventoryItemRepository(DbContextOptions options) : base(options) { }

        public async Task<InventoryItem> Add(InventoryItem inventoryItemToAdd)
        {
            try
            {
                var inventoryItemAdded = InventoryItem.Add(inventoryItemToAdd);
                await SaveChangesAsync();
                if (inventoryItemAdded?.Entity != null)
                    return inventoryItemAdded.Entity;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<InventoryItem> Get(int id)
        {
            try
            {
                var inventoryItem = await InventoryItem.FirstOrDefaultAsync(
                    item => item.Id == id);
                if (inventoryItem != null)
                    return inventoryItem;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InventoryItem>> Get(string type)
        {
            try
            {
                var inventoryItems = InventoryItem.Where(item => item.Type == type);
                if (inventoryItems != null)
                    return await inventoryItems.ToListAsync();
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InventoryItem>> GetLikeDescription(string description)
        {
            try
            {
                var inventoryItems = from item in InventoryItem
                                     where EF.Functions.Like(item.Description, description)
                                     select item;

                if (inventoryItems != null)
                    return await inventoryItems.ToListAsync();
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<InventoryItem> Update(InventoryItem inventoryItemToUpdate)
        {
            try
            {
                var updatedInventoryItem = InventoryItem.Update(inventoryItemToUpdate);
                await SaveChangesAsync();
                if (updatedInventoryItem?.Entity != null)
                    return updatedInventoryItem.Entity;
                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
