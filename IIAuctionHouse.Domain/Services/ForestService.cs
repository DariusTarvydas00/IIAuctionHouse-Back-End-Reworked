using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.IServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IEachUidServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.Core.Models.ForestDetailModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.Domain.Services
{
    public class ForestService: IForestService
    {
        private readonly IForestRepository _forestRepository;
        private readonly IForestGroupSubGroupService _forestGroupSubGroupService;
        private readonly IForestEnterpriseService _forestEnterpriseService;
        private readonly IForestUidService _forestUidService;

        public ForestService(IForestRepository forestRepository, 
            IForestGroupSubGroupService forestGroupSubGroupService, 
            IForestEnterpriseService forestEnterpriseService, IForestUidService forestUidService)
        {
            _forestRepository = forestRepository ?? throw new NullReferenceException("Forest Repository Can Not Be Null");
            _forestGroupSubGroupService = forestGroupSubGroupService ?? throw new NullReferenceException("Forest Group Service Can Not Be Null");
            _forestEnterpriseService = forestEnterpriseService ?? throw new NullReferenceException("Forestry Enterprise Service Can Not Be Null");
            _forestUidService = forestUidService ?? throw new NullReferenceException("Forestry Uid Service Can Not Be Null");
        }

        public List<Forest> GetAll()
        {
            return _forestRepository.FindAll().ToList();
        }

        public Forest GetById(int id)
        {
            CheckId(id);
            return _forestRepository.GetById(id);
        }

        public Forest Create(Forest forest)
        {
            CheckIfNull(forest);
            ValidateForestValues(forest.ForestGroupSubGroup, forest.ForestLocation, forest.ForestUid, forest.ForestryEnterprise);
            return _forestRepository.Create(forest);
        }

        public Forest Update(Forest forest)
        {
            CheckIfNull(forest);
            CheckId(forest.Id);
            ValidateForestValues(forest.ForestGroupSubGroup, forest.ForestLocation, forest.ForestUid, forest.ForestryEnterprise);
            ValidateForestAllIds(forest.ForestGroupSubGroup, forest.ForestLocation, forest.ForestUid, forest.ForestryEnterprise);
            return _forestRepository.Update(forest);
        }

        public Forest Delete(int id)
        {
            CheckId(id);
            return _forestRepository.Delete(id);
        }

        public Forest NewForest(int id ,ForestGroupSubGroup forestGroupSubGroup, ForestLocation forestLocation, ForestUid forestUid,
            ForestryEnterprise forestryEnterprise)
        {
            ValidateForestValues(forestGroupSubGroup, forestLocation, forestUid, forestryEnterprise);
            return new Forest()
            {
                Id = id,
                ForestGroupSubGroup = _forestGroupSubGroupService.GetForestGroupSubGroup(forestGroupSubGroup.Group.Id, forestGroupSubGroup.SubGroup.Id),
                ForestLocation = new ForestLocation()
                {
                    Id = forestLocation.Id,
                    GeoLocationX = forestLocation.GeoLocationX,
                    GeoLocationY = forestLocation.GeoLocationY
                },
                ForestryEnterprise = _forestEnterpriseService.GetById(forestryEnterprise.Id),
                ForestUid = _forestUidService.GetForestUid(forestUid.FirstUid.Id,forestUid.SecondUid.Id,forestUid.ThirdUid.Id)
            };
        }

        private void ValidateForestAllIds(ForestGroupSubGroup forestGroupSubGroup, ForestLocation forestLocation, ForestUid forestUid, ForestryEnterprise forestryEnterprise)
        {
            Console.WriteLine(forestGroupSubGroup.SubGroup.Id +" "+ forestGroupSubGroup.Group.Id+ " "+ forestLocation.Id + " " +forestryEnterprise.Id);
            if (forestGroupSubGroup.SubGroup.Id < 1 || forestGroupSubGroup.Group.Id < 1 || forestLocation.Id < 1 || forestryEnterprise.Id < 1 || forestUid.FirstUid.Id < 1
                || forestUid.SecondUid.Id < 1 || forestUid.ThirdUid.Id < 1)
                throw new InvalidDataException("Invalid Some Forest value Ids");
        }

        private void CheckId(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Invalid Forest Id");
        }

        private void CheckIfNull(Forest forest)
        {
            if (forest == null)
                throw new InvalidDataException("Forest Cannot Be Null");
        }
        
        
        
        private void ValidateForestValues(ForestGroupSubGroup forestGroupSubGroup, ForestLocation forestLocation, ForestUid forestUid, ForestryEnterprise forestryEnterprise)
        {
            if (forestGroupSubGroup == null || forestLocation == null || forestUid == null || forestryEnterprise == null)
                throw new InvalidDataException("Some Of Forest Values Are Empty");
            if (forestLocation.GeoLocationX < 0.1 || forestLocation.GeoLocationY < 0.1)
            {
                throw new InvalidDataException("Invalid Forest Location");
            }
        }
    }
}