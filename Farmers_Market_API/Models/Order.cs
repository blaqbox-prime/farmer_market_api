using Farmers_Market_API.Enums;

namespace Farmers_Market_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ListingId { get; set; }
        public double QuantityOrdered { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime? CollectionDate { get; set; }
        public string? Notes { get; set; } = string.Empty;

        private ProduceListing _product;

        public Order() { }
        public Order(int id, int buyerId, ProduceListing product, double quantityOrdered, OrderStatus status, DateTime? collectionDate = null, string? notes = null)
        {
            Id = id;
            BuyerId = buyerId;
            ListingId = product.ListingId;
            QuantityOrdered = quantityOrdered;
            TotalPrice = _calculateTotalPrice(quantityOrdered, product.PricePerKg);
            Status = status;
            CollectionDate = collectionDate;
            _product = product;
            Notes = notes ?? string.Empty;
        }

        private double _calculateTotalPrice(double quantityOrdered, double pricePerKg) 
        {
            return quantityOrdered * pricePerKg;
        }
    }
}
