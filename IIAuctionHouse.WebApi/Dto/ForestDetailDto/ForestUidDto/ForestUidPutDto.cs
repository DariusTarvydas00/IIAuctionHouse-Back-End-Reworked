using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto.ForestUidFirstDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto.ForestUidSecondDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto.ForestUidThirdDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto
{
    public class ForestUidPutDto
    {
        public int Id { get; set; }
        public ForestUidFirstIdDto ForestFirstUidDto { get; set; }
        public PercentageDto ForestSecondUidDto { get; set; }
        public ForestUidThirdIdDto ForestThirdUidDto { get; set; }
    }
}