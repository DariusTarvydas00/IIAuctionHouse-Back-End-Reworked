using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class PlotService: IPlotService
    {
        private readonly IPlotRepository _plotRepository;

        public PlotService(IPlotRepository plotRepository)
        {
            _plotRepository = plotRepository ?? throw new NullReferenceException("Plot Repository Cannot be null");
        }
        public List<Plot> GetAll()
        {
            return _plotRepository.FindAll().ToList();
        }

        public Plot GetById(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Incorrect Tree Type Id");
            return _plotRepository.GetById(id);
        }

        public Plot NewPlot(double plotSize, string plotResolution, double plotTenderness,
            int volume, int averageTreeHeight, List<TreeType> treeTypes)
        {
            
            if (volume < 1 || plotSize < 1 || plotTenderness < 0.1 ||
                averageTreeHeight < 1 || string.IsNullOrEmpty(plotResolution) || treeTypes == null)
                throw new InvalidDataException("Plot is missing some information");
            
            var newPlot = new Plot()
            {
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                TreeTypes = treeTypes.Select(asd => new TreeType()
                {
                        Percentage = new Percentage()
                        {
                            Id = asd.Percentage.Id,
                            Value = asd.Percentage.Value
                        },
                        Tree = new Tree()
                        {
                            Id = asd.Tree.Id,
                            Name = asd.Tree.Name
                        }
                }).ToList()
            };
            return newPlot;
        }

        public Plot UpdatePlot(int id, double plotSize, string plotResolution, double plotTenderness, int volume,
            int averageTreeHeight, List<TreeType> treeTypes)
        {
            
            if (volume < 1 || plotSize < 1 || plotTenderness < 0.1 ||
                averageTreeHeight < 1 || string.IsNullOrEmpty(plotResolution) || treeTypes == null)
                throw new InvalidDataException("Plot is missing some information");
            
            var newPlot = new Plot()
            {
                Id = id,
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                TreeTypes = treeTypes.Select(asd => new TreeType()
                {
                    Id = asd.Id,
                    Percentage = new Percentage()
                    {
                        Id = asd.Percentage.Id
                    },
                    Tree = new Tree()
                    {
                        Id = asd.Tree.Id
                    }
                }).ToList()
            };
            return newPlot;
        }

        public Plot Create(Plot plot)
        {
            if (plot == null)
                throw new InvalidDataException("Plot can not be empty");

            return _plotRepository.Create(plot);
        }

        public Plot Update(Plot plot)
        {
            if (plot == null)
                throw new InvalidDataException("Plot can not be empty");
            return _plotRepository.Update(plot);
        }

        public Plot Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Incorrect Tree Type Id");
            return _plotRepository.Delete(id);
        }
    }
}