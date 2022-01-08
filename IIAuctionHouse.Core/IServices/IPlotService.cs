using System.Collections.Generic;
using IIAuctionHouse.Core.Models;

namespace IIAuctionHouse.Core.IServices
{
    public interface IPlotService
    {
        List<Plot> GetAll();
        
        Plot GetById(int id);

        Plot NewPlot(double plotSize, string plotResolution,
            double plotTenderness, int volume, int averageTreeHeight, List<TreeType> treeTypes);

        Plot UpdatePlot(int id, double plotSize, string plotResolution,
            double plotTenderness, int volume, int averageTreeHeight, List<TreeType> treeTypes);
        Plot Create(Plot plot);
        
        Plot Update(Plot plot);

        Plot Delete(int id);
    }
}