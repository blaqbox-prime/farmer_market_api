namespace Farmers_Market_API.Exceptions
{
    public class InvalidProduceFormatException: Exception
    {
        public InvalidProduceFormatException()
        {
        }
        public InvalidProduceFormatException(string? message) : base(message)
        {
        }
    }
}
