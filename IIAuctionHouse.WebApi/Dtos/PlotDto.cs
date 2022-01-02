using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.WebApi.Dtos
{
    public class PlotDto
    {
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeType> TreeTypes { get; set; }
    }
}