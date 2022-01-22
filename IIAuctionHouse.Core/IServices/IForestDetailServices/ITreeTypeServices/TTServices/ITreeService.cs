using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices
{
    public interface ITreeService
    {
        List<Tree> GetAll();
        Tree Create(Tree tree);
        Tree Update(int id, Tree tree);
        Tree Delete(int id);
        Tree GetById(int treeId);
    }
}