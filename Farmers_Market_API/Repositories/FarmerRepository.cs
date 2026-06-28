using System.Data.Entity;
using Farmers_Market_API.Data;
using Farmers_Market_API.Exceptions;
using Farmers_Market_API.Interfaces;
using Farmers_Market_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Farmers_Market_API.Repositories
{
    public class FarmerRepository(AppDbContext db): IRepository<Farmer>
    {
        private readonly AppDbContext _db = db;

        public async Task<List<Farmer>> GetAllAsync()
        {
            return await _db.Farmers.ToListAsync();
        }

        public async Task AddAsync(Farmer farmer)
        {
            await _db.Farmers.AddAsync(farmer);
            
        }

        public async Task<Farmer?> GetByIdAsync(int Id)
        {
            
            return await _db.Farmers.FindAsync(Id) ?? throw new FarmerNotFoundException(Id);
        }

        public async Task<Farmer> GetByEmailAsync(string email)
        {
            
            return await _db.Farmers.FirstAsync((farmer) => farmer.Email == email) ?? throw new FarmerNotFoundException(email);
        }

        public async Task UpdateAsync(Farmer updatedFarmer)
        {
            var found = await  _db.Farmers.FindAsync(updatedFarmer.FarmerId) ?? throw new FarmerNotFoundException(updatedFarmer.FarmerId);
           _db.Farmers.Update(updatedFarmer);
           await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var found = await _db.Farmers.FindAsync(Id) ?? throw new FarmerNotFoundException(Id);
            _db.Farmers.Remove(found);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Farmer farmerToDelete)
        {
            var found = await _db.Farmers.FindAsync(farmerToDelete.FarmerId) ?? throw new FarmerNotFoundException(farmerToDelete.FarmerId);
            _db.Farmers.Remove(found);
            await _db.SaveChangesAsync();
            
        }
    }

}
