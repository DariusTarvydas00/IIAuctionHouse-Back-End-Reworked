using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailsRepositories
{
    public class PlotRepository: IPlotRepository
    {
        private readonly MainDbContext _ctx;

        public PlotRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public IEnumerable<Plot> FindAll()
        {
            return _ctx.PlotEntities.Select(ae => new Plot()
            {
                Id = ae.Id,
                PlotSize = ae.PlotSize,
                PlotResolutionFirstValue = ae.PlotResolutionFirstValue,
                PlotResolutionSecondValue = ae.PlotResolutionSecondValue,
                PlotTenderness = ae.PlotTenderness,
                Volume = ae.Volume,
                AverageTreeHeight = ae.AverageTreeHeight,
            }).ToList();
        }

        public Plot GetById(int id)
        {
            return _ctx.PlotEntities.Select(ae => new Plot()
            {
                Id = ae.Id,
                PlotSize = ae.PlotSize,
                PlotResolutionFirstValue = ae.PlotResolutionFirstValue,
                PlotResolutionSecondValue = ae.PlotResolutionSecondValue,
                PlotTenderness = ae.PlotTenderness,
                Volume = ae.Volume,
                AverageTreeHeight = ae.AverageTreeHeight,
                TreeTypes = ae.TreeTypeEntities
            }).FirstOrDefault(s=>s.Id == id);
        }

        public Plot Create(Plot plot)
        {
            var entity = _ctx.PlotEntities.Add(new PlotEntity()
            {
                PlotSize = plot.PlotSize,
                PlotResolutionFirstValue = plot.PlotResolutionFirstValue,
                PlotResolutionSecondValue = plot.PlotResolutionSecondValue,
                PlotTenderness = plot.PlotTenderness,
                Volume = plot.Volume,
                AverageTreeHeight = plot.AverageTreeHeight,
            }).Entity;
            _ctx.SaveChanges();
            var newPlot = GetById(entity.Id);
            return newPlot;
        }

        public Plot Update(Plot plot)
        {
            var entity = _ctx.PlotEntities.Update(new PlotEntity()
            {
                PlotSize = plot.PlotSize,
                PlotResolutionFirstValue = plot.PlotResolutionFirstValue,
                PlotResolutionSecondValue = plot.PlotResolutionSecondValue,
                PlotTenderness = plot.PlotTenderness,
                Volume = plot.Volume,
                AverageTreeHeight = plot.AverageTreeHeight,
            }).Entity;
            _ctx.SaveChanges();
            var updatedPlot = GetById(plot.Id);
            return updatedPlot;
        }

        public Plot Delete(int id)
        {
            var entity = GetById(id);
            _ctx.PlotEntities.Remove(new PlotEntity()
            {
                Id = id
            });
            _ctx.SaveChanges();
            return new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolutionFirstValue = entity.PlotResolutionFirstValue,
                PlotResolutionSecondValue = entity.PlotResolutionSecondValue,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
            };
        }
    }
}