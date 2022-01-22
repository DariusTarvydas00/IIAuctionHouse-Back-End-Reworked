using System.Collections.Generic;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities.EachUidEntities;
using IIAuctionHouse.DataAccess.Entities.UserDetailsEntities;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class UserSql
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDetailSql UserDetailSql { get; set; }
        public List<ForestUidSql> ForestUIdSqls { get; set; }
        public List<BidSql> BidSqls { get; set; }
    }
}