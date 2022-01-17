using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class ForestService: IForestService
    {
        private readonly IForestRepository _forestRepository;

        public ForestService(IForestRepository forestRepository)
        {
            _forestRepository = forestRepository;
        }

        public List<Forest> GetAll()
        {
            return _forestRepository.FindAll().ToList();
        }

        public Forest GetById(int id)
        {
            return _forestRepository.GetById(id);
        }

        // public Forest NewForest(ForestryEnterprise forestryEnterprise, 
        //     List<Bid> bids)
        // {
        //     if (
        //         forestryEnterprise == null || plots == null || bids ==null)
        //         throw new InvalidDataException("Forest is missing some information");
        //     return new Forest()
        //     {
        //         ForestGroup = forestGroup,
        //        // ForestryEnterprise = forestryEnterprise,
        //        // Plots = plots,
        //        // Bids = bids
        //     };
        // }
        
        public Forest NewForest(ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, ForestryEnterprise forestryEnterprise, List<Plot> plots)
        {
            if (forestGroup == null || forestLocation == null || forestUid == null || forestryEnterprise == null)
                throw new InvalidDataException("Forest is missing some information");
            return new Forest()
            {
                ForestUid = new ForestUid()
                {
                    FirstUid = new ForestUidFirst()
                    {
                        Id = forestUid.FirstUid.Id
                    },
                    SecondUid = new ForestUidSecond()
                    {
                        Id = forestUid.SecondUid.Id
                    },
                    ThirdUid = new ForestUidThird()
                    {
                        Id = forestUid.ThirdUid.Id
                    }
                },
                ForestGroup = new ForestGroup()
                {
                    Id = forestGroup.Id,
                },
                ForestLocation = new ForestLocation()
                {
                    GeoLocationX = forestLocation.GeoLocationX,
                    GeoLocationY = forestLocation.GeoLocationY
                },
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = forestryEnterprise.Id,
                },
                // Plots = new List<Plot>(),
                // Bids = new List<Bid>(),
                Plots = plots.Select(asd => new Plot()
                {
                   Id = asd.Id,
                   Volume = asd.Volume,
                   PlotResolution = asd.PlotResolution,
                   PlotSize = asd.PlotSize,
                   PlotTenderness = asd.PlotTenderness,
                   AverageTreeHeight = asd.AverageTreeHeight,
                   TreeTypes = asd.TreeTypes.Select(asdd =>new TreeType()
                   {
                           Percentage = new Percentage()
                           {
                               Id = asdd.Percentage.Id
                           },
                           Tree = new Tree()
                           {
                               Id = asdd.Tree.Id
                           }
                   }).ToList()
                }).ToList()
                // Bids = bids.Select(asd => new Bid()
                // {
                //     Id = asd.Id,
                //     BidAmount = asd.BidAmount,
                //     BidDateTime = asd.BidDateTime
                // }).ToList(),
            };
        }

        public Forest Create(Forest forest)
        {
            return _forestRepository.Create(forest);
        }

        public Forest Update(Forest forest)
        {
            return _forestRepository.Update(forest);
        }

        public Forest Delete(int id)
        {
            return _forestRepository.Delete(id);
        }

        public Forest UpdateForest(int id, ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, ForestryEnterprise forestryEnterprise, List<Plot> plots)
        {
            if (id < 1 ||  forestGroup == null || forestLocation == null || forestUid == null  || forestryEnterprise == null )
                throw new InvalidDataException("Forest is missing some information");
            return new Forest()
            {
                Id = id,
                ForestGroup = new ForestGroup()
                {
                    Id = forestGroup.Id,
                    Name = forestGroup.Name
                },
                ForestLocation = new ForestLocation()
                {
                    Id = forestLocation.Id,
                    GeoLocationX = forestLocation.GeoLocationX,
                    GeoLocationY = forestLocation.GeoLocationY
                },
                ForestUid = new ForestUid()
                {
                    Id = forestUid.Id,
                    FirstUid = forestUid.FirstUid,
                    SecondUid = forestUid.SecondUid,
                    ThirdUid = forestUid.ThirdUid
                },
                // Plots = new List<Plot>(),
                Bids = new List<Bid>(),
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = forestryEnterprise.Id,
                },
                Plots = plots.Select(asd => new Plot()
                {
                    Id = asd.Id,
                    Volume = asd.Volume,
                    PlotResolution = asd.PlotResolution,
                    PlotSize = asd.PlotSize,
                    PlotTenderness = asd.PlotTenderness,
                    AverageTreeHeight = asd.AverageTreeHeight,
                    TreeTypes = asd.TreeTypes.Select(asdd => new TreeType()
                    {
                        Id = asdd.Id,
                        Percentage = new Percentage()
                        {
                            Id = asdd.Percentage.Id,
                            Value = asdd.Percentage.Value
                        },
                        Tree = new Tree()
                        {
                            Id = asdd.Tree.Id,
                            Name = asdd.Tree.Name
                        }
                    }).ToList()
                }).ToList()
                // Bids = forestBids.Select(asd=>new Bid()
                // {
                //     Id = asd.Id,
                //     BidAmount = asd.BidAmount,
                //     BidDateTime = asd.BidDateTime
                // }).ToList(),
            };
            }
    }
}