using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface ITreeTypeRepository
    {
        TreeType Create(TreeType treeType);
        TreeType GetById(int id);
        IEnumerable<TreeType> FindAll();
        TreeType Update(TreeType treeType);
        TreeType Delete(int id);
    }
}