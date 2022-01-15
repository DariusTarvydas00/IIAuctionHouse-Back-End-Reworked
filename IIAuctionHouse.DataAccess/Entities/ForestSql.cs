using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestSql
    {
        public int Id { get; set; }
        public ForestGroupSql ForestGroupSql { get; set; }

        public int ForestryEnterpriseSqlId { get; set; }
         public ForestryEnterpriseSql ForestryEnterpriseSql { get; set; }
         public ForestLocationSql ForestLocationSql { get; set; }
         public List<PlotSql> PlotSqls { get; set; }
         public ForestUidSql ForestUidSql { get; set; }
         public List<BidSql> BidSqls { get; set; }

    }
}