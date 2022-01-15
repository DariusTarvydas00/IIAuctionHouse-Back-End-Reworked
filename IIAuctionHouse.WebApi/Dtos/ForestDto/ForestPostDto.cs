using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.WebApi.Dtos.ForestDto
{
    public class ForestPostDto
    {
         public ForestryEnterprise ForestryEnterprise { get; set; }

        public ForestLocation ForestLocation { get; set; }
        public ForestGroup ForestGroup { get; set; }
         public List<Plot> Plots { get; set; }

         public List<Bid> Bids { get; set; }
        public ForestUid ForestUid { get; set; }
    }
}