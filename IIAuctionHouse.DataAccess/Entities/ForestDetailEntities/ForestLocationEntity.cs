namespace IIAuctionHouse.DataAccess.Entities.ForestEntities
{
    public class ForestLocationEntity
    {
        public int Id { get; set; }
        public string ForestryEnterprise { get; set; }

        public int ForestForeignKey { get; set; }
        public ForestEntity ForestEntity { get; set; }
    }
}