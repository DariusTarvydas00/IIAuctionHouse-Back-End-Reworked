using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestRepositories
{
    public class TreeGroupRepository : ITreeGroupRepo
    {
        private readonly MainDbContext _ctx;

        public TreeGroupRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TreeGroup> FindAll()
        {
            return _ctx.TreeGroups.Select(entity => new TreeGroup()
            {
                Id = entity.Id,
                GroupOfTree = entity.GroupOfTree
            }).ToList();
        }

        public TreeGroup GetById(int id)
        {
            return _ctx.TreeGroups.Select(entity =>  new TreeGroup()
            {
                Id = entity.Id,
                GroupOfTree = entity.GroupOfTree
            }).FirstOrDefault(e => e.Id == id);
        }

        public TreeGroup Create(string groupOfTree)
        {
            var entity = _ctx.TreeGroups.Add(new TreeGroupEntity()
            {
                GroupOfTree = groupOfTree
            }).Entity;
            _ctx.SaveChanges();
            return new TreeGroup()
            {
                Id = entity.Id,
                GroupOfTree = entity.GroupOfTree
            };
        }

        public TreeGroup Update(TreeGroup groupOfTree)
        {
            var entity = _ctx.TreeGroups.Update(new TreeGroupEntity()
            {
                GroupOfTree = groupOfTree.GroupOfTree
            }).Entity;
            _ctx.SaveChanges();
                return new TreeGroup()
                {
                    Id = entity.Id,
                    GroupOfTree = entity.GroupOfTree
                };
        }

        public TreeGroup Delete(int id)
        {
            var entity = _ctx.TreeGroups.Remove(new TreeGroupEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new TreeGroup()
            {
                Id = entity.Id,
                GroupOfTree = entity.GroupOfTree
            };
        }
    }
}