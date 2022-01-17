using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestUid;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface IForestUidRepository
    {
        IEnumerable<ForestUid> GetAllForestUids();
        
         ForestUidFirst CreateForestUidFirst(int first);
         ForestUidSecond CreateForestUidSecond(int second);
         ForestUidThird CreateForestUidThird(int third);
    }
}