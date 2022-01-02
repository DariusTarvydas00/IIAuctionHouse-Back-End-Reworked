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
            return _ctx.PercentageEntities.Select(percentage => new Percentage()
            {
                Id = percentage.Id,
                PercentageValue = percentage.PercentageEntityValue
            }).ToList();
        }

        public Percentage GetById(int id)
        {
            return _ctx.PercentageEntities.Select(percentage => new Percentage()
            {
                Id = percentage.Id,
                PercentageValue = percentage.PercentageEntityValue
            }).FirstOrDefault(pId => pId.Id == id);
        }

        public Percentage Create(Percentage percentage)
        {
            var newPercentage = _ctx.PercentageEntities.Add(new PercentageEntity()
            {
                PercentageEntityValue = percentage.PercentageValue
            }).Entity;
            _ctx.SaveChanges();
            return new Percentage()
            {
                Id = newPercentage.Id,
                PercentageValue = newPercentage.PercentageEntityValue
            };
        }

        public Percentage Update(Percentage percentage)
        {
            var entity = _ctx.PercentageEntities.Update(new PercentageEntity()
            {
                Id = percentage.Id,
                PercentageEntityValue = percentage.PercentageValue
            }).Entity;
            _ctx.SaveChanges();
            return new Percentage()
            {
                Id = entity.Id,
                PercentageValue = entity.PercentageEntityValue
            };
        }

        public Percentage Delete(int id)
        {
            var entity = _ctx.PercentageEntities.FirstOrDefault(percentage => percentage.Id == id);
            if (entity != null) _ctx.PercentageEntities.Remove(entity);
            _ctx.SaveChanges();
            return new Percentage()
            {
                Id = entity.Id,
                PercentageValue = entity.PercentageEntityValue
            };
        }
    }
}