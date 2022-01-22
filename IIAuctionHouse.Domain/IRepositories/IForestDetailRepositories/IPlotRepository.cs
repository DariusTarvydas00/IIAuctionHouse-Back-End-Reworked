using IIAuctionHouse.Core.Models.ForestDetailModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories
{
    public interface IPlotRepository
    {
        Plot Create(Plot plot);
        Plot Update(Plot plot);
        Plot Delete(int id);
    }
}