using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices
{
    public interface IPlotService
    {
        Plot NewPlot(int id, int forestId,int volume, int averageTreeHeight, double plotSize,double plotTenderness, string plotResolution, List<TreeType> treeTypes);
        Plot Create(Plot plot);
        Plot Update(Plot plot);
        Plot Delete(int id);
    }
}