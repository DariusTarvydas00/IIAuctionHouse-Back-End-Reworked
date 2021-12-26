using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Domain.IRepositories.IForestRepositories
{
    public interface IForestLocationRepo
    {
        IEnumerable<ForestLocation> FindAll();
        ForestLocation GetById(int id);
        ForestLocation Create(string forestryEnterprise);
        ForestLocation Update(ForestLocation forestLocation);
        ForestLocation Delete(int id);
    }
}