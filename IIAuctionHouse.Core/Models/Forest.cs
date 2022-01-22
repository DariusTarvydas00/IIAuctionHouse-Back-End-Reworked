using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Core.Models
{
    public class Forest
    {
        public int Id { get; set; }
        public ForestLocation ForestLocation { get; set; }
        public ForestGroupSubGroup ForestGroupSubGroup { get; set; }
        public ForestryEnterprise ForestryEnterprise { get; set; }
        public ForestUid ForestUid { get; set; }
        public List<Plot> Plots { get; set; }
        public List<Bid> Bids { get; set; }
    }
}