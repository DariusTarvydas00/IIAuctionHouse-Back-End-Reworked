using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories.IForestUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestUidRepositories
{
    public class ForestThirdUidRepository : IForestThirdUidRepository
    {
        private readonly MainDbContext _ctx;

        public ForestThirdUidRepository(MainDbContext ctx)
        {
            _ctx = ctx;

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
                throw new InvalidDataException("This First Uid already exists");
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
                throw new InvalidDataException("This Third Uid already exists");
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