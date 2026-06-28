using Farmers_Market_API.Enums;

namespace Farmers_Market_API.Structs
{
    public struct FarmerLocation
    {
        public string FarmName;
        public Province Province;
        public string Town;

        public FarmerLocation(string farmName, Province province, string town)
            {
                FarmName = farmName;
                Province = province;
                Town = town;
            }
    }
}
