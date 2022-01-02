using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IForestRepository
    {
        IEnumerable<Forest> FindAll();
        Forest GetById(int id);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
    }
}