using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.ForestUidEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories
{
    public class ForestFirstUidRepository: IForestFirstUidRepository
    {
        private readonly MainDbContext _ctx;

        public ForestFirstUidRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            
        }

        public IEnumerable<ForestUidFirst> FindAll()
        {
            return _ctx.ForestUidFirstDbSet.OrderBy(sql => sql.Value).Select(f => new ForestUidFirst()
            {
                Id = f.Id,
                Value = f.Value,
            }).ToList();
        }

        public ForestUidFirst Create(ForestUidFirst forestUidFirst)
        {
            var first = _ctx.ForestUidFirstDbSet.FirstOrDefault(sql => sql.Value == forestUidFirst.Value);

            if (first != null)
            {
                throw new InvalidDataException(DataAccessExceptions.Exists);
            }
            var entity = _ctx.ForestUidFirstDbSet.Add(new ForestUidFirstSql()
            {
                Value = forestUidFirst.Value,
            }).Entity;
            _ctx.SaveChanges();
            return new ForestUidFirst()
            {
                Id = entity.Id,
                Value = entity.Value,
            };
        }

        public ForestUidFirst Update(ForestUidFirst forestUidFirst)
        {
            var second = _ctx.ForestUidFirstDbSet.FirstOrDefault(sql => sql.Value == forestUidFirst.Value);

            if (second != null)
            {
                throw new InvalidDataException(DataAccessExceptions.Exists);
            }
            var newFirstUid = new ForestUidFirstSql()
            {
                Id = forestUidFirst.Id,
                Value = forestUidFirst.Value
            };
            _ctx.ForestUidFirstDbSet.Update(newFirstUid);
            _ctx.SaveChanges();
            return new ForestUidFirst()
            {
                Id = newFirstUid.Id,
                Value = newFirstUid.Value,
            };
        }

        public ForestUidFirst Delete(int id)
        {
            var entity = _ctx.ForestUidFirstDbSet.FirstOrDefault(tree => tree.Id == id);
            if (entity != null) _ctx.ForestUidFirstDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new ForestUidFirst()
            {
                Id = entity.Id,
                Value = entity.Value,
            }: null;
        }

    }
}