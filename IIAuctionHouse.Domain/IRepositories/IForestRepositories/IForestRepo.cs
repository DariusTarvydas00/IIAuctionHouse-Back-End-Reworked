using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Domain.IRepositories.IForestRepositories
{
    public interface IForestRepo
    {
        IEnumerable<Forest> FindAll();
        Forest GetById(int id);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
    }
}