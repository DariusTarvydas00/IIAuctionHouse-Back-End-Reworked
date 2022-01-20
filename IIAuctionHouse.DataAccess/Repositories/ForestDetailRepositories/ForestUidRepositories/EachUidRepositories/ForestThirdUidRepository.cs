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
    public class ForestThirdUidRepository : IForestThirdUidRepository
    {
        private readonly MainDbContext _ctx;
        private readonly ForestUidThirdConverter _forestUidThirdConverter;

        public ForestThirdUidRepository(MainDbContext ctx, ForestUidThirdConverter forestUidThirdConverter)
        {
            _ctx = ctx ?? throw new NullReferenceException(DataAccessExceptions.NullContext);
            _forestUidThirdConverter = forestUidThirdConverter ?? throw new NullReferenceException(DataAccessExceptions.NullConverter);

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
            var forestUidThirdSql = _forestUidThirdConverter.Convert(forestUidThird);
            _ctx.ForestUidThirdDbSet.Add(forestUidThirdSql);
            _ctx.SaveChanges();
            return _forestUidThirdConverter.Convert(forestUidThirdSql);
        }

        public ForestUidThird Update(ForestUidThird forestUidThird)
        {
            var forestUidThirdSql = _forestUidThirdConverter.Convert(forestUidThird);
            var check =_ctx.ForestUidThirdDbSet.SingleOrDefault(sql => sql.Id == forestUidThird.Id); 
            if (check != null) 
                _ctx.ForestUidThirdDbSet.Update(forestUidThirdSql);
            else
                throw new InvalidDataException(DataAccessExceptions.NotFound);
            _ctx.SaveChanges();
            return _forestUidThirdConverter.Convert(forestUidThirdSql);
        }

        public ForestUidThird Delete(int id)
        {
            var forestUidThirdSql = _ctx.ForestUidThirdDbSet.FirstOrDefault(forestUidThirdSql => forestUidThirdSql.Id == id);
            if (forestUidThirdSql == null) return null;
            _ctx.ForestUidThirdDbSet.Remove(forestUidThirdSql);
            _ctx.SaveChanges();
            return _forestUidThirdConverter.Convert(forestUidThirdSql);
        }

        public ForestUidThird GetById(int id)
        {
            return _ctx.ForestUidThirdDbSet.Select(tree => new ForestUidThird()
            {
                Id = tree.Id,
                Value = tree.Value,
            }).FirstOrDefault(tree => tree.Id == id);
        }
    }
}