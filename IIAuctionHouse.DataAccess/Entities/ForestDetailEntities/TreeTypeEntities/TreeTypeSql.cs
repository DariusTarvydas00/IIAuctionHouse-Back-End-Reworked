using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities.TTEntities;

namespace IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities
{
    public class TreeTypeSql
    {
        public int Id { get; set; }
        public int? TreeSqlId { get; set; }
        public TreeSql TreeSql { get; set; }
        public int? PercentageSqlId { get; set; }
        public PercentageSql PercentageSql { get; set; }

    }
}