using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.Forest;
using IIAuctionHouse.DataAccess.Entities.ForestEntities;
using IIAuctionHouse.Domain.IRepositories.IForestRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestRepositories
{
    public class ForestRepository: IForestRepo
    {
        private readonly MainDbContext _ctx;

        public ForestRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Forest> FindAll()
        {
            return _ctx.Forests.Select(entity => new Forest()
            {
                Id = entity.Id,
                ForestLocation = entity.ForestLocationEntityForeignKey > 0 ? new ForestLocation()
                {
                    Id = entity.ForestLocationEntity.Id,
                    ForestryEnterprise = entity.ForestLocationEntity.ForestryEnterprise
                } : null,
                TreeGroup = entity.TreeGroupEntityForeignKey > 0 ? new TreeGroup() {
                    Id = entity.TreeGroupEntity.Id,
                    GroupOfTree = entity.TreeGroupEntity.GroupOfTree
                } : null,
                TreeType = entity.TreeTypeEntityForeignKey > 0 ? new TreeType()
                {
                    Id = entity.TreeTypeEntity.Id,
                    TypeOfTree = entity.TreeTypeEntity.TypeOfTree
                } : null
            }).ToList();
        }

        public Forest GetById(int id)
        {
            return _ctx.Forests.Select(entity => new Forest()
            {
                Id = entity.Id,
                ForestLocation = new ForestLocation()
                {
                    ForestryEnterprise = entity.ForestLocationEntity.ForestryEnterprise
                },
                TreeGroup = new TreeGroup() {
                    GroupOfTree = entity.TreeGroupEntity.GroupOfTree
                },
                TreeType = new TreeType()
                {
                    TypeOfTree = entity.TreeTypeEntity.TypeOfTree
                }
            }).FirstOrDefault(forest => forest.Id == id);
        }
        
        public Forest Create(Forest forest)
        {
            var entity = _ctx.Forests.Add(new ForestEntity()
            {
                ForestLocationEntity = new ForestLocationEntity()
                {
                    ForestryEnterprise = forest.ForestLocation.ForestryEnterprise
                },
                TreeGroupEntity = new TreeGroupEntity() {
                    GroupOfTree = forest.TreeGroup.GroupOfTree
                },
                TreeTypeEntity = new TreeTypeEntity()
                {
                    TypeOfTree = forest.TreeType.TypeOfTree
                }
            }).Entity;
            _ctx.SaveChanges();
            return new Forest()
            {
                Id = entity.Id,
                ForestLocation = new ForestLocation()
                {
                    ForestryEnterprise = entity.ForestLocationEntity.ForestryEnterprise
                },
                TreeGroup = new TreeGroup() {
                    GroupOfTree = entity.TreeGroupEntity.GroupOfTree
                },
                TreeType = new TreeType()
                {
                    TypeOfTree = entity.TreeTypeEntity.TypeOfTree
                }
            };
        }

        public Forest Update(Forest forest)
        {
            var entity = _ctx.Forests.Update(new ForestEntity()
            {
                Id = forest.Id,
                ForestLocationEntity = new ForestLocationEntity()
                {
                    Id = forest.ForestLocation.Id,
                    ForestryEnterprise = forest.ForestLocation.ForestryEnterprise
                },
                TreeGroupEntity = new TreeGroupEntity()
                {
                    Id = forest.TreeGroup.Id,
                    GroupOfTree = forest.TreeGroup.GroupOfTree,
                },
                TreeTypeEntity = new TreeTypeEntity()
                {
                    Id = forest.TreeType.Id,
                    TypeOfTree = forest.TreeType.TypeOfTree
                }
            }).Entity;
            _ctx.SaveChanges();
            return new Forest()
            {
                Id = entity.Id,
                ForestLocation = new ForestLocation()
                {
                    Id = entity.ForestLocationEntity.Id,
                    ForestryEnterprise = entity.ForestLocationEntity.ForestryEnterprise
                },
                TreeGroup = new TreeGroup()
                {
                    Id = entity.TreeGroupEntity.Id,
                    GroupOfTree = entity.TreeGroupEntity.GroupOfTree,
                },
                TreeType = new TreeType()
                {
                    Id = entity.TreeTypeEntity.Id,
                    TypeOfTree = entity.TreeTypeEntity.TypeOfTree
                }
            };
        }

        public Forest Delete(int id)
        {
            var entity = _ctx.Forests.Remove(new ForestEntity()
            {
                Id = id,
            }).Entity;
            _ctx.SaveChanges();
            return new Forest()
            {
                Id = entity.Id,
            };
        }
    }
}