using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class PlotEntity
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public int PlotResolutionFirstValue { get; set; }
        public int PlotResolutionSecondValue { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        
        public int TreeTypeForeignKey { get; set; }
        public List<TreeType> TreeTypeEntities { get; set; }
        
        public int ForestForeignKey { get; set; }
        public ForestEntity ForestEntity { get; set; }
    }
}