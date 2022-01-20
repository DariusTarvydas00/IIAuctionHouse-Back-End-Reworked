using IIAuctionHouse.Core.Models.UserDetailModels;
using IIAuctionHouse.WebApi.Dto.UserDetailDto;

namespace IIAuctionHouse.WebApi.Dto.UserDto
{
    public class UserPostDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDetailPostDto UserDetailsPostDto { get; set; }
    }
}