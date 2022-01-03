using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace IIAuctionHouse.DataAccess.Repositories
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
            return _ctx.TreeTypeEntities
                .Include(tt=>tt.PercentageEntity)
                .Select(treeType => new TreeType()
            {
                Id = treeType.Id,
                Name = treeType.Name,
                Percentage = treeType.Percentage == null | treeType.Percentage < 1 ? null : new Percentage()
                {
                    Id = treeType.PercentageEntity.Id,
                    PercentageValue = treeType.PercentageEntity.PercentageEntityValue
                }
            }).ToList();
        }

        public TreeType GetById(int id)
        {
            return _ctx.TreeTypeEntities.Select(entity => new TreeType()
            {
                Id = entity.Id,
                Name = entity.Name,
                Percentage = new Percentage()
                {
                    Id = entity.PercentageEntity.Id,
                    PercentageValue = entity.PercentageEntity.PercentageEntityValue
                }
            }).FirstOrDefault(treeType => treeType.Id == id);
        }

        public TreeType Create(TreeType treeType)
        {
            var entity = _ctx.TreeTypeEntities.Add(new TreeTypeEntity()
            {
                Name = treeType.Name
            }).Entity;
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public TreeType Update(TreeType updateTreeType)
        {
            var entity = _ctx.TreeTypeEntities.Update(new TreeTypeEntity()
            {
                Id = updateTreeType.Id,
                Name = updateTreeType.Name,
                PercentageEntityId = updateTreeType.Percentage.Id
            }).Entity;
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public TreeType Delete(int id)
        {
            var entity = _ctx.TreeTypeEntities.FirstOrDefault(treeType => treeType.Id == id);
            if (entity != null) _ctx.TreeTypeEntities.Remove(entity);
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

    }
}