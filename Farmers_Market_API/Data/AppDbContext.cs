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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProduceListing>()
            .HasOne<Farmer>()
            .WithMany()
            .HasForeignKey(p => p.FarmerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne<Buyer>()
            .WithMany()
            .HasForeignKey(o => o.BuyerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne<Farmer>()
            .WithMany()
            .HasForeignKey(o => o.FarmerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Order>()
            .HasOne<ProduceListing>()
            .WithMany()
            .HasForeignKey(o => o.ListingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
