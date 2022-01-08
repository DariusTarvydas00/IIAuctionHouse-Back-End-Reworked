using System;
using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int BidAmount { get; set; }
        public DateTime BidDateTime { get; set; }
    }
}