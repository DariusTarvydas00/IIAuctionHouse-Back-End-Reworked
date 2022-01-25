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
            if (id < 1)
                throw new InvalidDataException("Invalid Forest Id");
            return _forestRepository.GetById(id);
        }

        public Forest Create(Forest forest)
        {
            if (forest == null)
                throw new InvalidDataException("Forest Cannot Be Null");
            return _forestRepository.Create(forest);
        }

        public Forest Update(Forest forest)
        {
            if (forest == null)
                throw new InvalidDataException("Forest Cannot Be Null");
            if (forest.Id < 1)
                throw new InvalidDataException("Invalid Forest Id");
            CheckId(forest);
            GetForestGroupSubGroup(forest.ForestGroupSubGroup);
            ValidateForestLocation(forest.ForestLocation);
            GetForestUid(forest.ForestUid);
            GetForestryEnterprise(forest.ForestryEnterprise);
            return _forestRepository.Update(forest);
        }

        private void CheckId(Forest forest)
        {
            if (forest.ForestGroupSubGroup.Id < 1)
                throw new InvalidDataException("Invalid Forest Group Id");
            if (forest.ForestGroupSubGroup.Group.Id < 1)
                throw new InvalidDataException("Invalid Group Id");
            if (forest.ForestGroupSubGroup.SubGroup.Id < 1)
                throw new InvalidDataException("Invalid Sub Group Id");
            if (forest.ForestLocation.Id < 1)
                throw new InvalidDataException("Invalid Forest Location Id");
            if (forest.ForestryEnterprise.Id < 1)
                throw new InvalidDataException("Invalid Forestry Enterprise Id");
            if (forest.ForestUid.Id < 1)
                throw new InvalidDataException("Invalid Forestry Enterprise Id");
            if (forest.ForestUid.FirstUid.Id < 1)
                throw new InvalidDataException("Invalid Forestry Enterprise Id");
            if (forest.ForestUid.SecondUid.Id < 1)
                throw new InvalidDataException("Invalid Forestry Enterprise Id");
            if (forest.ForestUid.ThirdUid.Id < 1)
                throw new InvalidDataException("Invalid Forestry Enterprise Id");
        }

        public Forest Delete(int id)
        {
            if (id < 1)
                throw new InvalidDataException("Invalid Forest Id");
            return _forestRepository.Delete(id);
        }

        public Forest NewForest(int id ,ForestGroupSubGroup forestGroupSubGroup, ForestLocation forestLocation, ForestUid forestUid,
            ForestryEnterprise forestryEnterprise)
        {
            if (id < 1)
                throw new InvalidDataException("Invalid Forest Id");
            ValidateForestLocation(forestLocation);
            CheckId(new Forest()
            {
                Id = id,
                ForestGroupSubGroup = forestGroupSubGroup,
                ForestLocation = forestLocation,
                ForestUid = forestUid,
                ForestryEnterprise = forestryEnterprise
            });
            return new Forest()
            {
                ForestGroupSubGroup =  GetForestGroupSubGroup(forestGroupSubGroup),
                ForestLocation = forestLocation,
                ForestUid = GetForestUid(forestUid),
                ForestryEnterprise =  GetForestryEnterprise(forestryEnterprise)
            };
        }

        public Forest NewForest(ForestGroupSubGroup forestGroupSubGroup, ForestLocation forestLocation,
            ForestUid forestUid, ForestryEnterprise forestryEnterprise)
        {
            ValidateForestLocation(forestLocation);
            return new Forest()
            {
                ForestGroupSubGroup =  GetForestGroupSubGroup(forestGroupSubGroup),
                ForestLocation = forestLocation,
                ForestUid = GetForestUid(forestUid),
                ForestryEnterprise =  GetForestryEnterprise(forestryEnterprise)
            };
        }

        private ForestryEnterprise GetForestryEnterprise(ForestryEnterprise forestryEnterprise)
        {
            if (forestryEnterprise == null) 
                throw new InvalidDataException("Forestry Enterprise can not be null");
            return _forestEnterpriseService.GetById(forestryEnterprise.Id);
        }

        private ForestUid GetForestUid(ForestUid forestUid)
        {
            if (forestUid == null) 
                throw new InvalidDataException("Forest Uid can not be null");
            if (forestUid.FirstUid == null) 
                throw new InvalidDataException("Forest First Uid can not be null");
            if (forestUid.SecondUid == null) 
                throw new InvalidDataException("Forest Second Uid can not be null");
            if (forestUid.ThirdUid == null) 
                throw new InvalidDataException("Forest Third Uid can not be null");
            return _forestUidService.GetForestUid(forestUid.FirstUid.Id,forestUid.SecondUid.Id,forestUid.ThirdUid.Id);
        }

        private void ValidateForestLocation(ForestLocation forestLocation)
        {
            if (forestLocation == null) 
                throw new InvalidDataException("Forest Location can not be null");
            if (forestLocation.GeoLocationX < 0.1) 
                throw new InvalidDataException("Invalid Forest Location X");
            if (forestLocation.GeoLocationY < 0.1) 
                throw new InvalidDataException("Invalid Forest Location Y");
        }

        private ForestGroupSubGroup GetForestGroupSubGroup(ForestGroupSubGroup forestGroupSubGroup)
        {
            if (forestGroupSubGroup == null) 
                throw new InvalidDataException("ForestGroup can not be null");
            if (forestGroupSubGroup.Group == null) 
                throw new InvalidDataException("Forest Group can not be null");
            if (forestGroupSubGroup.SubGroup == null) 
                throw new InvalidDataException("Forest Sub Group can not be null");
            return _forestGroupSubGroupService.GetForestGroupSubGroup(forestGroupSubGroup.Group.Id,forestGroupSubGroup.SubGroup.Id);
        }

    }
}