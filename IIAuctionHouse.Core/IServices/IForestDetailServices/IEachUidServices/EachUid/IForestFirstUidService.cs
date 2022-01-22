using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid
{
    public interface IForestFirstUidService
    {
        List<ForestUidFirst> GetAll();
        ForestUidFirst GetById(int firstUid);
    }
}