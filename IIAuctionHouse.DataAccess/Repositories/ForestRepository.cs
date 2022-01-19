using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class ForestRepository: IForestRepository
    {
        private readonly MainDbContext _ctx;
        private readonly IForestEnterpriseRepository _forestEnterpriseRepository;
        private readonly IForestGroupRepository _forestGroupRepository;
        private readonly IForestUidRepository _forestUidRepository;
        private readonly IPlotRepository _plotRepository;

        public ForestRepository(MainDbContext ctx, 
            IForestEnterpriseRepository forestEnterpriseRepository, 
            IForestGroupRepository forestGroupRepository,
            IForestUidRepository forestUidRepository, 
            IPlotRepository plotRepository )
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestEnterpriseRepository = forestEnterpriseRepository;
            _forestGroupRepository = forestGroupRepository;
            _forestUidRepository = forestUidRepository;
            _plotRepository = plotRepository;
        }

        public IEnumerable<Forest> FindAll()
        {
            return _ctx.ForestsDbSet
                .Include(c => c.ForestGroupSql)
                .Include(ct => ct.ForestryEnterpriseSql)
                .Include(sql => sql.PlotSqls).ThenInclude(sql => sql.TreeTypeSql)
                .Select(c => new Forest()
                {
                    Id = c.Id,
                    ForestryEnterprise = _forestEnterpriseRepository.GetById(c.ForestryEnterpriseSqlId),
                    ForestGroup = _forestGroupRepository.GetById(c.ForestGroupSqlId),
                    ForestLocation = new ForestLocation()
                    {
                        Id = c.ForestLocationSql.Id,
                        GeoLocationX = c.ForestLocationSql.GeoLocationX,
                        GeoLocationY = c.ForestLocationSql.GeoLocationY
                    },
                    ForestUid = new ForestUid()
                    {
                        Id = c.Id,
                        FirstUid = _forestUidRepository.GetForestUidFirst(c.ForestUidSql.ForestUidFirstSql.Id),
                        SecondUid = _forestUidRepository.GetForestUidSecond(c.ForestUidSql.ForestUidSecondSql.Id),
                        ThirdUid = _forestUidRepository.GetForestUidThird(c.ForestUidSql.ForestUidThirdSql.Id)
                    },
                })
                .ToList();
        }

        public Forest GetById(int id)
        {
            var forest = _ctx.ForestsDbSet.Include(sql => sql.PlotSqls).ThenInclude(sql => sql.TreeTypeSql)
                .Select(sql => new Forest()
                {
                    Id = sql.Id,
                    ForestryEnterprise = _forestEnterpriseRepository.GetById(sql.ForestryEnterpriseSqlId),
                    ForestGroup = _forestGroupRepository.GetById(sql.ForestGroupSqlId),
                    ForestLocation = new ForestLocation()
                    {
                        Id = sql.ForestLocationSql.Id,
                        GeoLocationX = sql.ForestLocationSql.GeoLocationX,
                        GeoLocationY = sql.ForestLocationSql.GeoLocationY
                    },
                    ForestUid = new ForestUid()
                    {
                        Id = sql.Id,
                        FirstUid = _forestUidRepository.GetForestUidFirst(sql.ForestUidSql.ForestUidFirstSql.Id),
                        SecondUid = _forestUidRepository.GetForestUidSecond(sql.ForestUidSql.ForestUidSecondSql.Id),
                        ThirdUid = _forestUidRepository.GetForestUidThird(sql.ForestUidSql.ForestUidThirdSql.Id)
                    },
                    //Plots = plotList

                }).FirstOrDefault(forest => forest.Id == id);
            forest.Plots = _plotRepository.FindAll()
                .Where(plot => plot.ForestUid.FirstUid.Id == forest.ForestUid.FirstUid.Id)
                .Where(plot => plot.ForestUid.SecondUid.Id == forest.ForestUid.SecondUid.Id)
                .Where(plot => plot.ForestUid.ThirdUid.Id == forest.ForestUid.ThirdUid.Id).ToList();
            return forest;
            //      // Bids = entity.BidSqls.Select(asd => new Bid()
            //      // {
            //      //     Id = asd.Id,
            //      //     BidAmount = asd.BidAmount,
            //      //     BidDateTime = asd.BidDateTime
            //      // }).ToList(),
            //  }).FirstOrDefault(forest => forest.Id == id);
        }
        
        public Forest Create(Forest forest)
        {
            var newForest = _ctx.ForestsDbSet.Add(new ForestSql()
            {
                ForestryEnterpriseSqlId = forest.ForestryEnterprise.Id,
                ForestGroupSqlId = forest.ForestGroup.Id,
                ForestLocationSql = new ForestLocationSql()
                {
                    Id = forest.ForestLocation.Id,
                    GeoLocationX = forest.ForestLocation.GeoLocationX,
                    GeoLocationY = forest.ForestLocation.GeoLocationY
                },
                ForestUidSql = new ForestUidSql()
                {
                    Id = forest.ForestUid.Id,
                    ForestUidFirstSqlId = forest.ForestUid.FirstUid.Id,
                    ForestUidSecondSqlId = forest.ForestUid.SecondUid.Id,
                    ForestUidThirdSqlId = forest.ForestUid.ThirdUid.Id
                },
            }).Entity;
            _ctx.SaveChanges();
            return _ctx.ForestsDbSet
                .Include(sql => sql.ForestLocationSql)
                .Select(sql => new Forest()
                {
                    Id = sql.Id,
                    ForestryEnterprise = _forestEnterpriseRepository.GetById(sql.ForestryEnterpriseSqlId),
                    ForestGroup = _forestGroupRepository.GetById(sql.ForestGroupSqlId),
                    ForestLocation = new ForestLocation()
                    {
                        Id = sql.ForestLocationSql.Id,
                        GeoLocationX = sql.ForestLocationSql.GeoLocationX,
                        GeoLocationY = sql.ForestLocationSql.GeoLocationY
                    },
                    ForestUid = new ForestUid()
                    {
                        Id = sql.Id,
                        FirstUid = _forestUidRepository.GetForestUidFirst(sql.ForestUidSql.ForestUidFirstSql.Id),
                        SecondUid = _forestUidRepository.GetForestUidSecond(sql.ForestUidSql.ForestUidSecondSql.Id),
                        ThirdUid = _forestUidRepository.GetForestUidThird(sql.ForestUidSql.ForestUidThirdSql.Id)
                    },
                }).FirstOrDefault(forest => forest.Id == newForest.Id);
        }

        public Forest Update(Forest forest)
        {
           // var forestSql = _forestConverter.Convert(forest);
            // var check = _ctx.ForestsDbSet.SingleOrDefault(sql => sql.Id == forestSql.Id);
            // if (check != null)
            //     _ctx.ForestsDbSet.Update(forestSql);
            // else
            //     _ctx.ForestsDbSet.Add(forestSql);
            // _ctx.SaveChanges();
            //return _forestConverter.Convert(forestSql);
            return null;
        }

        public Forest Delete(int id)
        {
            // var forestSql = _ctx.ForestsDbSet.FirstOrDefault(tree => tree.Id == id);
            // if (forestSql != null) _ctx.ForestsDbSet.Remove(forestSql);
            // _ctx.SaveChanges();
            // if (forestSql == null) return null; 
            // _ctx.ForestsDbSet.Remove(forestSql);
            // _ctx.SaveChanges();
            // return _forestConverter.Convert(forestSql);
            return null;
        }
    }
}