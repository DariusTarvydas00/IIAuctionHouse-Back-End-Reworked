using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories
{
    public interface IPlotRepository
    {
        IEnumerable<Plot> FindAll();
        Plot GetById(int id);
        Plot Create(Plot plot);
        Plot Update(Plot plot);
        Plot Delete(int id);
    }
}