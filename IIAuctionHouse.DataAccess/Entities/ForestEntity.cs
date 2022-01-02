using System.Collections.Generic;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestEntity
    {
        public int Id { get; set; }
        
        public string ForestGroup { get; set; }
        
        public string ForestryEnterprise { get; set; }

        public double GeoLocationX { get; set; }

        public double GeoLocationY { get; set; }
      //   
      //   public int PlotEntityId { get; set; }
      //   public List<PlotEntity> PlotEntities { get; set; }
      //   
      // //  public int ForestUidId { get; set; }
      //  // public ForestUIdEntity ForestUidEntity { get; set; }
      //   
      //    public int BidEntityId { get; set; }
      //    public List<BidEntity> BidEntities { get; set; }

    }
}