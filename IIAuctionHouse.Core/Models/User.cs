using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.UserDetailModels;

namespace IIAuctionHouse.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserDetails UserDetails { get; set; }
        public List<ForestUid> ForestUIds { get; set; }
        public List<Bid> Bids { get; set; }
    }
}