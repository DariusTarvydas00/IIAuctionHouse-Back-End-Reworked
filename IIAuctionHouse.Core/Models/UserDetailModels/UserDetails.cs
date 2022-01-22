namespace IIAuctionHouse.Core.Models.UserDetailModels
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}