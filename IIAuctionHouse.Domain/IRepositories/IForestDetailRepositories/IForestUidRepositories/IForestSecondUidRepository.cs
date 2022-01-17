using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories
{
    public interface IForestSecondUidRepository
    {
        IEnumerable<ForestUidSecond> FindAll();
        ForestUidSecond Create(ForestUidSecond forestUidSecond);
        ForestUidSecond Update(ForestUidSecond forestUidSecond);
        ForestUidSecond Delete(int id);
    }
}