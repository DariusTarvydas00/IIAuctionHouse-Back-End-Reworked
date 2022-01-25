using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestGroupServices.GroupServices
{
    public class GroupService: IGroupService
    {
        private readonly IGroupRepository _groupRepository;

        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ?? throw new NullReferenceException("Group Repository Can Not Be Null");
        }

        public List<Group> GetAll()
        {
            return _groupRepository.FindAll().ToList();
        }

        public Group GetById(int groupId)
        {
            if (groupId < 1)
                throw new Exception("Group Id Can Not Be Less Than 1");
            return _groupRepository.GetById(groupId);
        }
        
    }
}