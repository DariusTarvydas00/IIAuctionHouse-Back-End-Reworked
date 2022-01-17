using System.Collections.Generic;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestUid;

namespace IIAuctionHouse.Core.IServices
{
    public interface IForestService
    {
        List<Forest> GetAll();
        Forest GetById(int id);
        Forest NewForest(ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, ForestryEnterprise forestryEnterprise, List<Plot> plots);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
        Forest UpdateForest(int id, ForestUid forestForestUid, ForestGroup forestForestGroup, ForestLocation forestForestLocation, ForestryEnterprise forestryEnterprise, List<Plot> plots);
    }
}