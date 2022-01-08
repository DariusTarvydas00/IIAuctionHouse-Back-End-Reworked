using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestryEnterpriseSql
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ForestSql> Forests { get; set; }
    }
}