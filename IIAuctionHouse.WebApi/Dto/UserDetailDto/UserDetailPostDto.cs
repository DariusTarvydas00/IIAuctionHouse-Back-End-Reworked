namespace IIAuctionHouse.WebApi.Dto.UserDetailDto
{
    public class UserDetailPostDto
    {
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public AddressPostDto AddressPostDto { get; set; }
    }
}