using IIAuctionHouse.DataAccess.Entities.ForestEntities;

namespace IIAuctionHouse.DataAccess.Entities.ForestDetailEntities
{
    public class PercentageEntity
    {
        public int Id { get; set; }
        public int PlotTreePercentage { get; set; }
        
        public int TreeTypeForeignKey { get; set; }
        public TreeTypeEntity TreeTypeEntity { get; set; }
    }
}