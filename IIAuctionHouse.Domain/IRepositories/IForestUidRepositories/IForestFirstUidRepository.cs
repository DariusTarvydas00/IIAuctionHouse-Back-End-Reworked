using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestUid;

namespace IIAuctionHouse.Domain.IRepositories.IForestUidRepositories
{
    public interface IForestFirstUidRepository
    {
        IEnumerable<ForestUidFirst> FindAll();
        ForestUidFirst Create(ForestUidFirst value);
        ForestUidFirst Update(ForestUidFirst forestUidFirst);
        ForestUidFirst Delete(int id);
    }
}