namespace IIAuctionHouse.DataAccess.Entities.ForestEntities
{
    public class TreeGroupEntity
    {
        public int Id { get; set; }
        public string GroupOfTree { get; set; }
        
        public int ForestForeignKey { get; set; }
        public ForestEntity ForestEntity { get; set; }
    }
}