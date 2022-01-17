using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class Forest
    {
        public int Id { get; set; }

        public ForestryEnterprise ForestryEnterprise { get; set; }

        public ForestLocation ForestLocation { get; set; }
        public ForestGroup ForestGroup { get; set; }
        public List<Plot> Plots { get; set; }

        public List<Bid> Bids { get; set; }
        public ForestUid.ForestUid ForestUid { get; set; }
    }
}