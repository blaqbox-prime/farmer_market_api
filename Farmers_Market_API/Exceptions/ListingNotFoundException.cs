namespace Farmers_Market_API.Exceptions
{
    public class ListingNotFoundException : Exception
    {
        public ListingNotFoundException()
        {
        }

        public ListingNotFoundException(string? message) : base(message)
        {
        }
    }
}
