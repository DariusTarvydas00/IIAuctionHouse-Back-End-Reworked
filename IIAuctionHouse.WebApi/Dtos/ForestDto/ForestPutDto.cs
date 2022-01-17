﻿using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestUid;

namespace IIAuctionHouse.WebApi.Dtos.ForestDto
{
    public class ForestPutDto
    {
        public int Id { get; set; }

         public ForestryEnterprise ForestryEnterprise { get; set; }
         public ForestLocation ForestLocation { get; set; }
         public ForestGroup ForestGroup { get; set; }
         public List<Plot> Plots { get; set; }
         public List<Bid> Bids { get; set; }
         public ForestUid ForestUid { get; set; }
    }
}