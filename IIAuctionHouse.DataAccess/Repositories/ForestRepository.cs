using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class ForestRepository: IForestRepository
    {
        private readonly MainDbContext _ctx;

        public ForestRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Forest> FindAll()
        {
            return _ctx.ForestsDbSet.Select(entity => new Forest()
            {
                Id = entity.Id,
                ForestGroup = new ForestGroup()
                {
                    Id = entity.ForestGroupSql.Id,
                    Name = entity.ForestGroupSql.Name
                },
                ForestLocation = new ForestLocation()
                {
                    Id = entity.ForestLocationSql.Id,
                    GeoLocationX = entity.ForestLocationSql.GeoLocationX,
                    GeoLocationY = entity.ForestLocationSql.GeoLocationY
                },
                ForestUid = new ForestUid()
                {
                    Id = entity.ForestUidSql.Id,
                    FirstUid = entity.ForestUidSql.FirstUid,
                    SecondUid = entity.ForestUidSql.SecondUid,
                    ThirdUid = entity.ForestUidSql.ThirdUid
                },
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = entity.ForestryEnterpriseSql.Id,
                    Name = entity.ForestryEnterpriseSql.Name
                },
            }).ToList();
        }

        public Forest GetById(int id)
        {
            return _ctx.ForestsDbSet.Select(entity => new Forest()
            {
                Id = entity.Id,
                ForestGroup = new ForestGroup()
                {
                    Id = entity.ForestGroupSql.Id,
                    Name = entity.ForestGroupSql.Name
                },
                ForestLocation = new ForestLocation()
                {
                    Id = entity.ForestLocationSql.Id,
                    GeoLocationX = entity.ForestLocationSql.GeoLocationX,
                    GeoLocationY = entity.ForestLocationSql.GeoLocationY
                },
                ForestUid = new ForestUid()
                {
                    Id = entity.ForestUidSql.Id,
                    FirstUid = entity.ForestUidSql.FirstUid,
                    SecondUid = entity.ForestUidSql.SecondUid,
                    ThirdUid = entity.ForestUidSql.ThirdUid
                },
                Plots = entity.PlotSqls.Select(sql => new Plot()
                {
                    Id = sql.Id,
                    Volume = sql.Volume,
                    PlotResolution = sql.PlotResolution,
                    PlotSize = sql.PlotSize,
                    PlotTenderness = sql.PlotTenderness,
                    AverageTreeHeight = sql.AverageTreeHeight,
                    TreeTypes = sql.TreeTypeSql.Select(treeTypeSql => new TreeType()
                    {
                        Id = treeTypeSql.Id,
                        Percentage = new Percentage()
                        {
                            Id = treeTypeSql.PercentageSql.Id,
                            Value = treeTypeSql.PercentageSql.Value
                        },
                        Tree = new Tree()
                        {
                            Id = treeTypeSql.TreeSql.Id,
                            Name = treeTypeSql.TreeSql.Name
                        }
                        
                    }).ToList()
                }).ToList(),
                Bids = entity.BidSqls.Select(asd => new Bid()
                {
                    Id = asd.Id,
                    BidAmount = asd.BidAmount,
                    BidDateTime = asd.BidDateTime
                }).ToList(),
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = entity.ForestryEnterpriseSql.Id,
                    Name = entity.ForestryEnterpriseSql.Name
                }
            }).FirstOrDefault(forest => forest.Id == id);
        }
        
        public Forest Create(Forest forest)
        {
            var newForest = new ForestSql()
            {
                ForestGroupSql = new ForestGroupSql()
                {
                        Id = forest.ForestGroup.Id,
                        Name = forest.ForestGroup.Name
                    
                },
                ForestLocationSql = new ForestLocationSql()
                {
                    GeoLocationX = forest.ForestLocation.GeoLocationX,
                    GeoLocationY = forest.ForestLocation.GeoLocationY
                },
                ForestUidSql = new ForestUidSql()
                {
                    FirstUid = forest.ForestUid.FirstUid,
                    SecondUid = forest.ForestUid.SecondUid,
                    ThirdUid = forest.ForestUid.ThirdUid
                },
                ForestryEnterpriseSqlId = forest.ForestryEnterprise.Id,
                PlotSqls = forest.Plots.Select(asd => new PlotSql()
                {
                    TreeTypeSql = asd.TreeTypes.Select(asdd => new TreeTypeSql()
                    {
                        PercentageSqlId = asdd.Percentage.Id,
                        TreeSqlId = asdd.Tree.Id
                    }).ToList()
                }).ToList(),
                BidSqls = forest.Bids.Select(asdd=> new BidSql()
                {
                    Id = asdd.Id,
                    BidAmount = asdd.BidAmount,
                    BidDateTime = asdd.BidDateTime
                }).ToList()
            };
            _ctx.ForestsDbSet.Add(newForest);
            _ctx.SaveChanges();
            return new Forest()
            {
                Id = newForest.Id,
                ForestGroup = new ForestGroup()
                {
                    Id = newForest.ForestGroupSql.Id,
                    Name = newForest.ForestGroupSql.Name
                },
                ForestLocation = new ForestLocation()
                {
                    Id = newForest.ForestLocationSql.Id,
                    GeoLocationX = newForest.ForestLocationSql.GeoLocationX,
                    GeoLocationY = newForest.ForestLocationSql.GeoLocationY
                },
                ForestUid = new ForestUid()
                {
                    Id = newForest.ForestUidSql.Id,
                    FirstUid = newForest.ForestUidSql.FirstUid,
                    SecondUid = newForest.ForestUidSql.SecondUid,
                    ThirdUid = newForest.ForestUidSql.ThirdUid
                },
                // ForestryEnterprise = new ForestryEnterprise()
                // {
                //     Id = newForest.ForestryEnterpriseSql.Id,
                //     Name = newForest.ForestryEnterpriseSql.Name
                // }
            };
        }

        public Forest Update(Forest forest)
        {
            var entity = _ctx.ForestsDbSet.Update(new ForestSql()
            {
                Id = forest.Id,
                ForestGroupSql = new ForestGroupSql()
                {
                    Id = forest.ForestGroup.Id,
                    Name = forest.ForestGroup.Name
                    
                },
                ForestLocationSql = new ForestLocationSql()
                {
                    Id = forest.ForestLocation.Id,
                    GeoLocationX = forest.ForestLocation.GeoLocationX,
                    GeoLocationY = forest.ForestLocation.GeoLocationY
                },
                ForestUidSql = new ForestUidSql()
                {
                    Id = forest.ForestUid.Id,
                    FirstUid = forest.ForestUid.FirstUid,
                    SecondUid = forest.ForestUid.SecondUid,
                    ThirdUid = forest.ForestUid.ThirdUid
                },
                ForestryEnterpriseSql = new ForestryEnterpriseSql()
                {
                    Id = forest.ForestryEnterprise.Id,
                    Name = forest.ForestryEnterprise.Name
                }
            }).Entity;
            _ctx.SaveChanges();
            return new Forest()
            {
                Id = entity.Id,
                ForestGroup = new ForestGroup()
                {
                    Id = entity.ForestGroupSql.Id,
                    Name = entity.ForestGroupSql.Name
                },
                ForestLocation = new ForestLocation() 
                {
                    Id = entity.ForestLocationSql.Id, 
                    GeoLocationX = entity.ForestLocationSql.GeoLocationX, 
                    GeoLocationY = entity.ForestLocationSql.GeoLocationY
                }, 
                ForestUid = new ForestUid() 
                {
                    Id = entity.ForestUidSql.Id, 
                    FirstUid = entity.ForestUidSql.FirstUid, 
                    SecondUid = entity.ForestUidSql.SecondUid, 
                    ThirdUid = entity.ForestUidSql.ThirdUid
                },
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = entity.ForestryEnterpriseSql.Id,
                    Name = entity.ForestryEnterpriseSql.Name
                }
             };
        }

        public Forest Delete(int id)
        {
            var entity = _ctx.ForestsDbSet.FirstOrDefault(percentage => percentage.Id == id);
            if (entity != null) _ctx.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new Forest()
            {
                Id = entity.Id,
                ForestGroup = new ForestGroup()
                {
                    Id = entity.ForestGroupSql.Id,
                    Name = entity.ForestGroupSql.Name
                },
                ForestLocation = new ForestLocation() 
                {
                    Id = entity.ForestLocationSql.Id, 
                    GeoLocationX = entity.ForestLocationSql.GeoLocationX, 
                    GeoLocationY = entity.ForestLocationSql.GeoLocationY
                }, 
                ForestUid = new ForestUid() 
                {
                    Id = entity.ForestUidSql.Id, 
                    FirstUid = entity.ForestUidSql.FirstUid, 
                    SecondUid = entity.ForestUidSql.SecondUid, 
                    ThirdUid = entity.ForestUidSql.ThirdUid
                },
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = entity.ForestryEnterpriseSql.Id,
                    Name = entity.ForestryEnterpriseSql.Name
                }
            } : null;
        }
    }
}