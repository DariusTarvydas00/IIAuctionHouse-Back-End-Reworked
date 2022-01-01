using System.Collections.Generic;

namespace IIAuctionHouse.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public List<ForestUid> ForestUids { get; set; }
        private List<Bid> Bids { get; set; }
    }
}