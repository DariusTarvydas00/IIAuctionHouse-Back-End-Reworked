using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories
{
    public class PlotRepository: IPlotRepository
    {
        private readonly MainDbContext _ctx;

        public PlotRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
        }

        public IEnumerable<Plot> FindAll()
        {
            return _ctx.PlotDbSet
                .OrderBy(sql => sql.ForestUidSql.ForestUidFirstSql.Id)
                .ThenBy(sql => sql.ForestUidSql.ForestUidSecondSql.Id)
                .ThenBy(sql => sql.ForestUidSql.ForestUidThirdSql.Id)
                .Select(entity => new Plot()
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
                }).ToList(),
                ForestUid = new ForestUid()
                {
                    Id = entity.ForestUidSql.Id,
                    FirstUid = new ForestUidFirst()
                    {
                        Id = entity.ForestUidSql.ForestUidFirstSql.Id,
                        Value = entity.ForestUidSql.ForestUidFirstSql.Value
                    },
                    SecondUid = new ForestUidSecond()
                    {
                        Id = entity.ForestUidSql.ForestUidSecondSql.Id,
                        Value = entity.ForestUidSql.ForestUidSecondSql.Value
                    },
                    ThirdUid = new ForestUidThird()
                    {
                        Id = entity.ForestUidSql.ForestUidThirdSql.Id,
                        Value = entity.ForestUidSql.ForestUidThirdSql.Value
                    }
                }
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
            var forest = _ctx.ForestsDbSet.FirstOrDefault(sql => 
                sql.ForestUidSql.ForestUidFirstSql.Id == plot.ForestUid.FirstUid.Id &&
                sql.ForestUidSql.ForestUidSecondSql.Id == plot.ForestUid.SecondUid.Id &&
                sql.ForestUidSql.ForestUidSecondSql.Id == plot.ForestUid.SecondUid.Id);
            if (forest == null)
            {
                throw new KeyNotFoundException(DataAccessExceptions.NotFound);
            }

            var newPlot = new PlotSql()
            {
                Volume = plot.Volume,
                PlotResolution = plot.PlotResolution,
                PlotSize = plot.PlotSize,
                PlotTenderness = plot.PlotTenderness,
                AverageTreeHeight = plot.AverageTreeHeight,
                ForestSqlId = forest.Id,
                TreeTypeSql = plot.TreeTypes.Select(asd => new TreeTypeSql()
                {
                    PercentageSqlId = asd.Percentage.Id,
                    TreeSqlId = asd.Tree.Id
                }).ToList(),
                ForestUidSql = new ForestUidSql()
                {
                    ForestUidFirstSqlId = plot.ForestUid.FirstUid.Id,
                    ForestUidSecondSqlId = plot.ForestUid.SecondUid.Id,
                    ForestUidThirdSqlId = plot.ForestUid.ThirdUid.Id
                },
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
                    TreeSqlId = asd.Tree.Id
                }).ToList()
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
            if (entity == null)
            {
                throw new KeyNotFoundException(DataAccessExceptions.NotFound);
            }

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