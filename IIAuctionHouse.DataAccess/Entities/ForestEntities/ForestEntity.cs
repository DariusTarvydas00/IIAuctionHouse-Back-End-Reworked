namespace IIAuctionHouse.DataAccess.Entities.ForestEntities
{
    public class ForestEntity
    {
        public int Id { get; set; }
        public int? TreeGroupEntityForeignKey { get; set; }
        public TreeGroupEntity TreeGroupEntity { get; set; }
        public int? TreeTypeEntityForeignKey { get; set; }
        public TreeTypeEntity TreeTypeEntity { get; set; }
        public int? ForestLocationEntityForeignKey { get; set; }
        public ForestLocationEntity ForestLocationEntity { get; set; }

    }
}