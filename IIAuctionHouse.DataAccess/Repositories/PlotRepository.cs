using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using IIAuctionHouse.Core.Exceptions;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Converters;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class PlotRepository: IPlotRepository
    {
        private readonly MainDbContext _ctx;
        private readonly IMapper _mapper;

        public PlotRepository(MainDbContext ctx)
        {
            // var configuration = new MapperConfiguration(cfg => {
            //     cfg.CreateMap<Plot, PlotEntity>().ConvertUsing(new PlotToPlotEntityConverter());
            //     cfg.CreateMap<PlotEntity, Plot>().ConvertUsing(new PlotEntityToPlotConverter());
            // });
            // configuration.AssertConfigurationIsValid();
            // _mapper = configuration.CreateMapper();
            _ctx = ctx;
        }
        
        public IEnumerable<Plot> FindAll()
        {
            return _ctx.Plots.Select(entity => new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolution = entity.PlotResolution,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
            }).ToList();
        }

        public Plot GetById(int id)
        {
            var plots = _ctx.Plots.Select(ae => new Plot()
            {
                Id = ae.Id,
                PlotSize = ae.PlotSize,
                PlotResolution = ae.PlotResolution,
                PlotTenderness = ae.PlotTenderness,
                Volume = ae.Volume,
                AverageTreeHeight = ae.AverageTreeHeight,
            }).FirstOrDefault(s=>s.Id == id);
            if (plots != null)
            {
                plots.TreeTypes = _ctx.TreeTypes.Select(ae => new TreeType()
                {
                    Id = ae.Id,
                    Name = ae.Name
                }).ToList();
                return plots;
            }

            return null;
        }

        public Plot Create(Plot plot)
        {
            try
            {
                var plotEntry = _ctx.Add(_mapper.Map<Plot, PlotEntity>(plot));
                _ctx.SaveChanges();
                var newPlot = plotEntry.Entity;
                return _mapper.Map<PlotEntity, Plot>(newPlot);
            }
            catch (Exception e)
            {
                throw new DataSourceException(e.InnerException?.Message);
            }
            //
            // var entity = _ctx.Plots.Add(new PlotEntity()
            // {
            //     PlotSize = plot.PlotSize,
            //     PlotResolutionFirstValue = plot.PlotResolutionFirstValue,
            //     PlotResolutionSecondValue = plot.PlotResolutionSecondValue,
            //     PlotTenderness = plot.PlotTenderness,
            //     Volume = plot.Volume,
            //     AverageTreeHeight = plot.AverageTreeHeight,
            // }).Entity;
            // _ctx.SaveChanges();
            // return newPlot;
        }

        public Plot Update(Plot plot)
        {
            var entity = _ctx.Plots.Update(new PlotEntity()
            {
                PlotSize = plot.PlotSize,
                PlotResolution = plot.PlotResolution,
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
            _ctx.Plots.Remove(new PlotEntity()
            {
                Id = id
            });
            _ctx.SaveChanges();
            return new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolution = entity.PlotResolution,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
            };
        }
    }
}