namespace Farmers_Market_API.Models
{
    public class Person(string fullName, string email, string phoneNumber)
    {
        public string FullName { get; set; } = fullName;
        public string Email { get; set; } = email;
        public string PhoneNumber { get; set; } = phoneNumber;
        
        public virtual string GetContactInfo()
        {
            return $"Email: {Email}, Phone: {PhoneNumber}";
        }
    }
}
