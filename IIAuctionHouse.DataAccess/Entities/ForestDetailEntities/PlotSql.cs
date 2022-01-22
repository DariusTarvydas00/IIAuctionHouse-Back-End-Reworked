using System.Collections.Generic;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities;

namespace IIAuctionHouse.DataAccess.Entities.ForestDetailEntities
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
        public int? ForestSqlId { get; set; }
    }
}