using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories
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