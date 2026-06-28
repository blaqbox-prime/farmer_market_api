using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmers_Market_API.Models
{
    public class Farmer: Person
    {
        static int _idCounter = 1;

        public int FarmerId { get; set; }

        public string Location { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public double Rating { get; set; } = 0.0;
        public bool IsVerified { get; set; } = false;

        public string FarmName { get; set; } = string.Empty;

        public Farmer(int farmerId, string fullName, string email, string phoneNumber, string location, string province, double rating, bool isVerified, string farmName) : base(fullName, email, phoneNumber)
        {
            FarmerId = farmerId;
            Location = location;
            Province = province;
            Rating = rating;
            IsVerified = isVerified;
            FarmName = farmName;
        }

        public Farmer():base("", "", ""){}

        public int GetFarmerId()
        {
            return FarmerId;
        }

        public override string GetContactInfo()
        {
            return base.GetContactInfo() + $", Location: {Location}, Farm: {FarmName}";
        }
    }
}