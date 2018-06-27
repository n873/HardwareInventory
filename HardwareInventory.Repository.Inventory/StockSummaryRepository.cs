using HardwareInventory.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareInventory.Repository.Inventory
{
    public class StockSummaryRepository : DbContext, IRepository<StockSummary>, IStockSummaryRepository
    {
        private DbSet<StockSummary> StockSummary { get; set; }

        public StockSummaryRepository(DbContextOptions options) : base(options) { }

        public async Task<StockSummary> Add(StockSummary stockSummaryToAdd)
        {
            try
            {
                var stockSummaryAdded = StockSummary.Add(stockSummaryToAdd);
                await SaveChangesAsync();
                if (stockSummaryAdded?.Entity != null)
                    return stockSummaryAdded.Entity;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<StockSummary> Get(int id)
        {
            try
            {
                var stockSummary = await StockSummary.FirstOrDefaultAsync(
                    summary => summary.Id == id);
                if (stockSummary != null)
                    return stockSummary;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<StockSummary>> Get(string type)
        {
            try
            {
                var stockSummaries = StockSummary.Where(summary => summary.Type == type);
                if (stockSummaries != null)
                    return await stockSummaries.ToListAsync();
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<StockSummary>> GetLikeDescription(string description)
        {
            try
            {
                var stockSummaries = from summary in StockSummary
                                     where EF.Functions.Like(summary.Description, description)
                                     select summary;

                if (stockSummaries != null)
                    return await stockSummaries.ToListAsync();
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<StockSummary> Update(StockSummary stockSummaryToUpdate)
        {
            try
            {
                var updatedStockSummary = StockSummary.Update(stockSummaryToUpdate);
                await SaveChangesAsync();
                if (updatedStockSummary?.Entity != null)
                    return updatedStockSummary.Entity;
                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
