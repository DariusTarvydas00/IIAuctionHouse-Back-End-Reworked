using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestUid;

namespace IIAuctionHouse.Domain.IRepositories.IForestUidRepositories
{
    public interface IForestThirdUidRepository
    {
        IEnumerable<ForestUidThird> FindAll();
        ForestUidThird Create(ForestUidThird forestUidThird);
        ForestUidThird Update(ForestUidThird forestUidThird);
        ForestUidThird Delete(int id);
    }
}