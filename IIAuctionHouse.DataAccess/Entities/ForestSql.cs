using System.Collections.Generic;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestGroupEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestSql
    {
        public int Id { get; set; }
        public ForestGroupSubGroupSql ForestGroupSubGroupSql { get; set; }
        public int? ForestryEnterpriseSqlId { get; set; }
        public ForestryEnterpriseSql ForestryEnterpriseSql { get; set; }
        public ForestLocationSql ForestLocationSql { get; set; }
         public List<PlotSql> PlotSqls { get; set; }
         public ForestUidSql ForestUidSql { get; set; }
         //public List<BidSql> BidSqls { get; set; }

    }
}