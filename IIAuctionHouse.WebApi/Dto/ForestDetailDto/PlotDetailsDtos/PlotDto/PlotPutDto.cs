using System.Collections.Generic;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDtos.TreeTypeDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDtos.PlotDto
{
    public class PlotPutDto
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeTypePutDto> TreeTypeDtos { get; set; }
        public ForestUidPutDto ForestUidDto { get; set; }
    }
}