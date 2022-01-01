using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailsRepositories
{
    public class TreeTypeRepository: ITreeTypeRepository
    {
        private readonly MainDbContext _ctx;

        public TreeTypeRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TreeType> FindAll()
        {
            return _ctx.TreeTypeEntities.Select(ae => new TreeType()
            {
                Id = ae.Id,
                Name = ae.Name,
                Percentage = ae.Percentage
            }).ToList();
        }

        public TreeType GetById(int id)
        {
            var entity = _ctx.TreeTypeEntities.FirstOrDefault(s=>s.Id == id);
            var treeType = ConvertToObject(entity);
            return treeType;
        }

        public TreeType Create(TreeType treeType)
        {
            var entity = ConvertToEntity(treeType);
            _ctx.TreeTypeEntities.Add(entity);
            _ctx.SaveChanges();
            return treeType;
        }

        public TreeType Update(TreeType treeType)
        {
            var ent = ConvertToEntity(treeType);
            _ctx.TreeTypeEntities.Update(ent);
            _ctx.SaveChanges();
            return treeType;
        }

        public TreeType Delete(int id)
        {
            var entity = _ctx.TreeTypeEntities.FirstOrDefault(ae => ae.Id == id);
            var deletedTreeType = ConvertToObject(entity);
            if (entity != null) _ctx.TreeTypeEntities.Remove(entity);
            _ctx.SaveChanges();
            return deletedTreeType;
        }

        private TreeType ConvertToObject(TreeTypeEntity treeTypeEntity)
        {
            return new TreeType()
            {
                Id = treeTypeEntity.Id,
                Name = treeTypeEntity.Name,
                Percentage = treeTypeEntity.Percentage
            };
        }
        
        private TreeTypeEntity ConvertToEntity(TreeType treeType)
        {
            return new TreeTypeEntity()
            {
                Id = treeType.Id,
                Name = treeType.Name,
                Percentage = treeType.Percentage
            };
        }
    }
}