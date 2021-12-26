namespace IIAuctionHouse.DataAccess.Entities.ForestEntities
{
    public class TreeTypeEntity
    {
        public int Id { get; set; }
        public string TypeOfTree { get; set; }
        
        public int ForestForeignKey { get; set; }
        public ForestEntity ForestEntity { get; set; }
    }
}