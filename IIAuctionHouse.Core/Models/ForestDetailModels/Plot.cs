using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;

namespace IIAuctionHouse.Core.Models.ForestDetailModels
{
    public class Plot
    {
        public int Id { get; set; }
        public Forest Forest { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public double PlotSize { get; set; }
        public double PlotTenderness { get; set; }
        public string PlotResolution { get; set; }
        public List<TreeType> TreeTypes { get; set; }
    }
}