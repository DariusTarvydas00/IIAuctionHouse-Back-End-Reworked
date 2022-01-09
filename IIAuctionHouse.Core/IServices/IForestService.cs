using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IForestService
    {
        List<Forest> GetAll();
        Forest GetById(int id);
        Forest NewForest(ForestUid forestUid, string forestGroup, ForestLocation forestLocation, 
            List<Plot> plots, List<Bid> forestBids, ForestryEnterprise forestryEnterprise);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
        Forest UpdateForest(int id, ForestUid forestForestUid, string forestForestGroup, ForestLocation forestForestLocation, 
            List<Plot> plots, List<Bid> forestBids, ForestryEnterprise forestryEnterprise);
    }
}