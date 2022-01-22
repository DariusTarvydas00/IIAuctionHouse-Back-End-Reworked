using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels;

namespace IIAuctionHouse.Core.IServices.IForestDetailServices.IForestGroupServices
{
    public interface IForestGroupSubGroupService
    {
        ForestGroupSubGroup GetForestGroupSubGroup(int groupId, int subGroupId);
    }
}