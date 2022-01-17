using System.Collections.Generic;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestSql
    {
        public int Id { get; set; }
        public int ForestGroupSqlId { get; set; }
        public ForestGroupSql ForestGroupSql { get; set; }
        public int ForestryEnterpriseSqlId { get; set; }
         public ForestryEnterpriseSql ForestryEnterpriseSql { get; set; }
         public ForestLocationSql ForestLocationSql { get; set; }
         public int PlotSqlId { get; set; }
         public List<PlotSql> PlotSqls { get; set; }
         public ForestUidSql ForestUidSql { get; set; }
         public List<BidSql> BidSqls { get; set; }

    }
}