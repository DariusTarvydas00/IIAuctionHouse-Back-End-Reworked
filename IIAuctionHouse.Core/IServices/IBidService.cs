using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IBidService
    {
        List<Bid> GetAll();
        Bid GetById(int id);
        Bid Create(Bid bid);
        Bid Update(Bid bid);
        Bid Delete(int id);
        Bid UpdateBid(int id, int bidAmount, User user, Forest forest);
        Bid NewBid(int bidAmount, int bidBidAmount, int bidForestId, int bidUserId);
    }
}