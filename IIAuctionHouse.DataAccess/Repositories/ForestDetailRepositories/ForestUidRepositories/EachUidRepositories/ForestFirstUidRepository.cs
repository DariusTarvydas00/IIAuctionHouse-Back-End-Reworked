using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories.EachUidRepositories
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
            return _ctx.ForestUidFirstDbSet.OrderBy(sql => sql.Value).Select(sql => new ForestUidFirst()
            {
                Id = sql.Id,
                Value = sql.Value
            });
        }

        public ForestUidFirst GetById(int id)
        {
            return _ctx.ForestUidFirstDbSet.Select(sql => new ForestUidFirst()
            {
                Id = sql.Id,
                Value = sql.Value
            }).FirstOrDefault(first => first.Id == id);
        }
    }
}