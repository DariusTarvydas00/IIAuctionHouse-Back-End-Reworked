using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories
{
    public interface IForestSecondUidRepository
    {
        IEnumerable<ForestUidSecond> FindAll();
        ForestUidSecond GetById(int id);
        ForestUidSecond Create(ForestUidSecond forestUidSecond);
        ForestUidSecond Update(ForestUidSecond forestUidSecond);
        ForestUidSecond Delete(int id);
    }
}