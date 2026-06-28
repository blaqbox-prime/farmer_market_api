using Farmers_Market_API.Enums;

namespace Farmers_Market_API.DTOs
{
    public struct CreateProduceDTO
    {
        public int FarmerId { get; set; }
        public string ProduceName { get; set; }
        public Category Category { get; set; }
        public double PricePerKg { get; set; }
        public double QuantityKg { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime HarvestDate { get; set; }
        public DateTime DateListed { get; set; }
        public string? Description { get; set; } = null;
        public CreateProduceDTO() { }

        public CreateProduceDTO(int farmerId, string produceName, Category category, double pricePerKg, double quantityKg, bool isAvailable, DateTime harvestDate, DateTime dateListed, string? description)
        {
            FarmerId = farmerId;
            ProduceName = produceName;
            Category = category;
            PricePerKg = pricePerKg;
            QuantityKg = quantityKg;
            IsAvailable = isAvailable;
            HarvestDate = harvestDate;
            DateListed = dateListed;
            Description = description;
        }
    }
}
