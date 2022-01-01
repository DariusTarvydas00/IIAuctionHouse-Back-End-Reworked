using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class TreeTypeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Percentage { get; set; }
        
        //public int PlotForeignKey { get; set; }
        //public PlotEntity PlotEntity { get; set; }
    }
}