namespace IIAuctionHouse.Core.Models.UserDetailModels
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int StreetOrHouseNumber { get; set; }
    }
}