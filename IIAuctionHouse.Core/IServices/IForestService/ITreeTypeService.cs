using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Core.IServices.IForestService
{
    public interface ITreeTypeService
    {
        List<TreeType> GetAll();
        
        TreeType GetById(int id);

        TreeType Create(string treeType);
        
        TreeType Update(TreeType treeType);

        TreeType Delete(int id);
    }
}