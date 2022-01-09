using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class UserSql
    {
        public int Id { get; set; }
        public List<ForestUidSql> ForestUidEntities { get; set; }
        public List<BidSql> BidEntities { get; set; }
    }
}