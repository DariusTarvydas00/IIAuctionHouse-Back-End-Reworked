using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories
{
    public interface IForestUidRepository
    {
        IEnumerable<ForestUid> GetAllForestUids();
        
         ForestUidFirst CreateForestUidFirst(int first);
         ForestUidSecond CreateForestUidSecond(int second);
         ForestUidThird CreateForestUidThird(int third);
    }
}