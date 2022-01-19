using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;

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
        public ForestUid ForestUid { get; set; }

        public User User { get; set; }
    }
}