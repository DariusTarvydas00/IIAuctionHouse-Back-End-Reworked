namespace IIAuctionHouse.WebApi.Dto.UserDetailDto
{
    public class UserDetailPutDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public AddressPutDto AddressPutDto { get; set; }
    }
}