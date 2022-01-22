using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;

namespace IIAuctionHouse.Core.IServices
{
    public interface IForestService
    {
        List<Forest> GetAll();
        Forest GetById(int id);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
        Forest NewForest(int id, ForestGroupSubGroup forestGroupSubGroup, ForestLocation forestLocation, ForestUid forestUid, ForestryEnterprise forestryEnterprise);
    }
}