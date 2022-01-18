using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestryEnterpriseDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Dto.UserDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDto
{
    public class ForestPutDto
    {
        public int Id { get; set; }
        public OnlyIdDto ForestryEnterpriseIdDto { get; set; }
        public ForestLocation ForestLocation { get; set; }
        public ForestGroup ForestGroup { get; set; }
        public ForestUid ForestUid { get; set; }
        public OnlyIdDto UserIdDto { get; set; }
        public OnlyIdDto ForestUidIdDto { get; set; }
    }
}