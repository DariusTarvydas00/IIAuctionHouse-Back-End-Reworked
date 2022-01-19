using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IPlotDetailServices;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.PlotServices
{
    public class PlotService: IPlotService
    {
        private readonly IPlotRepository _plotRepository;

        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }
        public List<Plot> GetAll()
        {
            return _plotRepository.FindAll().ToList();
        }

        public Plot GetById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _plotRepository.GetById(id);
        }

        public Plot NewPlot(double plotSize, string plotResolution, double plotTenderness,
            int volume, int averageTreeHeight, List<TreeType> treeTypes, ForestUid forestUid)
        {
            if (volume < 1 || plotSize < 1 || plotTenderness < 0.1 ||
                averageTreeHeight < 1 || string.IsNullOrEmpty(plotResolution) || plotResolution.Any(char.IsDigit))
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            
            var newPlot = new Plot()
            {
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                TreeTypes = treeTypes != null ? treeTypes.Select(asd => new TreeType()
                {
                    Percentage = asd.Percentage != null ? new Percentage()
                    {
                        Id = asd.Percentage?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = asd.Percentage.Value
                    } : throw new InvalidDataException(ServicesExceptions.MissingInformation),
                    Tree = asd.Tree != null ? new Tree()
                    {
                        Id = asd.Tree?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Name = asd.Tree.Name
                    } : throw new InvalidDataException(ServicesExceptions.MissingInformation),
                }).ToList() : throw new InvalidDataException(ServicesExceptions.MissingInformation),
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
            return newPlot;
        }

        public Plot UpdatePlot(int id, double plotSize, string plotResolution, double plotTenderness, int volume,
            int averageTreeHeight, List<TreeType> treeTypes, ForestUid forestUid)
        {
            if (id < 1 || volume < 1 || plotSize < 1 || plotTenderness < 0.1 ||
                averageTreeHeight < 1 || string.IsNullOrEmpty(plotResolution) || treeTypes == null || forestUid == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            
            var newPlot = new Plot()
            {
                Id = id,
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                TreeTypes = treeTypes != null ? treeTypes.Select(asd => new TreeType()
                {
                    Percentage = asd.Percentage != null ? new Percentage()
                    {
                        Id = asd.Percentage?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Value = asd.Percentage.Value
                    } : throw new InvalidDataException(ServicesExceptions.MissingInformation),
                    Tree = asd.Tree != null ? new Tree()
                    {
                        Id = asd.Tree?.Id ?? throw new InvalidDataException(ServicesExceptions.InvalidId),
                        Name = asd.Tree.Name
                    } : throw new InvalidDataException(ServicesExceptions.MissingInformation),
                }).ToList() : throw new InvalidDataException(ServicesExceptions.MissingInformation),
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
            if (plot == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _plotRepository.Create(plot);
        }

        public Plot Update(Plot plot)
        {
            if (plot == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _plotRepository.Update(plot);
        }

        public Plot Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _plotRepository.Delete(id);
        }
    }
}