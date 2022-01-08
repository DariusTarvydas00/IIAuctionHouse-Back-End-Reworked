namespace IIAuctionHouse.DataAccess.Entities
{
    public class BidSql
    {
        public int Id { get; set; }
        public int ForestSqlId { get; set; }
        public ForestSql ForestSql { get; set; }

        public int UserSqlId { get; set; }
        public UserSql UserSql { get; set; }
    }
}