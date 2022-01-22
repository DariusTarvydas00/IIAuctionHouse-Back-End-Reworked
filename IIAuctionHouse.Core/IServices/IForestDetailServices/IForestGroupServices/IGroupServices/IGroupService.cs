using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices
{
    public interface IGroupService
    {
        List<Group> GetAll();
        Group GetById(int groupId);
    }
}