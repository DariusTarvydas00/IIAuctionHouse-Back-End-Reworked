using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Core.IServices.IForestService
{
    public interface IForestLocationService
    {
        List<ForestLocation> GetAll();
        ForestLocation GetById(int id);

        ForestLocation Create(string forestryEnterprise);
        
        ForestLocation Update(ForestLocation forestLocation);

        ForestLocation Delete(int id);
    }
}