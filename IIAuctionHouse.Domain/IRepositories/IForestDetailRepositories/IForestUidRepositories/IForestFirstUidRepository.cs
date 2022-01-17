using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories
{
    public interface IForestFirstUidRepository
    {
        IEnumerable<ForestUidFirst> FindAll();
        ForestUidFirst Create(ForestUidFirst value);
        ForestUidFirst Update(ForestUidFirst forestUidFirst);
        ForestUidFirst Delete(int id);
    }
}