using System.Collections.Generic;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;

namespace IIAuctionHouse.DataAccess.Entities
{
    public class ForestEntity
    {
        public int Id { get; set; }
        
        public string ForestGroup { get; set; }
        
        public string ForestryEnterprise { get; set; }

        public double GeoLocationX { get; set; }

        public double GeoLocationY { get; set; }
        
        // public int ForestUidForeignKey { get; set; }
        // public ForestUidEntity ForestUidEntity { get; set; }
        
        public int PlotForeignKey { get; set; }
        public List<PlotEntity> PlotEntities { get; set; }
        
        //public int ForestUidForeignKey { get; set; }
        //public ForestUidEntity ForestUidEntity { get; set; }
        // public int BidForeignKey { get; set; }
        // public List<BidEntity> BidEntities { get; set; }

    }
}