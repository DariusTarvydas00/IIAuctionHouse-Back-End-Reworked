using System;
using System.Collections.Generic;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.TreeTypes.TTModels;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.ITreeTypeRepositories.TTRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.TreeTypeRepositories.TTRepositories
{
    public class PercentageRepository : IPercentageRepository
    {
        private readonly MainDbContext _ctx;

        public PercentageRepository(MainDbContext ctx)
        {
            _ctx = ctx ?? throw new NullReferenceException("Context Can Not Be Null");
        }

        public IEnumerable<Percentage> FindAll()
        {
            return _ctx.PercentageDbSet.OrderBy(sql => sql.Value).Select(percentageSql => new Percentage()
            {
                Id = percentageSql.Id,
                Value = percentageSql.Value
            }).ToList();
        }
        
        public Percentage GetById(int id)
        {
            try
            {
                return _ctx.PercentageDbSet.Select(tree => new Percentage()
                {
                    Id = tree.Id,
                    Value = tree.Value,
                }).FirstOrDefault(tree => tree.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception("Percentage Can Not be Deleted!");
            }
        }
    }
}