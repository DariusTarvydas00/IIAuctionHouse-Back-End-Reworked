using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class Forest
    {
        public int Id { get; set; }
        public ForestUid ForestUid { get; set; }
        
        public string ForestGroup { get; set; }
        
        public string ForestryEnterprise { get; set; }

        public double GeoLocationX { get; set; }

        public double GeoLocationY { get; set; }
        
        public List<Plot> Plots { get; set; }

        public List<Bid> Bids { get; set; }
    }
}