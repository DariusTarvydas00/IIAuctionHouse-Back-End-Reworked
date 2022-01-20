using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.ServiceExceptions;
using IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators.TreeTypeValidators;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices.TreeTypeServices
{
    public class TreeTypeService: ITreeTypeService
    {
        private readonly TreeValidator _treeValidator;
        private readonly PercentageValidator _percentageValidator;
        private readonly ITreeService _treeService;
        private readonly IPercentageService _percentageService;

        public TreeTypeService(TreeValidator treeValidator, PercentageValidator percentageValidator, ITreeService treeService, IPercentageService percentageService)
        {
            _treeValidator = treeValidator ?? throw new NullReferenceException(ServicesExceptions.NullValidator);
            _percentageValidator = percentageValidator ?? throw new NullReferenceException(ServicesExceptions.NullValidator);
            _treeService = treeService ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
            _percentageService = percentageService ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public TreeType NewTreeType(int id, int treeId, int percentageId)
        {
            _treeValidator.ValidateId(id);
            _treeValidator.ValidateId(treeId);
            _treeValidator.ValidateId(percentageId);
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