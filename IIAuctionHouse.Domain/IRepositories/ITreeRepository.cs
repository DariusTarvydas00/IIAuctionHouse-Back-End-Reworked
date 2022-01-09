using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
{
    public interface ITreeRepository
    {
        IEnumerable<Tree> FindAll();
        Tree Create(Tree tree);
        Tree Update(Tree tree);
        Tree Delete(int id);
    }
}