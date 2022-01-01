using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class Plot
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public int PlotResolutionFirstValue { get; set; }
        public int PlotResolutionSecondValue { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeType> TreeTypes { get; set; }
    }
}