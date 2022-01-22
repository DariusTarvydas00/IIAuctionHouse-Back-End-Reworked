using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices.IGroupServices
{
    public interface ISubGroupService
    {
        List<SubGroup> GetAll();
        SubGroup GetById(int subGroupId);
    }
}