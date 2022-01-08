using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.WebApi.Dtos.PlotDto
{
    public class PlotPutDto
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeType> TreeTypeDto { get; set; }
    }
}