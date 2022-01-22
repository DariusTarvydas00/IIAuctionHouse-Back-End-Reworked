using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestGroupServices.GroupServices
{
    public class SubGroupService: ISubGroupService
    {
        private readonly ISubGroupRepository _subGroupRepository;

        public SubGroupService(ISubGroupRepository subGroupRepository)
        {
            _subGroupRepository = subGroupRepository ?? throw new NullReferenceException("Sub Group Repository Can Not Be Null");
        }

        public List<SubGroup> GetAll()
        {
            return _subGroupRepository.FindAll().ToList();
        }

        public SubGroup GetById(int subGroupId)
        {
            CheckId(subGroupId);
            return _subGroupRepository.GetById(subGroupId);
        }
        
        private void CheckId(int id)
        {
            if (id < 1)
                throw new Exception("Sub Group Id Can Not Be Less Than 1");
        }
    }
}