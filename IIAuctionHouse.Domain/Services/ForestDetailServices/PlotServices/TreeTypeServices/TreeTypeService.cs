using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices
{
    public class TreeTypeService: ITreeTypeService
    {
        public TreeType NewTreeType(int treeId, int percentageId)
        {
            return new TreeType()
            {
                Tree = new Tree()
                {
                    Id = treeId
                },
                Percentage = new Percentage()
                {
                    Id = percentageId
                }
            };
        }

        public TreeType UpdateTreeType(int id, int treeId, int percentageId)
        {
            return new TreeType()
            {
                Id = id,
                Tree = new Tree()
                {
                    Id = treeId
                },
                Percentage = new Percentage()
                {
                    Id = percentageId
                }
            };
        }
    }
}