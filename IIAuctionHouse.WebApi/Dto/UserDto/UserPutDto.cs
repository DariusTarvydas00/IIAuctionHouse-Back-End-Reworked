using IIAuctionHouse.WebApi.Dto.UserDetailDto;

namespace IIAuctionHouse.WebApi.Dto.UserDto
{
    public class UserPutDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDetailPutDto UserDetailPutDto { get; set; }
    }
}