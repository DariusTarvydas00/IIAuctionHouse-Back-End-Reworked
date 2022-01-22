using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.TreeTypeEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories
{
    public class PlotRepository : IPlotRepository
    {
        private readonly MainDbContext _ctx;
        private readonly ITreeRepository _treeRepository;
        private readonly IPercentageRepository _percentageRepository;

        public PlotRepository(MainDbContext ctx, ITreeRepository treeRepository, IPercentageRepository percentageRepository)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _treeRepository = treeRepository ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
            _percentageRepository = percentageRepository;
        }
        
        public IEnumerable<Plot> GetAll()
        {
            return _ctx.PlotDbSet.Include(plot => plot.TreeTypeSql).Select(plot => new Plot()
            {
                Id = plot.Id,
                Volume = plot.Volume,
                PlotResolution = plot.PlotResolution,
                PlotSize = plot.PlotSize,
                PlotTenderness = plot.PlotTenderness,
                AverageTreeHeight = plot.AverageTreeHeight,
                TreeTypes = plot.TreeTypeSql.Select(sql => new TreeType()
                {
                    Id = sql.Id,
                    Tree = new Tree()
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
                Forest = new Forest()
                {
                    Id = plot.Id
                }
            });
        }

        // If Single Plot with TreeType List
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
                TreeTypes = sql.TreeTypeSql != null ? sql.TreeTypeSql.Select(typeSql => new TreeType()
                {
                    Id = typeSql.Id,
                    Percentage = _percentageRepository.GetById(typeSql.PercentageSql.Id),
                    Tree = _treeRepository.GetById(typeSql.TreeSql.Id)
                }).ToList():null
            }).FirstOrDefault(plot => plot.Id == id);
        }

        public Plot Create(Plot plot)
        {
            var check = _ctx.ForestsDbSet.FirstOrDefault(sql => sql.Id == plot.Forest.Id);
            if (check == null)
                throw new Exception("Plot Creation Failed! Invalid Id");
            _ctx.PlotDbSet.Add(new PlotSql()
            {
                Volume = plot.Volume,
                PlotResolution = plot.PlotResolution,
                PlotSize = plot.PlotSize,
                PlotTenderness = plot.PlotTenderness,
                AverageTreeHeight = plot.AverageTreeHeight,
                TreeTypeSql = plot.TreeTypes?.Select(type => new TreeTypeSql()
                {
                    TreeSqlId = type.Tree.Id,
                    PercentageSqlId = type.Percentage.Id
                }).ToList(),
                ForestSqlId = plot.Forest.Id
            });
            _ctx.SaveChanges();
            return GetById(plot.Id);

        }

        public Plot Update(Plot plot)
        {
            var check = _ctx.PlotDbSet.AsNoTracking().FirstOrDefault(sql => sql.Id == plot.Id);
            if (check == null)
                throw new Exception("Plot Update Failed!");
            _ctx.PlotDbSet.Update(new PlotSql()
                {
                    Id = plot.Id,
                    Volume = plot.Volume,
                    PlotResolution = plot.PlotResolution,
                    PlotSize = plot.PlotSize,
                    PlotTenderness = plot.PlotTenderness,
                    AverageTreeHeight = plot.AverageTreeHeight,
                    TreeTypeSql = plot.TreeTypes.Select(typeSql => new TreeTypeSql()
                    {
                        Id = typeSql.Id,
                        PercentageSqlId = typeSql.Percentage.Id,
                        TreeSqlId = typeSql.Tree.Id
                    }).ToList(),
                    ForestSqlId = plot.Forest.Id
                });
            _ctx.SaveChanges();
            return GetById(check.Id);
        }
        public Plot Delete(int id)
        {
            var plotSql = _ctx.PlotDbSet.FirstOrDefault(plot => plot.Id == id);
            if (plotSql == null) 
                throw new Exception("Plot Not Found");
            _ctx.PlotDbSet.Remove(plotSql);
            _ctx.SaveChanges();
            return GetById(plotSql.Id);
        }
    }
}
