using Farmers_Market_API.Enums;

namespace Farmers_Market_API.Models
{
    public class Buyer: Person
    {
        public int Id { get; set; }
        public BuyerType BuyerType { get; set; }
        public string Location { get; set; } = string.Empty;

        public Buyer(int id, string fullName, string email, string phoneNumber, BuyerType buyerType, string location) : base(fullName, email, phoneNumber)
        {
            Id = id;
            BuyerType = buyerType;
            Location = location;
        }

        public Buyer() : base("", "", "") {}

        public override string GetContactInfo()
        {
            return base.GetContactInfo() + $", Location: {Location}, Buyer Type: {BuyerType}";
        }
    }
}
