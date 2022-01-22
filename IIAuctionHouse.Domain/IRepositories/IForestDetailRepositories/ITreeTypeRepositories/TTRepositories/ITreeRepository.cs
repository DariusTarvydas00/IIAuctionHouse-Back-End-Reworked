using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories
{
    public interface ITreeRepository
    {
        IEnumerable<Tree> FindAll();
        Tree GetById(int id);
        Tree Create(Tree tree);
        Tree Update(Tree tree);
        Tree Delete(int id);
    }
}