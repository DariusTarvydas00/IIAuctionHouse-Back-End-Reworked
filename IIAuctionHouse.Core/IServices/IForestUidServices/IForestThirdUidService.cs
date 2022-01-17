using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestUid;

namespace IIAuctionHouse.Core.IServices.IForestUidServices
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