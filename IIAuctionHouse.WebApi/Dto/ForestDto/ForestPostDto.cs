using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestGroupDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestLocationDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestryEnterpriseDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Dto.UserDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDto
{
    public class ForestPostDto
    {
        public ForestryEnterpriseIdDto ForestryEnterprise { get; set; }
        public ForestGroupIdDto ForestGroup { get; set; }
        public ForestLocationPostDto ForestLocation { get; set; }
        public UserIdDto User { get; set; }
        public ForestUIdDto ForestUid { get; set; }
    }
}