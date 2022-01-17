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
    public class ForestThirdUidRepository : IForestThirdUidRepository
    {
        private readonly MainDbContext _ctx;

        public ForestThirdUidRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);

        }

        public IEnumerable<ForestUidThird> FindAll()
        {
            return _ctx.ForestUidThirdDbSet.OrderBy(sql => sql.Value).Select(f => new ForestUidThird()
            {
                Id = f.Id,
                Value = f.Value,
            }).ToList();
        }

        public ForestUidThird Create(ForestUidThird forestUidThird)
        {
            var second = _ctx.ForestUidThirdDbSet.FirstOrDefault(sql => sql.Value == forestUidThird.Value);

            if (second != null)
            {
                throw new InvalidDataException(DataAccessExceptions.Exists);
            }
            var entity = _ctx.ForestUidThirdDbSet.Add(new ForestUidThirdSql()
            {
                Value = forestUidThird.Value,
            }).Entity;
            _ctx.SaveChanges();
            return new ForestUidThird()
            {
                Id = entity.Id,
                Value = entity.Value,
            };
        }

        public ForestUidThird Update(ForestUidThird forestUidThird)
        {
            var second = _ctx.ForestUidThirdDbSet.FirstOrDefault(sql => sql.Value == forestUidThird.Value);

            if (second != null)
            {
                throw new InvalidDataException(DataAccessExceptions.Exists);
            }
            var newThirdUid = new ForestUidThirdSql()
            {
                Id = forestUidThird.Id,
                Value = forestUidThird.Value
            };
            _ctx.ForestUidThirdDbSet.Update(newThirdUid);
            _ctx.SaveChanges();
            return new ForestUidThird()
            {
                Id = newThirdUid.Id,
                Value = newThirdUid.Value,
            };
        }

        public ForestUidThird Delete(int id)
        {
            var entity = _ctx.ForestUidThirdDbSet.FirstOrDefault(tree => tree.Id == id);
            if (entity != null) _ctx.ForestUidThirdDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null
                ? new ForestUidThird()
                {
                    Id = entity.Id,
                    Value = entity.Value,
                }
                : null;
        }

    }
}