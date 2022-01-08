namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestUidSql
    {
        public int Id { get; set; }
        public int FirstUid { get; set; }
        public int SecondUid { get; set; }
        public int ThirdUid { get; set; }

        public int? UserSqlId { get; set; }
        public UserSql UserSql { get; set; }
    }
}