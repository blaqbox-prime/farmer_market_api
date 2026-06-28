using Farmers_Market_API.Enums;
using Farmers_Market_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Farmers_Market_API.Data;

public class AppDbContext(DbContextOptions options): DbContext(options)
{
    public DbSet<ProduceListing> ProduceListings {get; set;}
    public DbSet<Buyer> Buyers {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<Farmer> Farmers {get; set;}
}
