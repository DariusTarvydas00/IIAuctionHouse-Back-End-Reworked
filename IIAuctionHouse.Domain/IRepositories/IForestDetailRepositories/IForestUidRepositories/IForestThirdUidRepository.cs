using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories
{
    public interface IForestThirdUidRepository
    {
        IEnumerable<ForestUidThird> FindAll();
        ForestUidThird Create(ForestUidThird forestUidThird);
        ForestUidThird Update(ForestUidThird forestUidThird);
        ForestUidThird Delete(int id);
    }
}