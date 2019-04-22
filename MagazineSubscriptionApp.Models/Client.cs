namespace MagazineSubscriptionApp.Models
{
    public class Client : User
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}