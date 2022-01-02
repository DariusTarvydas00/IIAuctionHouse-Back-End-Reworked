using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Domain.IRepositories
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