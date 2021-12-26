using System.Collections.Generic;
using IIAuctionHouse.Core.Models.Forest;

namespace IIAuctionHouse.Domain.IRepositories.IForestRepositories
{
    public interface ITreeTypeRepo
    {
        IEnumerable<TreeType> FindAll();
        TreeType GetById(int id);
        TreeType Create(string treeType);
        TreeType Update(TreeType treeType);
        TreeType Delete(int id);
    }
}