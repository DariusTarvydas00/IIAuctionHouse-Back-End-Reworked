using IIAuctionHouse.WebApi.Dtos.PercentageDto;
using IIAuctionHouse.WebApi.Dtos.TreeDto;

namespace IIAuctionHouse.WebApi.Dtos.TreeTypeDto
{
    public class TreeTypePostDto
    {
        public int Id { get; set; }
        public TreeIdDto TreeIdDto { get; set; }
        public PercentageIdDto PercentageIdDto { get; set; }
    }
}