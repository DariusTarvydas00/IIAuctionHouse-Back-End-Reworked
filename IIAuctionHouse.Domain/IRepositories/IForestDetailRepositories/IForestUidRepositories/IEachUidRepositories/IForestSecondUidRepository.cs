using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories
{
    public interface IForestSecondUidRepository
    {
        IEnumerable<ForestUidSecond> FindAll();
        ForestUidSecond GetById(int id);
    }
}