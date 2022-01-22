using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestGroupModels.GroupModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestGroupRepositories.IGroupRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestGroupRepositories
{
    public class SubGroupRepository: ISubGroupRepository
    {
        private readonly MainDbContext _ctx;

        public SubGroupRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException("Sub Group Repository Can Not Be Null");
        }

        public IEnumerable<SubGroup> FindAll()
        {
            return _ctx.SubGroupDbSet.OrderBy(sql => sql.ForestSubGroupName).Select(subGroup => new SubGroup()
            {
                Id = subGroup.Id,
                ForestSubGroupName = subGroup.ForestSubGroupName
            }).ToList();
        }

        public SubGroup GetById(int subGroupId)
        {
            var subGroup = _ctx.SubGroupDbSet.FirstOrDefault(sql => sql.Id == subGroupId);
            if (subGroup == null) return null;
            return new SubGroup()
            {
                Id = subGroup.Id,
                ForestSubGroupName = subGroup.ForestSubGroupName
            };
        }
    }
}