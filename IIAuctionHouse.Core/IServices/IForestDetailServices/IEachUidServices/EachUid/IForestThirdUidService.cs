using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices.EachUid
{
    public interface IForestThirdUidService
    {
        List<ForestUidThird> GetAll();
        ForestUidThird GetById(int thirdUid);
    }
}