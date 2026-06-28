namespace Farmers_Market_API.Exceptions
{
    public class OrderNotFoundException: Exception
    {
        public OrderNotFoundException(int id) : base($"Order with ID {id} not found.")
        {

        }
    }
}
