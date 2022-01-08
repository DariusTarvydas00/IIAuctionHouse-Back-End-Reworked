using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class TreeRepository: ITreeRepository
    {
        private readonly MainDbContext _ctx;

        public TreeRepository(MainDbContext ctx)
        {
            _ctx = ctx;
            
        }

        public IEnumerable<Tree> FindAll()
        {
            return _ctx.TreeDbSet.Select(tree => new Tree()
            {
                Id = tree.Id,
                Name = tree.Name,
            }).ToList();
        }

        public Tree Create(Tree tree)
        {
            
            var entity = _ctx.TreeDbSet.Add(new TreeSql()
            {
                Name = tree.Name,
            }).Entity;
            _ctx.SaveChanges();
            return new Tree()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public Tree Update(Tree updateTree)
        {
            var entity = _ctx.TreeDbSet.Update(new TreeSql()
            {
                Id = updateTree.Id,
                Name = updateTree.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Tree()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Tree Delete(int id)
        {
            var entity = _ctx.TreeDbSet.FirstOrDefault(tree => tree.Id == id);
            if (entity != null) _ctx.TreeDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new Tree()
            {
                Id = entity.Id,
                Name = entity.Name,
            }: null;
        }

    }
}