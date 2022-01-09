using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models;
using IIAuctionHouse.DataAccess.Entities;
using IIAuctionHouse.Domain.IRepositories;

namespace IIAuctionHouse.DataAccess.Repositories
{
    public class PercentageRepository : IPercentageRepository
    {
        private readonly MainDbContext _ctx;

        public PercentageRepository(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Percentage> FindAll()
        {
            return _ctx.PercentageDbSet.OrderBy(sql => sql.Value).Select(percentage => new Percentage()
            {
                Id = percentage.Id,
                Value = percentage.Value
            }).ToList();
        }

        public Percentage Create(Percentage percentage)
        {
            var newPercentage = _ctx.PercentageDbSet.Add(new PercentageSql()
            {
                Value = percentage.Value
            }).Entity;
            _ctx.SaveChanges();
            return new Percentage()
            {
                Id = newPercentage.Id,
                Value = newPercentage.Value
            };
        }

        public Percentage Update(Percentage percentage)
        {
            var percentageSql = new PercentageSql()
            {
                Id = percentage.Id,
                Value = percentage.Value
            };
            _ctx.PercentageDbSet.Update(percentageSql);
            _ctx.SaveChanges();
            return new Percentage()
            {
                Id = percentageSql.Id,
                Value = percentageSql.Value
            };
        }

        public Percentage Delete(int id)
        {
            var entity = _ctx.PercentageDbSet.FirstOrDefault(percentage => percentage.Id == id);
            if (entity != null) _ctx.PercentageDbSet.Remove(entity);
            _ctx.SaveChanges();
            return entity != null ? new Percentage()
            {
                Id = entity.Id,
                Value = entity.Value
            } : null;
        }
    }
}