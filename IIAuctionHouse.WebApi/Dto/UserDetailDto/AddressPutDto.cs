namespace IIAuctionHouse.WebApi.Dto.UserDetailDto
{
    public class AddressPutDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int StreetOrHouseNumber { get; set; }
    }
}