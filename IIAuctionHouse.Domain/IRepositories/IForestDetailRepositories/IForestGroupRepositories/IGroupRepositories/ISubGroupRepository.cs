using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories
{
    public interface ISubGroupRepository
    {
        IEnumerable<SubGroup> FindAll();
        SubGroup GetById(int subGroupId);
    }
}