using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories
{
    public interface IForestFirstUidRepository
    {
        IEnumerable<ForestUidFirst> FindAll();
        ForestUidFirst GetById(int id);
    }
}