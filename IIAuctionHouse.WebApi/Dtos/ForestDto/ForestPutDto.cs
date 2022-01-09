using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.WebApi.Dtos.ForestDto
{
    public class ForestPutDto
    {
        public int Id { get; set; }

         public ForestryEnterprise ForestryEnterprise { get; set; }
         public ForestLocation ForestLocation { get; set; }
         public string ForestGroup { get; set; }
         public List<Plot> Plots { get; set; }
         public List<Bid> Bids { get; set; }
         public ForestUid ForestUid { get; set; }
    }
}