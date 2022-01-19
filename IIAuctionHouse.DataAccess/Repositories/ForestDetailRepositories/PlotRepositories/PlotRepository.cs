using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories
{
    public class PlotRepository : IPlotRepository
    {
        private readonly MainDbContext _ctx;
        private readonly IForestUidRepository _forestUidRepository;
        private readonly ITreeRepository _treeRepository;
        private readonly IPercentageRepository _percentageRepository;
        private readonly ITreeTypeRepository _treeTypeRepository;

        public PlotRepository(MainDbContext ctx, IForestUidRepository forestUidRepository,
            ITreeRepository treeRepository, IPercentageRepository percentageRepository, ITreeTypeRepository treeTypeRepository)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestUidRepository = forestUidRepository ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
            _treeRepository = treeRepository ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
            _percentageRepository = percentageRepository;
            _treeTypeRepository = treeTypeRepository;
        }

        public IEnumerable<Plot> FindAll()
        {
            return _ctx.PlotDbSet.Include(sql => sql.TreeTypeSql).Select(sql => new Plot()
            {
                Id = sql.Id,
                Volume = sql.Volume,
                PlotResolution = sql.PlotResolution,
                PlotSize = sql.PlotSize,
                PlotTenderness = sql.PlotTenderness,
                AverageTreeHeight = sql.AverageTreeHeight,
                ForestUid = new ForestUid()
                {
                    Id = sql.Id,
                    FirstUid = _forestUidRepository.GetForestUidFirst(sql.ForestUidSql.ForestUidFirstSql.Id),
                    SecondUid = _forestUidRepository.GetForestUidSecond(sql.ForestUidSql.ForestUidSecondSql.Id),
                    ThirdUid = _forestUidRepository.GetForestUidThird(sql.ForestUidSql.ForestUidThirdSql.Id)
                },
                TreeTypes = sql.TreeTypeSql.Select(typeSql => new TreeType()
                {
                    Id = typeSql.Id,
                    Percentage = new Percentage()
                    {
                        Id = typeSql.PercentageSql.Id,
                        Value = typeSql.PercentageSql.Value
                    },
                    Tree = new Tree()
                    {
                        Id = typeSql.TreeSql.Id,
                        Name = typeSql.TreeSql.Name
                    }
                }).ToList()
            });
        }

        public Plot GetById(int id)
        {
            return _ctx.PlotDbSet.Select(sql => new Plot()
            {
                Id = sql.Id,
                Volume = sql.Volume,
                PlotResolution = sql.PlotResolution,
                PlotSize = sql.PlotSize,
                PlotTenderness = sql.PlotTenderness,
                AverageTreeHeight = sql.AverageTreeHeight,
                ForestUid = new ForestUid()
                {
                    Id = sql.Id,
                    FirstUid = _forestUidRepository.GetForestUidFirst(sql.ForestUidSql.ForestUidFirstSql.Id),
                    SecondUid = _forestUidRepository.GetForestUidSecond(sql.ForestUidSql.ForestUidSecondSql.Id),
                    ThirdUid = _forestUidRepository.GetForestUidThird(sql.ForestUidSql.ForestUidThirdSql.Id)
                },
                TreeTypes = sql.TreeTypeSql.Select(typeSql => new TreeType()
                {
                    Id = typeSql.Id,
                    Percentage = _percentageRepository.GetById(typeSql.PercentageSql.Id),
                    Tree = _treeRepository.GetById(typeSql.TreeSql.Id)
                }).ToList()
            }).FirstOrDefault(plot => plot.Id == id);
        }

        public Plot Create(Plot plot)
        {
            var newPlot = _ctx.PlotDbSet.Add(new PlotSql()
            {
                Id = plot.Id,
                Volume = plot.Volume,
                PlotResolution = plot.PlotResolution,
                PlotSize = plot.PlotSize,
                PlotTenderness = plot.PlotTenderness,
                AverageTreeHeight = plot.AverageTreeHeight,
                ForestUidSql = new ForestUidSql()
                {
                    Id = plot.ForestUid.Id,
                    ForestUidFirstSqlId = plot.ForestUid.FirstUid.Id,
                    ForestUidSecondSqlId = plot.ForestUid.SecondUid.Id,
                    ForestUidThirdSqlId = plot.ForestUid.ThirdUid.Id
                },
                TreeTypeSql = plot.TreeTypes.Select(type => new TreeTypeSql()
                {
                    Id = type.Id,
                    TreeSqlId = type.Tree.Id,
                    PercentageSqlId = type.Percentage.Id
                }).ToList()
            }).Entity;
            _ctx.SaveChanges();
            return _ctx.PlotDbSet.Select(sql => new Plot()
            {
                Id = sql.Id,
                Volume = sql.Volume,
                PlotResolution = sql.PlotResolution,
                PlotSize = sql.PlotSize,
                PlotTenderness = sql.PlotTenderness,
                AverageTreeHeight = sql.AverageTreeHeight,
                ForestUid = new ForestUid()
                {
                    Id = sql.Id,
                    FirstUid = _forestUidRepository.GetForestUidFirst(sql.ForestUidSql.ForestUidFirstSql.Id),
                    SecondUid = _forestUidRepository.GetForestUidSecond(sql.ForestUidSql.ForestUidSecondSql.Id),
                    ThirdUid = _forestUidRepository.GetForestUidThird(sql.ForestUidSql.ForestUidThirdSql.Id)
                },
                TreeTypes = sql.TreeTypeSql.Select(typeSql => new TreeType()
                {
                    Id = typeSql.Id,
                    Percentage = _percentageRepository.GetById(typeSql.PercentageSql.Id),
                    Tree = _treeRepository.GetById(typeSql.TreeSql.Id)
                }).ToList()
            }).FirstOrDefault(plot => plot.Id == newPlot.Id);
        }

        public Plot Update(Plot plot)
        {
            var check = _ctx.PlotDbSet.SingleOrDefault(sql => sql.Id == plot.Id);
            if (check != null)
                _ctx.PlotDbSet.Update(new PlotSql()
                {
                    Id = plot.Id,
                    Volume = plot.Volume,
                    PlotResolution = plot.PlotResolution,
                    PlotSize = plot.PlotSize,
                    PlotTenderness = plot.PlotTenderness,
                    AverageTreeHeight = plot.AverageTreeHeight,
                    ForestUidSql = new ForestUidSql()
                    {
                        Id = plot.Id,
                        ForestUidFirstSqlId = plot.ForestUid.FirstUid.Id,
                        ForestUidSecondSqlId = plot.ForestUid.SecondUid.Id,
                        ForestUidThirdSqlId = plot.ForestUid.ThirdUid.Id
                    },
                    TreeTypeSql = plot.TreeTypes.Select(typeSql => new TreeTypeSql()
                    {
                        Id = typeSql.Id,
                        PercentageSqlId = typeSql.Percentage.Id,
                        TreeSqlId = typeSql.Tree.Id
                    }).ToList()
                });
            _ctx.SaveChanges();
            return GetById(check.Id);
        }

        public Plot Delete(int id)
        {
            // var plotSql = _ctx.PlotDbSet.FirstOrDefault(tree => tree.Id == id);
            // if (plotSql != null) _ctx.PlotDbSet.Remove(plotSql);
            // _ctx.SaveChanges();
            // if (plotSql == null) return null;
            // _ctx.PlotDbSet.Remove(plotSql);
            // _ctx.SaveChanges();
            // return _plotConverter.Convert(plotSql);
            return null;
        }
    }
}
