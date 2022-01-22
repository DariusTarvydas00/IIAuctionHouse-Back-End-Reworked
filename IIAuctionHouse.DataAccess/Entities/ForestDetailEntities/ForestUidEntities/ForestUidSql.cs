using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities.EachUidEntities;

namespace IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities
{
    public class ForestUidSql
    {
        public int Id { get; set; }
        public int? ForestUidFirstSqlId { get; set; }
        public ForestUidFirstSql ForestUidFirstSql { get; set; }
        public int? ForestUidSecondSqlId { get; set; }
        public ForestUidSecondSql ForestUidSecondSql { get; set; }
        public int? ForestUidThirdSqlId { get; set; }
        public ForestUidThirdSql ForestUidThirdSql { get; set; }

    }
}