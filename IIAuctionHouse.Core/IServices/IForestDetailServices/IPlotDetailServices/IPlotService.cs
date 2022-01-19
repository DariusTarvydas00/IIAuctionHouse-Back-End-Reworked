using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices
{
    public interface IPlotService
    {
        List<Plot> GetAll();
        
        Plot GetById(int id);

        Plot NewPlot(int id, double plotSize, string plotResolution,
            double plotTenderness, int volume, int averageTreeHeight, List<TreeType> treeTypes, ForestUid forestUid);
        Plot Create(Plot plot);
        
        Plot Update(Plot plot);

        Plot Delete(int id);
    }
}