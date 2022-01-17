using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.ForestUidDto;
using IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDtos.TreeTypeDto;

namespace IIAuctionHouse.WebApi.Dto.ForestDetailDto.PlotDetailsDtos.PlotDto
{
    public class PlotPostDto
    {
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeTypePostDto> TreeTypePostDtos { get; set; }
        public ForestUidPostDto ForestUidDto { get; set; }
    }
}