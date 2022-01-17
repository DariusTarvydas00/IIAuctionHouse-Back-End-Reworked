using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestUid;

namespace IIAuctionHouse.Domain.IRepositories.IForestUidRepositories
{
    public interface IForestSecondUidRepository
    {
        IEnumerable<ForestUidSecond> FindAll();
        ForestUidSecond Create(ForestUidSecond forestUidSecond);
        ForestUidSecond Update(ForestUidSecond forestUidSecond);
        ForestUidSecond Delete(int id);
    }
}