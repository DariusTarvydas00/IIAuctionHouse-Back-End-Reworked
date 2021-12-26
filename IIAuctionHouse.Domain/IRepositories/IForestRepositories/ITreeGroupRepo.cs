using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Domain.IRepositories.IForestRepositories
{
    public interface ITreeGroupRepo
    {
        IEnumerable<TreeGroup> FindAll();
        TreeGroup GetById(int id);
        TreeGroup Create(string treeGroup);
        TreeGroup Update(TreeGroup treeGroup);
        TreeGroup Delete(int id);
    }
}