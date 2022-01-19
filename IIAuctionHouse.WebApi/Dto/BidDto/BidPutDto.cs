using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Dto.ForestDto;
using IIAuctionHouse.WebApi.Dto.UserDto;

namespace IIAuctionHouse.WebApi.Dto.BidDto
{
    public class BidPutDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public UserIdDto UserPostIdDto { get; set; }
        public ForestIdDto ForestPostIdDto { get; set; }
    }
}