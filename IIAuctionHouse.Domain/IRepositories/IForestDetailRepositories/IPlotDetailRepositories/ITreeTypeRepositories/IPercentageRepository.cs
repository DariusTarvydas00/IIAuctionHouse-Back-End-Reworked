using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories
{
    public interface IPercentageRepository
    {
        IEnumerable<Percentage> FindAll();
        Percentage GetById(int id);
        Percentage Create(Percentage percentage);
        Percentage Update(Percentage percentage);
        Percentage Delete(int id);
    }
}