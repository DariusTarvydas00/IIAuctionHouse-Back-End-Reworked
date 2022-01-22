using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid
{
    public interface IForestSecondUidService
    {
        List<ForestUidSecond> GetAll();
        ForestUidSecond GetById(int secondUid);
    }
}