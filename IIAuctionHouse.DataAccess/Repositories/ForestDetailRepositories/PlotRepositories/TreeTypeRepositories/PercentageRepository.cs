using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.PlotDetailModels.TreeTypeModels;
using IIAuctionHouse.DataAccess.Entities.ForestDetailEntities.PlotEntities.TreeTypeEntities;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IPlotDetailRepositories.ITreeTypeRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.PlotRepositories.TreeTypeRepositories
{
    public class PercentageRepository : IPercentageRepository
    {
        private readonly MainDbContext _ctx;

        public PercentageRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
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
            var check =_ctx.PercentageDbSet.SingleOrDefault(sql => sql.Id == percentage.Id);
            if (check != null)
            {
                _ctx.PercentageDbSet.Update(percentageSql);
            }
            else
            {
                _ctx.PercentageDbSet.Add(percentageSql);
            }
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