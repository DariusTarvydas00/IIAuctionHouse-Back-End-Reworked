using System;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices;
using IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels;

namespace IIAuctionHouse.Domain.Services.ForestDetailServices.ForestGroupServices
{
    public class ForestGroupSubGroupService: IForestGroupSubGroupService
    {
        private readonly IGroupService _groupService;
        private readonly ISubGroupService _subGroupService;

        public ForestGroupSubGroupService(IGroupService groupService,ISubGroupService subGroupService)
        {
            _groupService = groupService ?? throw new NullReferenceException("Group Repository Can Not Be Null");
            _subGroupService = subGroupService ?? throw new NullReferenceException("Sub Group Repository Can Not Be Null");
        }

        public ForestGroupSubGroup GetForestGroupSubGroup(int groupId, int subGroupId)
        {
            var group = _groupService.GetById(groupId);
            var subGroup = _subGroupService.GetById(subGroupId);
            if (group != null || subGroup != null)
            {
                return new ForestGroupSubGroup()
                {
                    Group = group,
                    SubGroup = subGroup
                };
                
            }
            return null;

        }
    }
}