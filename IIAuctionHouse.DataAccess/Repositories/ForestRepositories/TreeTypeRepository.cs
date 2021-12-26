using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestRepositories
{
    public class TreeTypeRepository: ITreeTypeRepo
    {
        private readonly MainDbContext _ctx;

        public TreeTypeRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TreeType> FindAll()
        {
            return _ctx.TreeTypes.Select(ae => new TreeType()
            {
                Id = ae.Id,
                TypeOfTree = ae.TypeOfTree
            }).ToList();
        }

        public TreeType GetById(int id)
        {
            return _ctx.TreeTypes.Select(ae => new TreeType()
            {
                Id = ae.Id,
                TypeOfTree = ae.TypeOfTree
            }).FirstOrDefault(e => e.Id == id);
        }

        public TreeType Create(string typeOfTree)
        {
            var entity = _ctx.TreeTypes.Add(new TreeTypeEntity()
            {
                TypeOfTree = typeOfTree
            }).Entity;
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
                TypeOfTree = entity.TypeOfTree
            };
        }

        public TreeType Update(TreeType typeOfTree)
        {
            var entity = _ctx.TreeTypes.Update(new TreeTypeEntity()
            {
                TypeOfTree = typeOfTree.TypeOfTree
            }).Entity;
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
                TypeOfTree = entity.TypeOfTree
            };
        }

        public TreeType Delete(int id)
        {
            var entity = _ctx.TreeTypes.Remove(new TreeTypeEntity()
            {
                Id = id
            }).Entity;
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
                TypeOfTree = entity.TypeOfTree
            };
        }
    }
}