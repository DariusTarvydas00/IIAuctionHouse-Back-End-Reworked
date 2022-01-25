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
            return _ctx.GroupDbSet.Select(sql => new Group()
            {
                Id = sql.Id,
                ForestGroupName = sql.ForestGroupName
            }).FirstOrDefault(first => first.Id == groupId);
        }
    }
}