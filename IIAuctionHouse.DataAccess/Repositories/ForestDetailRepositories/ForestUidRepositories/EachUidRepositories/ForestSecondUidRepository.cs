using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IIAuctionHouse.Core.Models.ForestDetailModels.ForestUidModels.EachUidModels;
using IIAuctionHouse.DataAccess.Converters.ForestDetailConverters.ForestUidConverters;
using IIAuctionHouse.DataAccess.Exceptions;
using IIAuctionHouse.Domain.IRepositories.IForestDetailRepositories.IForestUidRepositories.IEachUidRepositories;

namespace IIAuctionHouse.DataAccess.Repositories.ForestDetailRepositories.ForestUidRepositories.EachUidRepositories
{
    public class ForestSecondUidRepository: IForestSecondUidRepository
    {
        private readonly MainDbContext _ctx;
        private readonly ForestUidSecondConverter _forestUidSecondConverter;

        public ForestSecondUidRepository(MainDbContext ctx, ForestUidSecondConverter forestUidSecondConverter)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestUidSecondConverter = forestUidSecondConverter ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);
            
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
            var forestUidSecondSql = _forestUidSecondConverter.Convert(forestUidSecond);
            _ctx.ForestUidSecondDbSet.Add(forestUidSecondSql);
            _ctx.SaveChanges();
            return _forestUidSecondConverter.Convert(forestUidSecondSql);
        }

        public ForestUidSecond Update(ForestUidSecond forestUidSecond)
        {
            var forestUidSecondSql = _forestUidSecondConverter.Convert(forestUidSecond);
            var check =_ctx.ForestUidSecondDbSet.SingleOrDefault(sql => sql.Id == forestUidSecond.Id); 
            if (check != null) 
                _ctx.ForestUidSecondDbSet.Update(forestUidSecondSql);
            else
                throw new InvalidDataException(DataAccessExceptions.NotFound);
            _ctx.SaveChanges();
            return _forestUidSecondConverter.Convert(forestUidSecondSql);
        }

        public ForestUidSecond Delete(int id)
        {
            var forestUidSecondSql = _ctx.ForestUidSecondDbSet.FirstOrDefault(forestUidSecondSql => forestUidSecondSql.Id == id);
            if (forestUidSecondSql == null) return null;
            _ctx.ForestUidSecondDbSet.Remove(forestUidSecondSql);
            _ctx.SaveChanges();
            return _forestUidSecondConverter.Convert(forestUidSecondSql);
        }

        public ForestUidSecond GetById(int id)
        {
            return _ctx.ForestUidSecondDbSet.Select(tree => new ForestUidSecond()
            {
                Id = tree.Id,
                Value = tree.Value,
            }).FirstOrDefault(tree => tree.Id == id);
        }
    }
}