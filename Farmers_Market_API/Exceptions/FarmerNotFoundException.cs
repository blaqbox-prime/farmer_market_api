namespace Farmers_Market_API.Exceptions
{
    public class FarmerNotFoundException : Exception
    {
        public FarmerNotFoundException(int farmerId)
            : base($"Farmer with ID {farmerId} not found.")
        {
        }

        public FarmerNotFoundException(string email)
            : base($"Farmer with email {email} not found.")
        {
        }
    }
}
