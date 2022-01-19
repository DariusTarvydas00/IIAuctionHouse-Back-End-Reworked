using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.Domain.IRepositories;
using IIAuctionHouse.Domain.ServiceExceptions;

namespace IIAuctionHouse.Domain.Services
{
    public class ForestService: IForestService
    {
        private readonly IForestRepository _forestRepository;

        public ForestService(IForestRepository forestRepository)
        {
            _forestRepository = forestRepository ?? throw new NullReferenceException(ServicesExceptions.NullRepository);
        }

        public List<Forest> GetAll()
        {
            return _forestRepository.FindAll().ToList();
        }

        public Forest GetById(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestRepository.GetById(id);
        }
        
        public Forest NewForest(ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, ForestryEnterprise forestryEnterprise, User user)
        {
            if (forestGroup == null || forestLocation == null || forestUid == null || forestryEnterprise == null || user == null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
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
                User = new User()
                {
                    Id = user.Id
                }
            };
        }

        public Forest Create(Forest forest)
        {
            if (forest ==null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestRepository.Create(forest);
        }

        public Forest Update(Forest forest)
        {
            if (forest ==null)
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
            return _forestRepository.Update(forest);
        }

        public Forest Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return _forestRepository.Delete(id);
        }

        public Forest UpdateForest(int id, ForestUid forestUid, ForestGroup forestGroup, ForestLocation forestLocation, ForestryEnterprise forestryEnterprise, User user)
        {
            if (id < 1 ||  forestGroup == null || forestLocation == null || forestUid == null  || forestryEnterprise == null || user == null )
                throw new InvalidDataException(ServicesExceptions.MissingInformation);
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
                ForestryEnterprise = new ForestryEnterprise()
                {
                    Id = forestryEnterprise.Id,
                },
                User = new User()
                {
                    Id = user.Id
                }
            };
        }

        public Forest NewForestCheck(int id)
        {
            if (id < 1)
                throw new InvalidDataException(ServicesExceptions.InvalidId);
            return new Forest()
            {
                Id = id
            };
        }
    }
}