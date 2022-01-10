using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;


namespace IIAuctionHouse.DataAccess.Repositories
{
    public class PlotRepository: IPlotRepository
    {
        private readonly MainDbContext _ctx;
        private readonly ITreeRepository _treeRepository;
        private readonly IPercentageRepository _percentageRepository;

        public PlotRepository(MainDbContext ctx, ITreeRepository treeRepository, IPercentageRepository percentageRepository)
        {
            _ctx = ctx;
            _treeRepository = treeRepository;
            _percentageRepository = percentageRepository;
        }

        public IEnumerable<Plot> FindAll()
        {
            
            return _ctx.PlotDbSet.Select(entity => new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolution = entity.PlotResolution,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
                TreeTypes =  entity.TreeTypeSql.Select(sql => new TreeType()
                {
                    Id = sql.Id,
                    Tree =  new Tree()
                    {
                        Id = sql.TreeSql.Id,
                        Name = sql.TreeSql.Name
                    },
                    Percentage = new Percentage()
                    {
                        Id = sql.PercentageSql.Id,
                        Value = sql.PercentageSql.Value
                    }
                }).ToList()
            }).ToList();
        }

        public Plot GetById(int id)
        {
            return _ctx.PlotDbSet.Select(entity => new Plot()
            {
                Id = entity.Id,
                PlotSize = entity.PlotSize,
                PlotResolution = entity.PlotResolution,
                PlotTenderness = entity.PlotTenderness,
                Volume = entity.Volume,
                AverageTreeHeight = entity.AverageTreeHeight,
                TreeTypes =  entity.TreeTypeSql.Select(sql => new TreeType()
                {
                    Id = sql.Id,
                    Tree =  new Tree()
                    {
                        Id = sql.TreeSql.Id,
                        Name = sql.TreeSql.Name
                    },
                    Percentage = new Percentage()
                    {
                        Id = sql.PercentageSql.Id,
                        Value = sql.PercentageSql.Value
                    }
                }).ToList()
            }).FirstOrDefault(plot => plot.Id == id);
        }

        public Plot Create(Plot plot)
        {
            
            var newPlot = new PlotSql()
            {
                Volume = plot.Volume,
                PlotResolution = plot.PlotResolution,
                PlotSize = plot.PlotSize,
                PlotTenderness = plot.PlotTenderness,
                AverageTreeHeight = plot.AverageTreeHeight,
                TreeTypeSql = plot.TreeTypes.Select(asd => new TreeTypeSql()
                {
                    PercentageSqlId = asd.Percentage.Id,
                    TreeSqlId = asd.Tree.Id
                }).ToList()
            };
            var plotEntry = _ctx.PlotDbSet.Add(newPlot);
            _ctx.SaveChanges();
            return new Plot()
            {
                Id = plotEntry.Entity.Id,
                PlotSize = plotEntry.Entity.PlotSize,
                PlotResolution = plotEntry.Entity.PlotResolution,
                PlotTenderness = plotEntry.Entity.PlotTenderness,
                Volume = plotEntry.Entity.Volume,
                AverageTreeHeight = plotEntry.Entity.AverageTreeHeight,
            };
        }

        public Plot Update(Plot plot)
        {
            var entity =new PlotSql()
            {
                Id = plot.Id,
                PlotSize = plot.PlotSize,
                PlotResolution = plot.PlotResolution,
                PlotTenderness = plot.PlotTenderness,
                Volume = plot.Volume,
                AverageTreeHeight = plot.AverageTreeHeight,
                TreeTypeSql = plot.TreeTypes.Select(asd => new TreeTypeSql()
                   {
                       Id = asd.Id,
                       PercentageSqlId = asd.Percentage.Id, 
                       TreeSqlId = asd.Tree.Id}).ToList()
            };
            _ctx.PlotDbSet.Update(entity);

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

        public Plot Delete(int id)
        {
            var entity = GetById(id);
            _ctx.PlotDbSet.Remove(new PlotSql()
            {
                Id = id,
                TreeTypeSql = entity.TreeTypes.Select(asd => new TreeTypeSql()
                {
                    Id = asd.Id
                }).ToList()
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