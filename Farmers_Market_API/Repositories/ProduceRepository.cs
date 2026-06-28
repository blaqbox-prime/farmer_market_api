using System;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using Farmers_Market_API.Data;
using Farmers_Market_API.Enums;
using Farmers_Market_API.Exceptions;
using Farmers_Market_API.Interfaces;
using Farmers_Market_API.Models;

namespace Farmers_Market_API.Repositories
{
    public class ProduceRepository(AppDbContext db): IRepository<ProduceListing>
    {
        private readonly AppDbContext _db = db;

        public async Task AddAsync(ProduceListing produce) 
        {
            
            if (string.IsNullOrEmpty(produce.ProduceName)) { throw new InvalidProduceFormatException("Produce name cannot be null or empty."); }
            if (produce.PricePerKg < 0) { throw new InvalidProduceFormatException("Price per kg cannot be negative."); }
            if (produce.QuantityKg < 0) { throw new InvalidProduceFormatException("Quantity per kg cannot be negative."); }
            _db.ProduceListings.Add(produce);
            await _db.SaveChangesAsync();
        }

        public async Task<List<ProduceListing>> GetAllAsync() { return await _db.ProduceListings.ToListAsync(); }

        public async Task<ProduceListing?> GetByIdAsync(int id)
        {
           var produce = await _db.ProduceListings.FirstAsync((p) => p.Id == id, CancellationToken.None);
           return produce ?? throw new ListingNotFoundException($"Produce listing with ID {id} not found.");
        }

        public async Task<List<ProduceListing>> GetByCategory(Category category)
        {
            var produce = await _db.ProduceListings.Where((p) => p.Category == category).ToListAsync();
            return produce;
        }
        
        public async Task<List<ProduceListing>> GetAvailable()
        {
            return await _db.ProduceListings.Where((p) => p.IsAvailable == true).ToListAsync();
        }

        public async Task UpdateAsync(ProduceListing updatedProduce)
        {
            var foundProduce = await _db.ProduceListings.FindAsync(updatedProduce.Id) ?? throw new ListingNotFoundException($"Produce listing with ID {updatedProduce.Id} not found.");
            _db.ProduceListings.Update(updatedProduce);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProduceListing produceToDelete)
        {
            var foundProduce = await _db.ProduceListings.FindAsync(produceToDelete.Id) ?? throw new ListingNotFoundException($"Produce listing with ID {produceToDelete.Id} not found.");
           _db.ProduceListings.Remove(produceToDelete);
           await _db.SaveChangesAsync();
        }
    }
}
