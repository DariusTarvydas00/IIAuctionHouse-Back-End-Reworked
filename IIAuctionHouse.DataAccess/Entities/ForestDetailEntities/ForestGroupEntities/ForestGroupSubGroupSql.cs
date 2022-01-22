using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestGroupEntities.GroupEntities;

namespace IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestGroupEntities
{
    public class ForestGroupSubGroupSql
    {
        public int Id { get; set; }
        public int? GroupSqlId { get; set; }
        public GroupSql GroupSql { get; set; }
        public int? SubGroupSqlId { get; set; }
        public SubGroupSql SubGroupSql { get; set; }
    }
}