using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories.EachUidRepositories
{
    public class ForestSecondUidRepository : IForestSecondUidRepository
    {
        private readonly MainDbContext _ctx;

        public ForestSecondUidRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);

        }

        public IEnumerable<ForestUidSecond> FindAll()
        {
            return _ctx.ForestUidSecondDbSet.OrderBy(sql => sql.Value).Select(sql => new ForestUidSecond()
            {
                Id = sql.Id,
                Value = sql.Value
            });
        }

        public ForestUidSecond GetById(int id)
        {
            return _ctx.ForestUidSecondDbSet.Select(sql => new ForestUidSecond()
            {
                Id = sql.Id,
                Value = sql.Value
            }).FirstOrDefault(first => first.Id == id);
        }
    }
}