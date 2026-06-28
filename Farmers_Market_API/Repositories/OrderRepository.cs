using Farmers_Market_API.Interfaces;
using Farmers_Market_API.Models;
using Farmers_Market_API.Exceptions;
using Farmers_Market_API.Data;
using System.Data.Entity;

namespace Farmers_Market_API.Repositories
{
    public class OrderRepository(AppDbContext db) : IRepository<Order>
    {

        private readonly AppDbContext _db = db; 

        public async Task AddAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            var foundOrder = await _db.Orders.FindAsync(order.Id) ?? throw new OrderNotFoundException(order.Id);
            _db.Orders.Remove(foundOrder);
            await _db.SaveChangesAsync();

        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
        
            return await _db.Orders.FindAsync(id) ?? throw new OrderNotFoundException(id);
        }

        public async Task UpdateAsync(Order order)
        {
            var foundOrder = await _db.Orders.FindAsync(order.Id) ?? throw new OrderNotFoundException(order.Id);
            _db.Orders.Update(order);
        }
    }
}
