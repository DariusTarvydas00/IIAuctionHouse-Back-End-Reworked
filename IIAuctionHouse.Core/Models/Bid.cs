using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Forest Forest { get; set; }
    }
}