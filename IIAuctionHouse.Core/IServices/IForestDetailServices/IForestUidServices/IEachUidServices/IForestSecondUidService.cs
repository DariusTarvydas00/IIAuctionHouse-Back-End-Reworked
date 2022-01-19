using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices.IEachUidServices
{
    public interface IForestSecondUidService
    {
        List<ForestUidSecond> GetAll();
        ForestUidSecond NewSecondUid(int value);
        ForestUidSecond Create(ForestUidSecond forestUidSecond);
        ForestUidSecond Update(ForestUidSecond forestUidSecond);
        ForestUidSecond Delete(int id);
        ForestUidSecond UpdateSecondUid(int id, int value);
    }
}