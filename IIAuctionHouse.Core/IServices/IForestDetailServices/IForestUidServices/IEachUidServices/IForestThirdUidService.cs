using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices.IEachUidServices
{
    public interface IForestThirdUidService
    {
        List<ForestUidThird> GetAll();
        ForestUidThird NewThirdUid(int value);
        ForestUidThird Create(ForestUidThird forestUidThird);
        ForestUidThird Update(ForestUidThird forestUidThird);
        ForestUidThird Delete(int id);
        ForestUidThird UpdateThirdUid(int id, int value);
    }
}