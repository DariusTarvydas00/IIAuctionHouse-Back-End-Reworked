using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Core.IServices.IForestService
{
    public interface ITreeGroupService
    {
        List<TreeGroup> GetAll();
        TreeGroup GetById(int id);

        TreeGroup Create(string treeGroup);
        
        TreeGroup Update(TreeGroup treeGroup);

        TreeGroup Delete(int id);
    }
}