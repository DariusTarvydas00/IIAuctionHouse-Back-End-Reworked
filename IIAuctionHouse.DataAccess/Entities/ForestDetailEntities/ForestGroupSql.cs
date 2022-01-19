using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities.ForestDetailEntities
{
    public class ForestGroupSql
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ForestSql> ForestSqls { get; set; }
    }
}