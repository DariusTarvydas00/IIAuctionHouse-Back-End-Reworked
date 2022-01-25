using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices.TTServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.TreeTypeServices
{
    public class TreeTypeService: ITreeTypeService
    {
        private readonly ITreeService _treeService;
        private readonly IPercentageService _percentageService;

        public TreeTypeService(ITreeService treeService,IPercentageService percentageService)
        {
            _treeService = treeService ?? throw new NullReferenceException("Tree Repository Can Not Be Null");
            _percentageService = percentageService ?? throw new NullReferenceException("Percentage Repository Can Not Be Null");
        }

        public TreeType GetTreeType(int treeId, int percentageId)
        {
            var tree = _treeService.GetById(treeId);
            var percentage = _percentageService.GetById(percentageId);
            if (tree != null | percentage != null)
            {
                return new TreeType()
                {
                    Tree = tree,
                    Percentage = percentage
                };
                
            }
            throw new Exception("Tree Type Not Found");

        }
    }
}