using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels
{
    public class Plot
    {
        public int Id { get; set; }

        public ForestUid ForestUid { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeType> TreeTypes { get; set; }
    }
}