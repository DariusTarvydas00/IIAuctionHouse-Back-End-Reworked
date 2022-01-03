using System.Collections.Generic;
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
            _plotRepository = plotRepository;
        }
        public List<Plot> GetAll()
        {
            return _plotRepository.FindAll().ToList();
        }

        public Plot GetById(int id)
        {
            var plot = _plotRepository.GetById(id);
            return plot;
        }

        public Plot NewPlot(double plotSize, string plotResolution, double plotTenderness,
            int volume, int averageTreeHeight, List<TreeType> treeTypes)
        {
            
            var newPlot = new Plot()
            {
                PlotSize = plotSize,
                PlotResolution = plotResolution,
                PlotTenderness = plotTenderness,
                Volume = volume,
                AverageTreeHeight = averageTreeHeight,
                TreeTypes = treeTypes,
            };
            return newPlot;
        }

        public Plot Create(Plot plot)
        {
            return _plotRepository.Create(plot);
        }

        public Plot Update(Plot plot)
        {
            return _plotRepository.Update(plot);
        }

        public Plot Delete(int id)
        {
            return _plotRepository.Delete(id);
        }
    }
}