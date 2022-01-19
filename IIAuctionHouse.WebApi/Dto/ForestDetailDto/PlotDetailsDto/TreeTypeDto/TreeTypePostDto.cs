using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto.ForestUidFirstDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto.ForestUidSecondDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto.TreeTypeDto
{
    public class TreeTypePostDto
    {
        public ForestUidFirstIdDto TreeTypeIdDto { get; set; }
        public ForestUidSecondIdDto PercentageIdDto { get; set; }
    }
}