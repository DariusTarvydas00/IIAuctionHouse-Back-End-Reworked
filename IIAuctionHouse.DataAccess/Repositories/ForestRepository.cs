using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestGroupEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class ForestRepository: IForestRepository
    {
        private readonly MainDbContext _ctx;
        private readonly IForestryEnterpriseRepository _forestryEnterpriseRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IPlotRepository _plotRepository;

        public ForestRepository(MainDbContext ctx, 
            IForestryEnterpriseRepository forestryEnterpriseRepository, 
            IGroupRepository groupRepository,
            IPlotRepository plotRepository )
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestryEnterpriseRepository = forestryEnterpriseRepository;
            _groupRepository = groupRepository;
            _plotRepository = plotRepository;
        }

        public IEnumerable<Forest> FindAll()
        {
            return _ctx.ForestsDbSet
                .Include(sql => sql.PlotSqls).ThenInclude(sql => sql.TreeTypeSql).Include(fl=>fl.ForestLocationSql)
                .Select(c => new Forest()
                {
                    Id = c.Id,
                    ForestryEnterprise = new ForestryEnterprise()
                    {
                      Id  = c.ForestLocationSql.Id,
                      Name = c.ForestryEnterpriseSql.Name
                    },
                    ForestGroupSubGroup = new ForestGroupSubGroup()
                    {
                        Id = c.Id,
                        Group = new Group()
                        {
                            Id = c.ForestGroupSubGroupSql.GroupSql.Id,
                            ForestGroupName = c.ForestGroupSubGroupSql.GroupSql.ForestGroupName,
                        },
                        SubGroup = new SubGroup()
                        {
                            Id = c.ForestGroupSubGroupSql.SubGroupSql.Id,
                            ForestSubGroupName = c.ForestGroupSubGroupSql.SubGroupSql.ForestSubGroupName
                        },
                    },
                    ForestLocation = new ForestLocation()
                    {
                        Id = c.ForestLocationSql.Id,
                        GeoLocationX = c.ForestLocationSql.GeoLocationX,
                        GeoLocationY = c.ForestLocationSql.GeoLocationY
                    },
                    ForestUid = new ForestUid()
                    {
                        Id = c.Id,
                        FirstUid = new ForestUidFirst()
                        {
                            Id = c.ForestUidSql.ForestUidFirstSql.Id,
                            Value = c.ForestUidSql.ForestUidFirstSql.Value
                        },
                        SecondUid = new ForestUidSecond()
                        {
                            Id = c.ForestUidSql.ForestUidSecondSql.Id,
                            Value = c.ForestUidSql.ForestUidSecondSql.Value
                        },
                        ThirdUid = new ForestUidThird()
                        {
                            Id = c.ForestUidSql.ForestUidThirdSql.Id,
                            Value = c.ForestUidSql.ForestUidThirdSql.Value
                        }
                    },
                    Plots = c.PlotSqls.Select(sql => new Plot()
                    {
                        Id = sql.Id,
                        Volume = sql.Volume,
                        PlotResolution = sql.PlotResolution,
                        PlotSize = sql.PlotSize,
                        PlotTenderness = sql.PlotTenderness,
                        AverageTreeHeight = sql.AverageTreeHeight,
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
                    }).ToList()
                });
        }

        public Forest GetById(int id)
        {
            return _ctx.ForestsDbSet.Include(plot => plot.PlotSqls).ThenInclude(sqla => sqla.TreeTypeSql).Select(
                sql => new Forest()
                {
                    Id = sql.Id,
                    ForestryEnterprise = new ForestryEnterprise()
                    {
                        Id  = sql.ForestLocationSql.Id,
                        Name = sql.ForestryEnterpriseSql.Name
                    },
                    ForestLocation = new ForestLocation()
                    {
                        Id = sql.ForestLocationSql.Id,
                        GeoLocationX = sql.ForestLocationSql.GeoLocationX,
                        GeoLocationY = sql.ForestLocationSql.GeoLocationY
                    },
                    ForestUid = new ForestUid()
                    {
                        Id = sql.Id,
                        FirstUid = new ForestUidFirst()
                        {
                            Id = sql.ForestUidSql.ForestUidFirstSql.Id,
                            Value = sql.ForestUidSql.ForestUidFirstSql.Value
                        },
                        SecondUid = new ForestUidSecond()
                        {
                            Id = sql.ForestUidSql.ForestUidSecondSql.Id,
                            Value = sql.ForestUidSql.ForestUidSecondSql.Value
                        },
                        ThirdUid = new ForestUidThird()
                        {
                            Id = sql.ForestUidSql.ForestUidThirdSql.Id,
                            Value = sql.ForestUidSql.ForestUidThirdSql.Value
                        }
                    },
                    ForestGroupSubGroup = new ForestGroupSubGroup()
                    {
                        Id = sql.Id,
                        Group = new Group()
                        {
                            Id = sql.ForestGroupSubGroupSql.GroupSql.Id,
                            ForestGroupName = sql.ForestGroupSubGroupSql.GroupSql.ForestGroupName,
                        },
                        SubGroup = new SubGroup()
                        {
                            Id = sql.ForestGroupSubGroupSql.SubGroupSql.Id,
                            ForestSubGroupName = sql.ForestGroupSubGroupSql.SubGroupSql.ForestSubGroupName
                        },
                    },
                    Plots = sql.PlotSqls.Select(sql => new Plot()
                    {
                        Id = sql.Id,
                        Volume = sql.Volume,
                        PlotResolution = sql.PlotResolution,
                        PlotSize = sql.PlotSize,
                        PlotTenderness = sql.PlotTenderness,
                        AverageTreeHeight = sql.AverageTreeHeight,
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
                    }).ToList()
                }).FirstOrDefault(forest => forest.Id == id);
      
        }

        public Forest Create(Forest forest)
        {
            var newForest = _ctx.ForestsDbSet.Add(new ForestSql()
            {
                ForestryEnterpriseSqlId = forest.ForestryEnterprise.Id,
                ForestGroupSubGroupSql = new ForestGroupSubGroupSql()
                {
                    GroupSqlId = forest.ForestGroupSubGroup.Group.Id,
                    SubGroupSqlId = forest.ForestGroupSubGroup.SubGroup.Id
                },
                ForestLocationSql = new ForestLocationSql()
                {
                    GeoLocationX = forest.ForestLocation.GeoLocationX,
                    GeoLocationY = forest.ForestLocation.GeoLocationY
                },
                ForestUidSql = new ForestUidSql()
                {
                    ForestUidFirstSqlId = forest.ForestUid.FirstUid.Id,
                    ForestUidSecondSqlId = forest.ForestUid.SecondUid.Id,
                    ForestUidThirdSqlId = forest.ForestUid.ThirdUid.Id
                },
            }).Entity;
            _ctx.SaveChanges();
            return GetById(newForest.Id);
        }

        public Forest Update(Forest forest)
        {
            var forestSql = _ctx.ForestsDbSet.AsNoTracking().FirstOrDefault(sql => sql.Id == forest.Id);
            if (forestSql == null)
                throw new Exception("Forest Update Failed! ");
            _ctx.ForestsDbSet.Update(new ForestSql()
            {
                Id = forest.Id,
                ForestryEnterpriseSqlId = forest.ForestryEnterprise.Id,
                ForestLocationSql = new ForestLocationSql()
                {
                    Id = forest.ForestLocation.Id,
                    GeoLocationX = forest.ForestLocation.GeoLocationX,
                    GeoLocationY = forest.ForestLocation.GeoLocationY
                },
                ForestUidSql = new ForestUidSql()
                {
                    Id = forest.Id,
                    ForestUidFirstSqlId = forest.ForestUid.FirstUid.Id,
                    ForestUidSecondSqlId = forest.ForestUid.SecondUid.Id,
                    ForestUidThirdSqlId = forest.ForestUid.ThirdUid.Id
                },
                ForestGroupSubGroupSql = new ForestGroupSubGroupSql()
                {
                    Id = forest.Id,
                    GroupSqlId = forest.ForestGroupSubGroup.Group.Id,
                    SubGroupSqlId = forest.ForestGroupSubGroup.SubGroup.Id
                },
                
            });
            _ctx.SaveChanges();
            return GetById(forestSql.Id);
        }

        public Forest Delete(int id)
        {
            var forestSql = _ctx.ForestsDbSet.FirstOrDefault(forest => forest.Id == id);
            if (forestSql == null) 
                throw new Exception("Forest Not Found");
            _ctx.ForestsDbSet.Remove(forestSql);
            _ctx.SaveChanges();
            return GetById(forestSql.Id);
        }
    }
}