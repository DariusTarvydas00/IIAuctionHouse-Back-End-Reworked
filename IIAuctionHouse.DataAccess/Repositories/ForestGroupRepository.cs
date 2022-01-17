using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class ForestGroupRepository: IForestGroupRepository
    {
        private readonly MainDbContext _ctx;

        public ForestGroupRepository(MainDbContext ctx)
        {
            _ctx = ctx;
            
        }

        public IEnumerable<ForestGroup> FindAll()
        {
            return _ctx.ForestGroupDbSet.OrderBy(sql => sql.Name).Select(forestGroup => new ForestGroup()
            {
                Id = forestGroup.Id,
                Name = forestGroup.Name,
            }).ToList();
        }

        public ForestGroup Create(ForestGroup forestGroup)
        {
            
            var entity = _ctx.ForestGroupDbSet.Add(new ForestGroupSql()
            {
                Id = forestGroup.Id,
                Name = forestGroup.Name,
            }).Entity;
            _ctx.SaveChanges();
            return new ForestGroup()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public ForestGroup Update(ForestGroup updateForestGroup)
        {
            var newForestGroup = new ForestGroupSql()
            {
                Id = updateForestGroup.Id,
                Name = updateForestGroup.Name
            };
            _ctx.ForestGroupDbSet.Update(newForestGroup);
            _ctx.SaveChanges();
            return new ForestGroup()
            {
                Id = newForestGroup.Id,
                Name = newForestGroup.Name
            };
        }

        public ForestGroup Delete(int id)
        {
            var entity = _ctx.ForestGroupDbSet.FirstOrDefault(forestGroup => forestGroup.Id == id);
            if (entity != null) _ctx.ForestGroupDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new ForestGroup()
            {
                Id = entity.Id,
                Name = entity.Name,
            }: null;
        }

    }
}