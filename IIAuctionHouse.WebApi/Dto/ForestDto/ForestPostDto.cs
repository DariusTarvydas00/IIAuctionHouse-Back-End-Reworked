using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestLocationDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDto
{
    public class ForestPostDto
    {
        public ForestryEnterprise ForestryEnterprise { get; set; }
        public ForestGroup ForestGroup { get; set; }
        public ForestLocationPostDto ForestLocationPostDto { get; set; }
        public OnlyIdDto UserIdDto { get; set; }
        public ForestUidPostDto ForestUidIdDto { get; set; }
    }
}