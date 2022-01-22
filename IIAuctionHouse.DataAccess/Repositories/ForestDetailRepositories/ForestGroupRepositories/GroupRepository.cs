using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestGroupRepositories
{
    public class GroupRepository: IGroupRepository
    {
        private readonly MainDbContext _ctx;

        public GroupRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException("Group Repository Can Not Be Null");
        }

        public IEnumerable<Group> FindAll()
        {
            return _ctx.GroupDbSet.OrderBy(sql => sql.ForestGroupName).Select(forestGroup => new Group()
            {
                Id = forestGroup.Id,
                ForestGroupName = forestGroup.ForestGroupName,
            }).ToList();
        }

        public Group GetById(int groupId)
        {
            var group = _ctx.GroupDbSet.FirstOrDefault(sql => sql.Id == groupId);
            if (group == null) return null;
            return new Group()
            {
                Id = group.Id,
                ForestGroupName = group.ForestGroupName
            };
        }
    }
}