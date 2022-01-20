using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IBidRepository
    {
        IEnumerable<Bid> FindAll();
        Bid GetById(int id);
        Bid Create(Bid bid);
        Bid Update(Bid bid);
        Bid Delete(int id);
    }
}