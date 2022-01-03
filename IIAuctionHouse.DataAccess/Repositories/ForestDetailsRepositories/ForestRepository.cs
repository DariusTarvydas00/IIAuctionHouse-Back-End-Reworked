using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailsRepositories
{
    public class ForestRepository: IForestRepository
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
                ForestGroup = entity.ForestGroup,
                // ForestLocation = entity.ForestLocationEntityForeignKey > 0 ? new ForestLocation()
                // {
                //     Id = entity.ForestLocationEntity.Id,
                //     ForestryEnterprise = entity.ForestLocationEntity.ForestryEnterprise
                // } : null,
                // Contingent = entity.TreeGroupEntityForeignKey > 0 ? new Contingent() {
                //     Id = entity.TreeGroupEntity.Id,
                //     ForestGroup = entity.TreeGroupEntity.GroupOfTree
                // } : null,
                // TreeType = entity.TreeTypeEntityForeignKey > 0 ? new TreeType()
                // {
                //     Id = entity.TreeTypeEntity.Id,
                //     TypeOfTree = entity.TreeTypeEntity.TypeOfTree
                // } : null
            }).ToList();
        }

        public Forest GetById(int id)
        {
            throw new NotImplementedException();
            // return _ctx.Forests.Select(entity => new Forest()
            // {
            //     Id = entity.Id,
            //     ForestLocation = new ForestLocation()
            //     {
            //         ForestryEnterprise = entity.ForestLocationEntity.ForestryEnterprise
            //     },
            //     Contingent = new Contingent() {
            //         ForestGroup = entity.TreeGroupEntity.GroupOfTree
            //     },
            //     TreeType = new TreeType()
            //     {
            //         TypeOfTree = entity.TreeTypeEntity.TypeOfTree
            //     }
            // }).FirstOrDefault(forest => forest.Id == id);
        }
        
        public Forest Create(Forest forest)
        {
            var entity = _ctx.Forests.Add(new ForestEntity()
            {
            }).Entity;
            _ctx.SaveChanges();
            return new Forest()
            {
                Id = entity.Id,
               // TreeType = new TreeType()
               // {
                   // TypeOfTree = entity.TreeTypeEntity.TypeOfTree
               // }
            };
        }

        public Forest Update(Forest forest)
        {
            var entity = _ctx.Forests.Update(new ForestEntity()
            {
                Id = forest.Id,
                ForestGroup = forest.ForestGroup,
            }).Entity;
            _ctx.SaveChanges();
            return new Forest()
            {
                Id = entity.Id,
            //     TreeType = new TreeType()
            //     {
            //         Id = entity.TreeTypeEntity.Id,
            //         TypeOfTree = entity.TreeTypeEntity.TypeOfTree
            //     }
             };
        }

        public Forest Delete(int id)
        {
            var delete = GetById(id);
            var deletedForest = new Forest()
            {
                Id = delete.Id,
                ForestGroup = delete.ForestGroup,

            };
            _ctx.Remove(delete);
            _ctx.SaveChanges();
            return deletedForest;
        }
    }
}