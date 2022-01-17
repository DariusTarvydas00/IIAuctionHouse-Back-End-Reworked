using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestUid;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories.IForestUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestUidRepositories
{
    public class ForestSecondUidRepository: IForestSecondUidRepository
    {
        private readonly MainDbContext _ctx;

        public ForestSecondUidRepository(MainDbContext ctx)
        {
            _ctx = ctx;
            
        }

        public IEnumerable<ForestUidSecond> FindAll()
        {
            return _ctx.ForestUidSecondDbSet.OrderBy(sql => sql.Value).Select(f => new ForestUidSecond()
            {
                Id = f.Id,
                Value = f.Value,
            }).ToList();
        }

        public ForestUidSecond Create(ForestUidSecond forestUidSecond)
        {
            var second = _ctx.ForestUidSecondDbSet.FirstOrDefault(sql => sql.Value == forestUidSecond.Value);

            if (second != null)
            {
                throw new InvalidDataException("This First Uid already exists");
            }
            
            var entity = _ctx.ForestUidSecondDbSet.Add(new ForestUidSecondSql()
            {
                Value = forestUidSecond.Value,
            }).Entity;
            _ctx.SaveChanges();
            return new ForestUidSecond()
            {
                Id = entity.Id,
                Value = entity.Value,
            };
        }

        public ForestUidSecond Update(ForestUidSecond forestUidSecond)
        {
            var second = _ctx.ForestUidSecondDbSet.FirstOrDefault(sql => sql.Value == forestUidSecond.Value);

            if (second != null)
            {
                throw new InvalidDataException("This Second Uid already exists");
            }
            var newSecondUid = new ForestUidSecondSql()
            {
                Id = forestUidSecond.Id,
                Value = forestUidSecond.Value
            };
            _ctx.ForestUidSecondDbSet.Update(newSecondUid);
            _ctx.SaveChanges();
            return new ForestUidSecond()
            {
                Id = newSecondUid.Id,
                Value = newSecondUid.Value,
            };
        }

        public ForestUidSecond Delete(int id)
        {
            var entity = _ctx.ForestUidSecondDbSet.FirstOrDefault(tree => tree.Id == id);
            if (entity != null) _ctx.ForestUidSecondDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new ForestUidSecond()
            {
                Id = entity.Id,
                Value = entity.Value,
            }: null;
        }

    }
}