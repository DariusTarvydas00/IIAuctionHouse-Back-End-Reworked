using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices
{
    public interface ITreeService
    {
        List<Tree> GetAll();
        Tree NewTree(string name);
        Tree Create(Tree tree);
        Tree Update(Tree tree);
        Tree Delete(int id);
        
        Tree UpdateTree(int id, string name);
    }
}