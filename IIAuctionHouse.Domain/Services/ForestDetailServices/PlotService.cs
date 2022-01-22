using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.ITreeTypeServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices
{
    public class PlotService: IPlotService
    {
        private readonly IPlotRepository _plotRepository;
        
        private readonly ITreeTypeService _treeTypeService;

        public PlotService(IPlotRepository plotRepository, ITreeTypeService treeTypeService)
        {
            _plotRepository = plotRepository ?? throw new NullReferenceException("Plot Repository Can Not Be Null");
            _treeTypeService = treeTypeService ?? throw new NullReferenceException("Tree Type Service Can Not Be Null");
            
        }
        
        public Plot NewPlot(int id, int forestId, int volume, int averageTreeHeight, double plotSize, double plotTenderness,
            string plotResolution, List<TreeType> treeTypes)
        {
            CheckId(forestId);
            ValidatePlotValues(volume,averageTreeHeight,plotSize,plotTenderness,plotResolution);
            return new Plot
            {
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                Forest = new Forest()
                {
                    Id = forestId
                },
                TreeTypes = treeTypes
                    .Select(treeType => 
                        _treeTypeService.GetTreeType(treeType.Tree.Id, treeType.Percentage.Id)).ToList()
            };
        }

        public Plot Create(Plot plot)
        {
            CheckIfNull(plot);
            ValidatePlotValues(plot.Volume, plot.AverageTreeHeight, plot.PlotSize, plot.PlotTenderness,plot.PlotResolution);
            return _plotRepository.Create(plot);
        }

        public Plot Update(Plot plot)
        {
            CheckIfNull(plot);
            CheckId(plot.Id);
            ValidatePlotValues(plot.Volume, plot.AverageTreeHeight, plot.PlotSize, plot.PlotTenderness,plot.PlotResolution);
            return _plotRepository.Update(plot);
        }

        public Plot Delete(int id)
        {
            CheckId(id);
            return _plotRepository.Delete(id);
        }

        private void CheckId(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Invalid Plot Id");
        }

        private void CheckIfNull(Plot plot)
        {
            if (plot == null)
                throw new InvalidDataException("Plot Cannot Be Null");
        }
        
        
        
        private void ValidatePlotValues(int volume, int averageTreeHeight, double plotSize, double plotTenderness, string plotResolution)
        {
            if (volume < 1 || averageTreeHeight < 1 || plotSize < 0.1 || plotTenderness < 0.1)
                throw new InvalidDataException("Some Of Plot Values Are Incorrect");
            
            var patter = new Regex(@"^\d{1,4}(x\d{1,4})");
            var match = patter.Match(plotResolution);
            if (!match.Success)
                throw new InvalidDataException("Incorrect Plot Tenderness");
        }
    }
}