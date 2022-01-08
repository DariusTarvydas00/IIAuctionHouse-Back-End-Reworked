using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface ITreeService
    {
        List<Tree> GetAll();
        Tree NewTreeType(string name);
        Tree Create(Tree tree);
        Tree Update(Tree tree);
        Tree Delete(int id);
    }
}