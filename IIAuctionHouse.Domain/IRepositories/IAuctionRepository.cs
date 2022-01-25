using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IAuctionRepository
    {
        IEnumerable<Forest> FindAll();
    }
}