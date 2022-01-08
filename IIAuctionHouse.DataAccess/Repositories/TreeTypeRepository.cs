using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

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
            return _ctx.TreeTypeDbSet.Select(treeType => new TreeType()
            {
                Id = treeType.Id,
              //  Name = treeType.Name,
            }).ToList();
        }

        public TreeType GetById(int id)
        {
            var entity = _ctx.TreeTypeDbSet.Select(typeEntity => new TreeTypeSql()
            {
                Id = typeEntity.Id,
                TreeSql = _ctx.TreeDbSet.FirstOrDefault(sql => sql.Id == typeEntity.TreeSql.Id),
                PercentageSql = _ctx.PercentageDbSet.FirstOrDefault(sql => sql.Id == typeEntity.PercentageSql.Id)
            }).FirstOrDefault(type => type.Id == id);

            return new TreeType()
            {
                Id = entity.Id,
                Tree = new Tree()
                {
                    Id = entity.TreeSql.Id,
                    Name = entity.TreeSql.Name
                },
                Percentage = new Percentage()
                {
                    Id = entity.PercentageSql.Id,
                    Value = entity.PercentageSql.Value
                }
            };
        }

        public TreeType Create(TreeType treeType)
        {
            
            var entity = _ctx.TreeTypeDbSet.Add(new TreeTypeSql()
            {
                TreeSqlId = treeType.Tree.Id,
                PercentageSqlId = treeType.Percentage.Id,
            }).Entity;
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
                // Tree = new Tree()
                // {
                //     Id = entity.TreeSql.Id,
                //     Name = entity.TreeSql.Name
                // },
                // Percentage = new Percentage()
                // {
                //     Id = entity.PercentageSql.Id,
                //     Value = entity.PercentageSql.Value
                // }
            };
        }

        public TreeType Update(TreeType updateTreeType)
        {
            var entity = _ctx.TreeTypeDbSet.Update(new TreeTypeSql()
            {
                Id = updateTreeType.Id,
               // Name = updateTreeTypeType.Name
            }).Entity;
            _ctx.SaveChanges();
            return new TreeType()
            {
                Id = entity.Id,
              //  Name = entity.Name
            };
        }

        public TreeType Delete(int id)
        {
            var entity = _ctx.TreeTypeDbSet.FirstOrDefault(treeType => treeType.Id == id);
            if (entity != null) _ctx.TreeTypeDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new TreeType()
            {
                Id = entity.Id,
               // Name = entity.Name,
            }: null;
        }

    
    }
}