using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices
{
    public interface ITreeTypeService
    {
        TreeType NewTreeType(int treeId, int percentageId);
        TreeType UpdateTreeType(int id, int treeId, int percentageId);
    }
}