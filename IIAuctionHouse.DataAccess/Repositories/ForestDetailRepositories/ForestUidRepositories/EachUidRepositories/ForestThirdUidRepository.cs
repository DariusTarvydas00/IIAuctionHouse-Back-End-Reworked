using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories.EachUidRepositories
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
            return _ctx.ForestUidThirdDbSet.OrderBy(sql => sql.Value).Select(sql => new ForestUidThird()
            {
                Id = sql.Id,
                Value = sql.Value
            });
        }

        public ForestUidThird GetById(int id)
        {
            return _ctx.ForestUidThirdDbSet.Select(sql => new ForestUidThird()
            {
                Id = sql.Id,
                Value = sql.Value
            }).FirstOrDefault(first => first.Id == id);
        }
    }
}