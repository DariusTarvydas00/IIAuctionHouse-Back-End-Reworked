using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestUidServices.IEachUidServices
{
    public interface IForestFirstUidService
    {
        List<ForestUidFirst> GetAll();
        ForestUidFirst NewFirstUid(int value);
        ForestUidFirst Create(ForestUidFirst forestUidFirst);
        ForestUidFirst Update(ForestUidFirst forestUidFirst);
        ForestUidFirst Delete(int id);
        ForestUidFirst UpdateFirstUid(int id, int value);
    }
}