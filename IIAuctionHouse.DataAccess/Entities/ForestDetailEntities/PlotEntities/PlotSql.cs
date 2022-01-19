using System.Collections.Generic;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;

namespace IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities
{
    public class PlotSql
    {
        public int Id { get; set; }
        public double PlotSize { get; set; }
        public string PlotResolution { get; set; }
        public double PlotTenderness { get; set; }
        public int Volume { get; set; }
        public int AverageTreeHeight { get; set; }
        public List<TreeTypeSql> TreeTypeSql { get; set; }
        public ForestUidSql ForestUidSql { get; set; }
    }
}