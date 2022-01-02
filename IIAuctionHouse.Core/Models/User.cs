using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public List<ForestUid> ForestUIds { get; set; }
        public List<Bid> Bids { get; set; }
    }
}