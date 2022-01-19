using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;
using IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators;
using IIAuctionHouse.Domain.Validators.ForestDetailsValidators.PlotDetailsValidators.TreeTypeValidators;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices
{
    public class PlotService: IPlotService
    {
        private readonly IPlotRepository _plotRepository;
        private readonly PlotValidator _plotValidator;
        private readonly TreeValidator _treeValidator;
        private readonly PercentageValidator _percentageValidator;

        public PlotService(IPlotRepository plotRepository, PlotValidator plotValidator, 
            TreeValidator treeValidator, PercentageValidator percentageValidator)
        {
            _plotRepository = plotRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
            _plotValidator = plotValidator ?? throw new NullReferenceException(ServicesExceptions.NullValidator);
            _treeValidator = treeValidator ?? throw new NullReferenceException(ServicesExceptions.NullValidator);
            _percentageValidator = percentageValidator ?? throw new NullReferenceException(ServicesExceptions.NullValidator);
        }
        public List<Plot> GetAll()
        {
            return _plotRepository.FindAll().ToList();
        }

        public Plot GetById(int id)
        {
            _plotValidator.ValidateId(id);
            return _plotRepository.GetById(id);
        }

        public Plot NewPlot(int id, double plotSize, string plotResolution, double plotTenderness,
            int volume, int averageTreeHeight, List<TreeType> treeTypes, ForestUid forestUid)
        {
            _plotValidator.ValidateId(id);
            _plotValidator.ValidateValue(volume,plotSize,plotTenderness,averageTreeHeight,plotResolution);
            foreach (var treeType in treeTypes)
            {
                _plotValidator.ValidateId(treeType.Id);
                _treeValidator.DefaultValidation(treeType.Tree);
                _percentageValidator.DefaultValidation(treeType.Percentage);
            }
            return new Plot()
            {
                Id = id,
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                TreeTypes = treeTypes,
                ForestUid = forestUid != null ? new ForestUid()
                {
                    FirstUid = new ForestUidFirst()
                    {
                        Id = forestUid.FirstUid?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = forestUid.FirstUid.Value,
                    },
                    SecondUid = new ForestUidSecond()
                    {
                        Id = forestUid.SecondUid?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = forestUid.SecondUid.Value
                    },
                    ThirdUid = new ForestUidThird()
                    {
                        Id = forestUid.ThirdUid?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = forestUid.ThirdUid.Value
                    }
                } : null
            };
        }

        public Plot UpdatePlot(int id, double plotSize, string plotResolution, double plotTenderness, int volume,
            int averageTreeHeight, List<TreeType> treeTypes, ForestUid forestUid)
        {
            _plotValidator.ValidateId(id);
            _plotValidator.ValidateValue(volume,plotSize,plotTenderness,averageTreeHeight,plotResolution);
            foreach (var treeType in treeTypes)
            {
                _plotValidator.ValidateId(treeType.Id);
                _treeValidator.DefaultValidation(treeType.Tree);
                _percentageValidator.DefaultValidation(treeType.Percentage);
            }
            
            var newPlot = new Plot()
            {
                Id = id,
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                TreeTypes = treeTypes,
                ForestUid = new ForestUid()
                {
                    FirstUid = new ForestUidFirst()
                    {
                        Id = forestUid.FirstUid?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = forestUid.FirstUid.Value
                    },
                    SecondUid = new ForestUidSecond()
                    {
                        Id = forestUid.SecondUid?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = forestUid.SecondUid.Value
                    },
                    ThirdUid = new ForestUidThird()
                    {
                        Id = forestUid.ThirdUid?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = forestUid.ThirdUid.Value
                    }
                }
            }; 
            return newPlot;
        }

        public Plot Create(Plot plot)
        {
            _plotValidator.DefaultValidation(plot);
            return _plotRepository.Create(plot);
        }

        public Plot Update(Plot plot)
        {
            _plotValidator.DefaultValidation(plot);
            return _plotRepository.Update(plot);
        }

        public Plot Delete(int id)
        {
            _plotValidator.ValidateId(id);
            return _plotRepository.Delete(id);
        }
    }
}