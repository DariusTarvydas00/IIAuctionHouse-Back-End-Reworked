using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IForestService
    {
        List<Forest> GetAll();
        Forest GetById(int id);
        Forest NewForest(ForestUid forestUid, string forestGroup, string forestryEnterprise, 
            double geoLocationX, double geoLocationY, List<Plot> plots, List<Bid> bids);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
    }
}