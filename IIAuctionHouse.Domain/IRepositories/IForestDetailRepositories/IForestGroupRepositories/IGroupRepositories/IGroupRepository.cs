using System.Collections.Generic;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;

namespace IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories
{
    public interface IGroupRepository
    {
        IEnumerable<Group> FindAll();
        Group GetById(int groupId);
    }
}