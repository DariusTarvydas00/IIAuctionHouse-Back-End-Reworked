using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface ITreeTypeService
    {
        List<TreeType> GetAll();
        
        TreeType GetById(int id);

        TreeType Create(TreeType treeType);
        
        TreeType NewTreeType(Tree treeType, Percentage percentage);
        
        TreeType Update(TreeType treeType);

        TreeType Delete(int id);
    }
}