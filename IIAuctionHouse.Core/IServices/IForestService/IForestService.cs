using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Core.IServices.IForestService
{
    public interface IForestService
    {
        List<Forest> GetAll();
        Forest GetById(int id);
        Forest NewForest(TreeGroup treeGroup, TreeType treeType, ForestLocation forestLocation);
        Forest Create(Forest forest);
        Forest Update(Forest forest);
        Forest Delete(int id);
    }
}