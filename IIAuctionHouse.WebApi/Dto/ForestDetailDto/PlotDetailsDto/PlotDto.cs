using System.Collections.Generic;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto.TreeTypesDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDto
{
    public class PlotDto
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeTypeDto> TreeTypes { get; set; }
        public ForestUIdDto ForestUid { get; set; }
    }
}