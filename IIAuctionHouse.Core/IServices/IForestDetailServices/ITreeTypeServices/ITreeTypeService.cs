using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices
{
    public interface ITreeTypeService
    {
        TreeType GetTreeType(int treeId, int percentageId);
    }
}