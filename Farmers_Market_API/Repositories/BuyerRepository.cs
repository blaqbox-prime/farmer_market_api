using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Farmers_Market_API.Data;
using Farmers_Market_API.Interfaces;
using Farmers_Market_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmers_Market_API.Repositories
{
    public class BuyerRepository(AppDbContext db) : IRepository<Buyer>
    {
        private readonly AppDbContext _db = db;

        public async Task AddAsync(Buyer entity)
        {
            await _db.Buyers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Buyer entity)
        {
            var existingBuyer = await _db.Buyers.FindAsync(entity.Id)
                ?? throw new InvalidOperationException($"Buyer with ID {entity.Id} was not found.");

            _db.Buyers.Remove(existingBuyer);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Buyer>> GetAllAsync()
        {
            return await _db.Buyers.ToListAsync();
        }

        public async Task<Buyer?> GetByIdAsync(int id)
        {
            return await _db.Buyers.FindAsync(id);
        }

        public async Task UpdateAsync(Buyer entity)
        {
            var existingBuyer = await _db.Buyers.FindAsync(entity.Id)
                ?? throw new InvalidOperationException($"Buyer with ID {entity.Id} was not found.");

            _db.Entry(existingBuyer).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
        }
    }
}