using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;

namespace IIAuctionHouse.WebApi.Dto.PlotDtos
{
    public class PlotDto
    {
        public int Id { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public double PlotSize { get; set; }
        public double PlotTenderness { get; set; }
        public string PlotResolution { get; set; }
        public List<TreeType> TreeTypes { get; set; }
        public int ForestId { get; set; }
    }
}