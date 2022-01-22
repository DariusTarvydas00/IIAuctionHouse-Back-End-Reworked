using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices
{
    public interface IForestUidService
    {
        ForestUid GetForestUid(int firstUid, int secondUid, int thirdUid);
        List<ForestUidFirst> GetAllFirstUids();
        List<ForestUidSecond> GetAllSecondUids();
        List<ForestUidThird> GetAllThirdUids();
    }
}