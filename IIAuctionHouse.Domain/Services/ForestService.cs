using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
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
        
        public Forest NewForest(ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, List<Plot> plots, List<Bid> bids, ForestryEnterprise forestryEnterprise)
        {
            if (forestGroup == null || forestLocation == null || forestUid == null || plots == null || forestryEnterprise == null)
                throw new InvalidDataException("Forest is missing some information");
            return new Forest()
            {
                ForestUid = new ForestUid()
                {
                    FirstUid = forestUid.FirstUid,
                    SecondUid = forestUid.SecondUid,
                    ThirdUid = forestUid.ThirdUid
                },
                ForestGroup = new ForestGroup()
                {
                    Name = forestGroup.Name
                },
                ForestLocation = new ForestLocation()
                {
                    GeoLocationX = forestLocation.GeoLocationX,
                    GeoLocationY = forestLocation.GeoLocationY
                },
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
                }).ToList(),
                Bids = bids.Select(asd => new Bid()
                {
                    Id = asd.Id,
                    BidAmount = asd.BidAmount,
                    BidDateTime = asd.BidDateTime
                }).ToList(),
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = forestryEnterprise.Id,
                    Name = forestryEnterprise.Name
                }
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

        public Forest UpdateForest(int id, ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, List<Plot> plots, List<Bid> forestBids, ForestryEnterprise forestryEnterprise)
        {
            if (id < 1 ||  forestGroup == null || forestLocation == null || forestUid == null  || plots == null || forestBids == null || forestryEnterprise == null)
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
                }).ToList(),
                Bids = forestBids.Select(asd=>new Bid()
                {
                    Id = asd.Id,
                    BidAmount = asd.BidAmount,
                    BidDateTime = asd.BidDateTime
                }).ToList(),
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = forestryEnterprise.Id,
                    Name = forestryEnterprise.Name
                }
            };
        }
    }
}