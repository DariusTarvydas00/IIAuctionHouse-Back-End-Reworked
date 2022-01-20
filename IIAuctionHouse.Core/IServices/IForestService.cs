using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;

namespace IIAuctionHouse.Core.IServices
{
    public interface IForestService
    {
        List<Forest> GetAll();
        Forest GetById(int id);
        Forest NewForest(ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, ForestryEnterprise forestryEnterprise, User user);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
        Forest UpdateForest(int id, ForestUid forestForestUid, ForestGroup forestForestGroup, ForestLocation forestForestLocation, ForestryEnterprise forestryEnterprise, User user);
        Forest NewForestCheck(int id);
    }
}