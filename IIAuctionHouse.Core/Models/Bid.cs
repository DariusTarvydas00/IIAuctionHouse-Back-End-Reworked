using System;

namespace IIAuctionHouse.Core.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int BidAmount { get; set; }
        public DateTime BidDateTime { get; set; }

        public User User { get; set; }

        public Forest Forest { get; set; }
    }
}